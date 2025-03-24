using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    [SerializeField] private Camera gameCam;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int ammo;

    void Start() {
        
    }

    void Update() {
        Shoot();
    }

    private void Shoot() {
        if (Input.GetButtonDown("Fire1")) {
            if (ammo > 0) {
                Ray ray = gameCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit  raycastHit;

                if (Physics.Raycast(ray, out raycastHit)) {
                    Debug.Log("I'm lookin at: " + raycastHit.transform.name);
                } else {
                    Debug.Log("I'm lookin at nothing.");
                }

                ammo--;
            } else {
                Debug.Log("No ammo.");
            }
        }
    }
}
