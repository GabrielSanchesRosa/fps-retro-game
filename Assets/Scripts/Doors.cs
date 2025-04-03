using UnityEngine;

public class Doors : MonoBehaviour {
    [SerializeField] private Animator oDoorAnimator;
    [SerializeField] private Collider2D doorCollider;

    [SerializeField] private bool normalDoor, silverDoor, goldenDoor, closedDoor;

    void Start() {
        closedDoor = true;
    }

    void Update() {
        
    }

    private void OpenDoor() {
        oDoorAnimator.SetTrigger("OpeningDoor");

        closedDoor           = false;
        doorCollider.enabled = false;
    }

    private void CloseDoor() {
        oDoorAnimator.SetTrigger("ClosingDoor");

        closedDoor           = true;
        doorCollider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (closedDoor) {
                if (normalDoor) {
                    OpenDoor();
                }

                if (silverDoor) {
                    if (GameManager.instance.haveSilverKey) {
                        OpenDoor();
                    }
                }

                if (goldenDoor) {
                    if (GameManager.instance.haveGoldenKey) {
                        OpenDoor();
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (!closedDoor) {
                CloseDoor();
            }
        }
    }
}
