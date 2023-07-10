using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sp;
    private BoxCollider2D coll;
    

    [SerializeField] private LayerMask jumpableGround; //To access the layers in Unity


    [SerializeField] private float jumpValue = 8f;
    private float moveForward=6f;
    private float dirX = 0f;

    private enum MovementState // creating states for animations 
    {
        idle, running, jumping, falling
    }

    [SerializeField] private AudioSource jumpSoundEffect;








    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll= GetComponent<BoxCollider2D>();




    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         dirX=Input.GetAxisRaw("Horizontal"); //Raw for more precise Inputs
        rb.velocity = new Vector2(dirX*moveForward,rb.velocity.y); //we want it to still have the previous y velocity

        if(Input.GetButtonDown("Jump") && isGrounded()) //isGrounded to check if the player is on the ground and only jump once  
        {
            jumpSoundEffect.Play();

            rb.velocity = new Vector2(0, jumpValue);

        }

        UpdateAnimationState();



    }
    private void UpdateAnimationState()
    {
        MovementState state; //our enum 
        
        if (dirX > 0f)
        {
            state = MovementState.running;

            sp.flipX = false;
           // anim.SetBool("is_Running", true); //setting the parameter we defined as true

        }
        else if (dirX < 0f)
        {

            sp.flipX = true;
            // anim.SetBool("is_Running", true);
            state = MovementState.running;

        }
        else
        {
            //anim.SetBool("is_Running", false);
            state = MovementState.idle;

        }
        if(rb.velocity.y> .1f) //not zero
        {
            state = MovementState.jumping; 

        }
        if(rb.velocity.y < -.1f) //not zero
        {
            state = MovementState.falling;

        }
        anim.SetInteger("state", (int)state); //cast chose enum values are int in c

    }

    private bool isGrounded()
    {
        //create a box around our player like BoxCollider, 0 angle, offset with dowm vetor 
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        //pretty much checkign if we are overlapping the jumppableGround layer

    }
}
