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
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            int roomIndex = 0;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player == PhotonNetwork.LocalPlayer)
                {
                    Vector3 spawnPosition = _spawnPointsPlayers[roomIndex].position;

                    PhotonNetwork.Instantiate(_player.name, spawnPosition, Quaternion.identity);
                    break;
                }

                roomIndex++;
            }
        }
    }
}
