using UnityEngine;
using Photon.Pun;

namespace Core.PlayerMovement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PhotonView _photonView;

        private void FixedUpdate()
        {
            if (_photonView.IsMine)
            {
                Move(); 
            }
        }

        private void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            
            _rigidbody.linearVelocity = new Vector2(moveX * _speed, _rigidbody.linearVelocity.y);
        }
    }
}
