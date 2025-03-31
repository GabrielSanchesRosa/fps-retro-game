using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
    [SerializeField] private Camera gameCam;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Text ammoText;

    [SerializeField] private int maxAmmo, ammo, weaponDamage;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;

        UpdateAmmo(ammo);
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
                    Instantiate(impactEffect, raycastHit.point, raycastHit.transform.rotation);
                    Debug.Log("I'm lookin at: " + raycastHit.transform.name);

                    if (raycastHit.transform.gameObject.CompareTag("Enemy")) {
                        raycastHit.transform.gameObject.GetComponentInParent<Enemy>().HitEnemy(weaponDamage);
                    }
                } else {
                    Debug.Log("I'm lookin at nothing.");
                }

                gunAnimator.SetTrigger("ShootingGun");
                ammo--;
                UpdateAmmo(ammo);
            } else {
                Debug.Log("No ammo.");
            }
        }
    }

    private void UpdateAmmo(int newAmmo) {
        ammoText.text = "AMMO\n" + newAmmo;
    }

    public void AddAmmo(int collectedAmmo) {
        if (collectedAmmo + ammo < maxAmmo) {
            ammo += collectedAmmo;
        } else {
            ammo = maxAmmo;
        }

        UpdateAmmo(ammo);
    }
}
