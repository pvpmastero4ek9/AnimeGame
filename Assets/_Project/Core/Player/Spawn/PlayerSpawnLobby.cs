using UnityEngine;
using Photon.Pun;

namespace Core.PlayersSpawn
{
    public class PlayerSpawnLobby : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        
        private void Start()
        {
            PhotonNetwork.Instantiate(_player.name, new Vector2(), Quaternion.identity);
        }
    }
}
