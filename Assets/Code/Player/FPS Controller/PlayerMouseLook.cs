using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private Transform _playerBody;

    private float _rotationX;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float x = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _rotationX -= y;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        _playerBody.Rotate(Vector3.up * x);
    }
}
