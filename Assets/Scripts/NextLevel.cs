using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    [SerializeField] private Animator oAnimatorTransition;
    [SerializeField] private string nextLevel;
    [SerializeField] private float waitTime;

    private IEnumerator LoadNextLevel() {
        oAnimatorTransition.Play("ImageDarkening");
        
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(nextLevel);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            StartCoroutine(LoadNextLevel());
        }
    }
}
