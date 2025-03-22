using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Core.LobbyReady
{
    public class DistributionPlayersRooms : MonoBehaviourPunCallbacks
    {
        [SerializeField] private int _roomCount;
        [SerializeField] private string _nameLoadScene;
        [SerializeField] private LobbyReadySystem _lobbyReadySystem;

        public override void OnEnable()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            _lobbyReadySystem.AllPlayersReady += DistributePlayersToRooms;
        }

        public override void OnDisable() 
        {
            _lobbyReadySystem.AllPlayersReady -= DistributePlayersToRooms;
        }

        private void DistributePlayersToRooms()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel($"{_nameLoadScene}");
            }
        }
    }
}
