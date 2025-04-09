using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
    [SerializeField] private string menuName;

    public void LoadMenu() {
        SceneManager.LoadScene(menuName);
    }

    public void ExitGame() {
        Application.Quit();
        Debug.Log("Saiu do Jogo");
    }
}
