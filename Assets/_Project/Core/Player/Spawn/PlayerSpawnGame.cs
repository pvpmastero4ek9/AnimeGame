using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Collections;

namespace Core.PlayersSpawn
{
    public class PlayerSpawnGame : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private Transform[] _spawnPointsPlayers;

        private void Start() 
        {
            StartCoroutine(WaitForRoomIndexAndSpawn());
        }

        private IEnumerator WaitForRoomIndexAndSpawn()
        {
            // Ждем, пока RoomIndex не появится
            while (!PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("RoomIndex"))
            {
                yield return null; // Ждём, пока RoomIndex синхронизируется
            }

            int roomIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["RoomIndex"];
            Debug.Log(roomIndex);
            Vector3 spawnPosition = _spawnPointsPlayers[roomIndex].position;

            PhotonNetwork.Instantiate(_player.name, spawnPosition, Quaternion.identity);
        }
    }
}
