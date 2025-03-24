using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public static PlayerControl instance;

    [SerializeField] private Rigidbody2D oRigidbody2D;
    [SerializeField] private Animator GunPanelAnimator;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float mouseSensitivity;

    private Vector2 keyboardCommands;
    private Vector2 mouseMovement;

    void Awake()
    {
        instance = this;
    }

    void Start() {
        
    }

    void Update() {
        
    }

    void FixedUpdate() {
        MovePlayer();
        MoveCam();
    }

    private void MovePlayer() {
        keyboardCommands = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMove = transform.up * -keyboardCommands.x;
        Vector3 verticalMove   = transform.right * keyboardCommands.y;

        oRigidbody2D.linearVelocity = (horizontalMove + verticalMove) * playerSpeed;

        if (oRigidbody2D.linearVelocity.magnitude == 0) {
            GunPanelAnimator.Play("PlayerStopped");
        } else {
            GunPanelAnimator.Play("WalkingPlayer");
        }
    }

    private void MoveCam() {
        mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity, Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseMovement.x);
    }
}
