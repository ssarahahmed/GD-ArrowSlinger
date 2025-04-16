using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool autoRotate = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (autoRotate && rb.linearVelocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            rb.MoveRotation(angle);
        }
    }

    public void EnableAutoRotation()
    {
        autoRotate = true;
    }
}
