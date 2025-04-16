using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            Destroy(collision.gameObject); // Destroy zombie
            Destroy(gameObject); // Destroy arrow

            ScoreManager.Instance.AddScore(1);
        }
    }
}
