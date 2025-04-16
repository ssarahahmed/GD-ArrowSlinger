using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    [SerializeField] Transform Bow;
    [SerializeField] GameObject ArrowPrefab;
    public float arrowSpeed = 10f;
    public float maxChargeTime = 2f; 
    public float maxForceMultiplier = 2f; 

    private Vector2 movement;
    private float holdTime = 0f;
    private bool isCharging = false;

    void Update()
    {
        MovementInput();
        RotateBowWithMouse();

        if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
            holdTime = 0f;
        }

        if (Input.GetMouseButton(0) && isCharging)
        {
            holdTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0) && isCharging)
        {
            ShootArrow();
            isCharging = false;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    void RotateBowWithMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 direction = (mousePos - Bow.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Bow.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    void MovementInput()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        movement = new Vector2(mx, my).normalized;
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(ArrowPrefab, Bow.position, Bow.rotation);
        Rigidbody2D rbArrow = arrow.GetComponent<Rigidbody2D>();

        Vector2 arrowDirection = Bow.right.normalized;

        float forceMultiplier = Mathf.Lerp(1f, maxForceMultiplier, Mathf.Clamp01(holdTime / maxChargeTime));
        rbArrow.AddForce(arrowDirection * arrowSpeed * forceMultiplier, ForceMode2D.Impulse);

        arrow.GetComponent<ArrowRotation>()?.EnableAutoRotation();
    }
}
