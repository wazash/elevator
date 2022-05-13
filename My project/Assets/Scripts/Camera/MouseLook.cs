using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float minRotation = -90f, maxRotation = 90f;

    [SerializeField] private Transform body;

    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        body.Rotate(Vector3.up, mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minRotation, maxRotation);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
