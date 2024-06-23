using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private CharacterController _controller;

    [SerializeField] private float _gravity = -9.81f;
    private Vector3 _velocity;

    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private float _distanceToGround;
    [SerializeField] private LayerMask _groundMask;

    private bool _isGrounded;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * z + transform.right * x;
        Vector3.ClampMagnitude(movement, _speed);
        _controller.Move(movement * _speed * Time.deltaTime);

        _isGrounded = Physics.CheckSphere(_groundCheckPoint.position, _distanceToGround, _groundMask);

        if (_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _velocity.y = Mathf.Sqrt(-_jumpHeight * 2 * _gravity);
            }
        }
        else
        {
            _velocity.y += _gravity * Time.deltaTime;
        }

        //if (!_isGrounded)
        //{
        //    _velocity.y += _gravity * Time.deltaTime;
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        _velocity.y = Mathf.Sqrt(-_jumpHeight * 2 * _gravity);
        //    }
        //}

        _controller.Move(_velocity * Time.deltaTime);
    }
}
