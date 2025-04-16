using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // Called when the "Play Again" button is clicked
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

