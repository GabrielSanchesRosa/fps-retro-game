using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D oRigidbody2D;
    [SerializeField] private float playerSpeed;

    private Vector2 keyboardCommands;
    void Start()
    {
        
    }

    void Update()
    {
        movePlayer();
    }

    private void movePlayer() 
    {
        keyboardCommands = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMove = transform.up * -keyboardCommands.x;
        Vector3 verticalMove   = transform.right * keyboardCommands.y;

        oRigidbody2D.linearVelocity = (horizontalMove + verticalMove) * playerSpeed;
    }
}
