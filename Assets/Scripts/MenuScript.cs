using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayEasy()
    {
        SceneManager.LoadScene("Easy Mode");
    }

    public void PlayMedium()
    {
        SceneManager.LoadScene("Medium Mode");
    }

    public void PlayHard()
    {
        SceneManager.LoadScene("Hard Mode");
    }


}

