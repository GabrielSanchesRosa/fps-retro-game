using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public void ResumeGame() {
        GameManager.instance.PauseGame();
    }

    public void ExitGame() {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}
