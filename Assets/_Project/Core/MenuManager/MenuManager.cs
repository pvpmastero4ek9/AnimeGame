using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

namespace Core.MenuManagers
{
    public class MenuManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private int _maxPlayers;
        [SerializeField] private string _nameScene;
        [SerializeField] private TMP_InputField _createInput;
        [SerializeField] private TMP_InputField _joinInput;

        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = _maxPlayers;
            PhotonNetwork.CreateRoom(_createInput.text, roomOptions);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(_joinInput.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel($"{_nameScene}");
        }
    }
}
