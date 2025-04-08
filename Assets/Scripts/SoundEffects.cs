using UnityEngine;

public class SoundEffects : MonoBehaviour {
    public static SoundEffects instance;

    [SerializeField] private AudioSource enemyAttack, playerAttack, keyCollected, enemyDamage, playerDamage, enemyDefeated, ammoCollected, noAmmo, lifeCollected;

    void Awake() {
        instance = this;
    }

    public void PlaySoundEffects(string soundEffect) {
        switch (soundEffect) {
            case "enemyAttack":
                enemyAttack.Play();
                break;
            
            case "playerAttack":
                playerAttack.Play();
                break;
            
            case "keyCollected":
                keyCollected.Play();
                break;

            case "enemyDamage":
                enemyDamage.Play();
                break;

            case "playerDamage":
                playerDamage.Play();
                break;

            case "enemyDefeated":
                enemyDefeated.Play();
                break;

            case "ammoCollected":
                ammoCollected.Play();
                break;

            case "noAmmo":
                noAmmo.Play();
                break;

            case "lifeCollected":
                lifeCollected.Play();
                break;   
        }
    }
}
