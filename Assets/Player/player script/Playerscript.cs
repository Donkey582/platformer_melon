using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    [Header("Debug")]
    public bool debug;
    public bool isdead;

    [Header("Components")]
    public Rigidbody2D rig;
    public Animator animator;
    public AudioSource audio;
    public Collider2D collider;


    [Header("Movement Vars")]
    public float x_input;
    public float y_input;
    public float moveSpeed;
    public float climbSpeed;
    public bool isClimbing;
    public int facingDir;
    public bool isWalking; // add for animation


    [Header("Jump Vars")]
    public float jumpForce;
    public int maxJumps;
    public int jumpCount;
    public bool isJumping;




    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }



    // Start is called before the first frame update
    void Start()
    {
        x_input = 0f;
        y_input = 0f;
        isClimbing = false;
        isJumping = false;
        facingDir = 1;

        maxJumps = 2;



    }

    private void FixedUpdate()
    {
        x_input = Input.GetAxis("Horizontal");
       
        move(x_input);
    }

    // Update is called once per frame
    void Update()
    {

        // set animator state
        animator.SetBool("walking", isWalking);
        animator.SetBool("jumping", isJumping);
        animator.SetBool("isdead", isdead);


        if(rig.velocity.y <= 0)
        {
            if (isGrounded())
            {
                reset_jump_count();
            }
        }
        // check for jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }


        // debug
        if (debug)
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .05f, transform.position.z), Vector2.down);

            Debug.DrawRay(new Vector3(transform.position.x + .335f, transform.position.y - .05f, transform.position.z), Vector2.down);
            Debug.DrawRay(new Vector3(transform.position.x - .335f, transform.position.y - .05f, transform.position.z), Vector2.down);
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .05f, transform.position.z), Vector2.down);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }


    private void jump()
    {
        if(jumpCount > 0)
        {
            isJumping = true;
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    private void move(float x_input)
    {
        if(x_input != 0 && !isJumping)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        if (x_input > 0)
        {
            facingDir = 1;
        }
        else if (x_input < 0)
        {
            facingDir = -1;
        }
        transform.localScale = new Vector3(facingDir, transform.localScale.y, transform.localScale.z);
        rig.velocity = new Vector2(x_input * moveSpeed, rig.velocity.y);
    }

    public void collect(int value)
    {

    }

    private void climb()
    {

    }

    private void crouch()
    {

    }

    public void die()
    {

    }

    private bool isGrounded()
    {
        RaycastHit2D hitCenter = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .05f, transform.position.z), Vector2.down);
        if (hitCenter)
        {


            if (hitCenter.collider.gameObject.CompareTag("ground"))
            {
                return true;
            }
        }
        return true;
    }
    public void reset_jump_count()
    {
        isJumping = false;
        jumpCount = maxJumps;
    }

    private void shoot()
    {

    }




}
