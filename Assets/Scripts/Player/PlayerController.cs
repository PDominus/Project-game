using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    

    public static PlayerController instance;


    public Rigidbody2D theRB;
    public float moveSpeed;
    public float jumpForce;

    //public float runSpeed;

    //public bool isRunning;

    private SpriteRenderer theSR;

    public bool IsGround;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private Animator anim;

    private Vector2 boxsize = new Vector2(0.1f, 1f);

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 7f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;


    private void Awake()
    {
        instance = this;

        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);

        /*
        if (isRunning)
        {
            theRB.velocity = new Vector2(runSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);
        }
        else { 

            theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);
        }*/

        if(theRB.velocity.y > 0)
        {
            //anim.SetBool("canJump", false);
            anim.SetBool("JumpUp", true);
            anim.SetBool("JumpDown", false);
        }

        else if (theRB.velocity.y < 0)
        {
            anim.SetBool("canJump", false);
            anim.SetBool("JumpDown", true);
            anim.SetBool("JumpUp", false);
        }

        if (theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if (theRB.velocity.x > 0) //then you walk to left and standing still the head will one the same way
        {
            theSR.flipX = false;
        }

        IsGround = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        anim.SetFloat("yVelocity", theRB.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGround)
            {
                anim.SetBool("canJump", true);
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
              
            }

            else
            {
                anim.SetBool("canJump", false);
                theRB.velocity = new Vector2(theRB.velocity.x, .0f);

            }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        //anim.SetBool("isRunning" , isRunning);

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        //Set the yVelocity in the animator
        anim.SetFloat("yVelocity", theRB.velocity.y);

    }

    /*private void OnTriggerEnter2D(Collider2D target)

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("ToNextScene"))
        {
            //Debug.Log("Crash!");
            SceneManager.LoadScene("Scene2");
        }
    }*/

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        anim.SetBool("isDashing", true);
        float originalGravity = theRB.gravityScale;
        theRB.gravityScale = 0f;

        if (theRB.velocity.x < 0)
        {
            theRB.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);
        }
        else if (theRB.velocity.x > 0) //then you walk to left and standing still the head will one the same way
        {
            theRB.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }

        //theRB.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        theRB.gravityScale = originalGravity;
        isDashing = false;
        anim.SetBool("isDashing", false);
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
