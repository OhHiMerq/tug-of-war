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
    private float xDir;
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
        if(leftPlayer ){
            if(Input.GetKey(KeyCode.A)){
                xDir = -1;
            }else if(Input.GetKey(KeyCode.D)){
                xDir = 1;
            }else{
                xDir = 0;
            }
        }else{
            if(Input.GetKey(KeyCode.LeftArrow)){
                xDir = -1;
            }else if(Input.GetKey(KeyCode.RightArrow)){
                xDir = 1;
            }else{
                xDir = 0;
            }
        }

        rb.velocity = new Vector2(xDir * (movementForce*Time.deltaTime),rb.velocity.y);
        if (Mathf.Abs(xDir) > 0) {
            anim.SetBool("Walk", true);
        }else{
            anim.SetBool("Walk", false);
        }
        // animatiom

        
    }

    private void LeftMovement(){
        
            rb.velocity = new Vector2(xDir * (movementForce*Time.deltaTime),rb.velocity.y);
    }

    private void WalkAnim(){

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
