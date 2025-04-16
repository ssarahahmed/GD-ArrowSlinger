//using UnityEngine;
//using System.Collections;

//namespace NetDinamica.AppFast
//{
//    public class PlayAnimations : MonoBehaviour
//    {

//        // Use this for initialization
//        Animator anim;
//        bool facingRight = true;

//        void Start()
//        {
//            anim = GetComponentInChildren<Animator>();
//        }

//        // Update is called once per frame
//        void Update()
//        {
//            if (Input.GetKeyDown(KeyCode.Alpha1))
//            {
//                anim.Play("Idle");
//            }
//            else if (Input.GetKeyDown(KeyCode.Alpha3))
//            {
//                anim.Play("Walk");
//            }
//            else if (Input.GetKeyDown(KeyCode.Alpha5))
//            {
//                anim.Play("Attack");
//            }
//            if (Input.GetKeyDown(KeyCode.Alpha7))
//            {
//                anim.Play("Hurt");
//            }
//            else if (Input.GetKeyDown(KeyCode.Alpha9))
//            {
//                anim.Play("Die");
//            }
//            else if (Input.GetKeyDown(KeyCode.F))
//            {
//                Flip();
//            }
//        }

//        void Flip()
//        {
//            facingRight = !facingRight;
//            Vector3 theScale = transform.localScale;
//            theScale.x *= -1;
//            transform.localScale = theScale;

//        }
//    }

//}

using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // Speed of the zombie
    public Transform Player;        // Reference to the player's position (player character)
    private Animator anim;        // Animator for walking animation
    private bool isAttacking = false;  // Whether the zombie is attacking
    private Rigidbody2D rb;       // Rigidbody2D for movement

    void Start()
    {
        anim = GetComponentInChildren<Animator>(); // Get the animator
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component

        anim.Play("Walk"); // Start walking animation instantly

    }

    void Update()
    {
        if (isAttacking)
            return; // If already attacking, don't move

        // Move the zombie towards the player
        Vector3 direction = (Player.position - transform.position).normalized;

        // Apply movement using Rigidbody2D
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);  // Move horizontally, keep vertical velocity unchanged

        // Check if the zombie is close enough to attack
        if (Vector3.Distance(transform.position, Player.position) < 1f)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            anim.Play("Attack");
            // You can add a delay before the attack starts or any damage logic here
        }
    }
}
