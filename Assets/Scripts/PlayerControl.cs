using UnityEngine;

public class PlayerControl : MonoBehaviour {
    [SerializeField] private Rigidbody2D oRigidbody2D;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float mouseSensitivity;

    private Vector2 keyboardCommands;
    private Vector2 mouseMovement;

    void Start() {
        
    }

    void Update() {
        MovePlayer();
        MoveCam();
    }

    private void MovePlayer() {
        keyboardCommands = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMove = transform.up * -keyboardCommands.x;
        Vector3 verticalMove   = transform.right * keyboardCommands.y;

        oRigidbody2D.linearVelocity = (horizontalMove + verticalMove) * playerSpeed;
    }

    private void MoveCam() {
        mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity, Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseMovement.x);
    }
}
