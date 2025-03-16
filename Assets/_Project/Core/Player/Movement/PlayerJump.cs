using UnityEngine;
using Photon.Pun;

namespace Core.PlayerMovement
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private int _jumpForce;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private float _groundRadius = 0.3f;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundMask; 
        private bool _isGrounded;

        private void Update()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                Jump();
            }
        }

        private void Jump()
        {
            if (_photonView.IsMine)
            {
                _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
