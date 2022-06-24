using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Health script;

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public GameObject FirePoint;
    public int damageAmount;

    void Start()
    {
        FirePoint.transform.eulerAngles = new Vector3(0, 180, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {

        // take damage function testing
        if (Input.GetKeyDown("j"))
        {
            TakeDamage(1);
        }
        // take damage function testing

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (moveInput > 0)
        {
            FirePoint.transform.eulerAngles = new Vector3(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if(moveInput < 0){
            FirePoint.transform.eulerAngles = new Vector3(0, 180, 0);
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.UpArrow) && isJumping == true){

            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }
    }

    

    public void TakeDamage(int damageAmount)
    {
       script.health -= damageAmount;
    }


}
