using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Core.ConnectServer
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        [SerializeField] private string _menuNameScene;
        private void Start() 
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene($"{_menuNameScene}");
        } 
    }
}
