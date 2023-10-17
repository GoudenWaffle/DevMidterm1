using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float horizontalMove;
    float lastYVelocity = 0;
    public float speed = 2f;

    Rigidbody2D myBody;

    //bool grounded = false;//ply has to be on the ground to jump
    public float castDist = 1f;

    public float jumpPower = 2f;
    public float jumpPowerPlus = 4f;
    public float gravityScale = 5f;
    public float gravityFall = 30f;

    bool jump = false;

    [SerializeField] bool jumpedInAir = false;

    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();//grab plyer's ridigbody
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");//left right move

        //if (Input.GetButtonDown("Jump") && grounded)//first jump
        //{
        //    myAnim.SetBool("jumping", true);
        //    jump = true;

        //}



        if (horizontalMove > 0.2f || horizontalMove < -0.2f)
        {
            myAnim.SetBool("running", true);
        }
        else
        {
            myAnim.SetBool("running", false);
        }

        float moveSpeed = horizontalMove * speed;


        //verticle movement//--------------------------------------------------------
        //if(jump)
        //{
        //    myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //    jump = false;
        //    jumpedInAir = true;
        //}
        //if (Input.GetButtonDown("Jump") && jumpedInAir && !grounded) //double jump
        //{
        //    myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //    myAnim.SetBool("jumping", true);
        //    jumpedInAir = false;
        //    Debug.Log("doubleJump");
        //}

        if (myBody.velocity.y > 0)//if goingup
        {
            myBody.gravityScale = gravityScale;
        }
        else if (myBody.velocity.y < 0)//if falling
        {
            myBody.gravityScale = gravityFall;
        }

        Debug.Log(Mathf.Abs(this.lastYVelocity - GetComponent<Rigidbody2D>().velocity.y) < 0.1);


        // determine whether player is on ground

        if (Mathf.Abs(this.lastYVelocity - GetComponent<Rigidbody2D>().velocity.y) < 0.1)// if <0.1 not in air,is grounded
        {
            jumpedInAir = false;
            myAnim.SetBool("jumping", false);
            if (Input.GetButtonDown("Jump"))
            {
                myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                myAnim.SetBool("jumping", true);

            }

        }
        else//not grounded, already in air
        {
            if (Input.GetButtonDown("Jump") && !jumpedInAir)
            {
                jumpedInAir = true;
                myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }

        }

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);//draw a line
        //Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);

        ////if(hit.collider != null && hit.transform.name == "Ground")
        //if (hit.collider != null && hit.transform.tag =="Ground")//inspector tag ground
        //{
        //    myAnim.SetBool("jumping", false);//animation change
        //    grounded = true;
        //   // jumpedInAir = false;
        //}
        //else
        //{
        //    grounded = false;
        //}

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0f);
        // x, y(jump),z(not using for 2d

        lastYVelocity = GetComponent<Rigidbody2D>().velocity.y;
    }

     void FixedUpdate()//update with rest of the physcis
    {
        
    }
}
