using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 6.5f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float GravityScale;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool doubleJump;
    [SerializeField] private float doubleJumpForce = 6.5f;

    private bool isInvicible = false;

    public int currentItems;

    [SerializeField] private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = GravityScale;
    }



    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            anim.SetBool("IsWalking", horizontal != 0);
            return;
        }

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
            anim.SetBool("IsJumping", false);
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJump ? doubleJumpForce : jumpForce);

                doubleJump = !doubleJump;
                anim.SetBool("IsJumping", true);
            }
        }

    }


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y  * Time.fixedDeltaTime;
        }
       anim.SetFloat("YVelocity", rb.linearVelocity.y);






        horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetBool("IsWalking", horizontal != 0);


        


        Flip();




    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }



    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        { 
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;


        }
    
    }


    //Respawn Code

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RespawnTrigger") && !isInvicible)
        {
            TakeDamage();

        }

    }

    void TakeDamage()
    {
        isInvicible = true;
        HealthManager.health--;

        if (HealthManager.health <= 0)
        {
            StartCoroutine(Die());

        }

        else
        {
            Respawn();
            StartCoroutine(GetHurt());
        }
    }

    void Respawn()
    {
        transform.position = RespawnController.Instance.respawnPoint.position;
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(7, 8, false);

        isInvicible = false;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);

        GameManager.isGameOver = true;
        gameObject.SetActive(false);
    }


    //Item Collection Code 
    public void AddItem()
    {
        currentItems++; // เพิ่มจำนวนไอเท็มเมื่อผู้เล่นเก็บไอเท็ม
        Debug.Log("Current Items: " + currentItems);
    }

    public bool UseItems(int amount)
    {
        if (currentItems >= amount)
        { 
            currentItems -= amount;
            return true;
        
        
        
        }
        return false;
    
    
    }


}
