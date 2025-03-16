using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using Core.LobbyReady;
using UI.CommonScripts;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

namespace UI.LobbyReady
{
    public class ReadyButton : MonoBehaviour
    {
        [SerializeField] private LobbyReadySystem _lobbyReadySystem;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _readyText;
        [SerializeField] private LocalizedString _format;
        [SerializeField] private Tab _readyState;
        [SerializeField] private Tab _notReadyState;
        private int _readyPlayers;

        private void OnEnable()
        {
            _notReadyState.Enable();

            _button.onClick.AddListener(ClickButton);
            _lobbyReadySystem.ChangeReady += ChangeState;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ClickButton);
            _lobbyReadySystem.ChangeReady -= ChangeState;
        }

        private void ClickButton()
        {
            _lobbyReadySystem.OnChangeReadyPlayer();
        }

        private void ChangeState(bool state)
        {
            if (state)
            {
                _readyState.Enable();
            }
            else
            {
                _notReadyState.Enable();
            }

            _readyPlayers = 0;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                bool playerReady = (bool)player.CustomProperties.GetValueOrDefault("IsReady", false);
                
                if (playerReady) _readyPlayers++;
            }

            _readyText.text = _format.GetLocalizedString(_readyPlayers, PhotonNetwork.PlayerList.Length);
        }
    }
}
