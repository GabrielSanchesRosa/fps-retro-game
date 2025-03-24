using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    [SerializeField] private Camera gameCam;

    void Start() {
        
    }

    void Update() {
        Shoot();
    }

    private void Shoot() {
        if (Input.GetButtonDown("Fire1")) {
            Ray ray = gameCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit  raycastHit;

            if (Physics.Raycast(ray, out raycastHit)) {
                Debug.Log("I'm lookin at: " + raycastHit.transform.name);
            } else {
                Debug.Log("I'm lookin at nothing.");
            }
        }
    }
}
