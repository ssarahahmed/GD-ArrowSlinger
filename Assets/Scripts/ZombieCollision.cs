using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            Destroy(other.gameObject); // Destroy arrow
            Destroy(gameObject);       // Destroy zombie
        }
        else if (other.CompareTag("Player"))
        {
            // Load GameOver scene
            SceneManager.LoadScene("GameOver");
        }
    }
}

