using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    public static PlayerController instance;


    public Rigidbody2D theRB;
    public float moveSpeed;
    public float jumpForce;

    public float moveRun;

    public bool isRunning;

    private SpriteRenderer theSR;

    public bool IsGround;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private Animator anim;

    private Vector2 boxsize = new Vector2(0.1f, 1f);


    private void Awake()
    {
        instance = this;
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

        

        if (isRunning)
        {
            theRB.velocity = new Vector2(moveRun * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);
        }
        else { 

        theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);
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

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGround)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else
            {
                theRB.velocity = new Vector2(theRB.velocity.x, .0f);
            }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isRunning" , isRunning);

    }

}
