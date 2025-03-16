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
            ReassignmentRoomPlayers();
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
        private void ReassignmentRoomPlayers()
        {
                int roomIndex = 0;
                
                foreach (Player player in PhotonNetwork.PlayerList)
                {
                    // Проверяем, установлен ли RoomIndex у игрока
                    if (!player.CustomProperties.ContainsKey("RoomIndex"))
                    {
                        ExitGames.Client.Photon.Hashtable props = new ExitGames.Client.Photon.Hashtable
                        {
                            { "RoomIndex", roomIndex } 
                        };
                        player.SetCustomProperties(props);
                        roomIndex++;
                    }
                }
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        {
            ReassignmentRoomPlayers();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            ReassignmentRoomPlayers();
        }

    }
}
