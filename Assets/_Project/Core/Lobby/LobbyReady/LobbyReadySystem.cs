using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

namespace Core.LobbyReady
{
    public class LobbyReadySystem : MonoBehaviourPunCallbacks
    {
        private bool _isReady = false;
        private int _readyPlayers;

        public delegate void ChangeReadyDelegate(bool isReady);
        public event ChangeReadyDelegate ChangeReady;
        public delegate void AllPlayersReadyDelegate();
        public event AllPlayersReadyDelegate AllPlayersReady;

        public void OnChangeReadyPlayer()
        {
            _isReady = !_isReady;

            ExitGames.Client.Photon.Hashtable props = new ExitGames.Client.Photon.Hashtable
            {
                { "IsReady", _isReady }
            };
            PhotonNetwork.LocalPlayer.SetCustomProperties(props);

            ChangeReady?.Invoke(_isReady);
        }

        private void CheckReadyAllPlayers()
        {
            _readyPlayers = 0;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                bool playerReady = (bool)player.CustomProperties.GetValueOrDefault("IsReady", false);
                
                if (playerReady) _readyPlayers++;
            }

            if (_readyPlayers == PhotonNetwork.PlayerList.Length)
            {
                AllPlayersReady?.Invoke();
            }
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        {
            CheckReadyAllPlayers();
            ChangeReady?.Invoke(_isReady);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            CheckReadyAllPlayers();
            ChangeReady?.Invoke(_isReady);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            CheckReadyAllPlayers();
            ChangeReady?.Invoke(_isReady);
        }
    }
}
