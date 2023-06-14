using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementForce;
    public float jumpForce;

    [Range(0f, 100f)] public float raycastDistance = 1.5f;
    public LayerMask whatIsGround;
    public bool isGround = false;
    private Rigidbody2D rb;

    [Header("Animation")]
    public Animator anim;
    public bool leftPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = IsGrounded();
        Movement();
        Jump();
    }

    private void Movement(){
       
        

        if(leftPlayer && (Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) ){
             float xDir = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(xDir * (movementForce*Time.deltaTime),rb.velocity.y);
            if (Mathf.Abs(xDir) > 0) 
            {
                anim.SetBool("Walk", true);
            }else{
                anim.SetBool("Walk", false);
            }
        }

        if(!leftPlayer && (Input.GetKey(KeyCode.UpArrow) ||Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) ){
             float xDir = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(xDir * (movementForce*Time.deltaTime),rb.velocity.y);
            if (Mathf.Abs(xDir) > 0) 
            {
                anim.SetBool("Walk", true);
            }else{
                anim.SetBool("Walk", false);
            }
        }
        // animatiom

        
    }

    private void Jump(){
        if(Input.GetKey(KeyCode.W) && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
        }
    }

    private bool IsGrounded() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;
    }
}
