using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer theSR;

    public float knockBackLength, knockBackForce;
    public float knockBackCounter;

    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(knockBackCounter <= 0 )
        {
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"),theRB.velocity.y);
        
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,.2f,whatIsGround);
        
            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if(Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x , jumpForce );
                }else
                {
                    if (canDoubleJump)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x , jumpForce );
                        canDoubleJump = false;
                    }
                }
                
            }
            if(theRB.velocity.x < 0)
            {
                theSR.flipX = true;
            }
            else if(theRB.velocity.x > 0)
            {
                theSR.flipX = false;
            }
        }else
        {
            knockBackCounter -= Time.deltaTime;
            if( !theSR.flipX )
            {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }
            else
            {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }
            
        }
        
       

        //anim.SetBool("isGrounded",isGrounded);
        //anim.SetFloat("moveSpeed",theRB.velocity.x);
        
    }
    public void KnockBack()
        {
            knockBackCounter = knockBackLength;
            theRB.velocity = new Vector2(0f, knockBackForce);
        }
}
