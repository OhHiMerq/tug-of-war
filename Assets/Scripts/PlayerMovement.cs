using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementForce;

    [Range(0f, 100f)] public float raycastDistance = 1.5f;
    public LayerMask whatIsGround;
    public bool isGround = false;
    private Rigidbody2D rb;

    [Header("Animation")]
    public Animator anim;
    public bool leftPlayer = false;
    private float xDir;

public float maxVelocity = 8f;
    public float baseVelocity = 0f; // The base velocity of the player
    public float velocityIncreasePerClick = 0.5f; // The amount of velocity increase per key press
    public float velocityDecreaseRate = 1f; // The rate at which the velocity decreases when not spamming

    public float currentVelocity; // The current velocity of the player
    // Start is called before the first frame update
    void Start()
    {
      currentVelocity = baseVelocity;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = IsGrounded();
        Movement();
    }

    private void Movement(){
        if(leftPlayer ){
            if (Input.GetKeyDown(KeyCode.W) && Mathf.Abs(currentVelocity) < maxVelocity && isGround)
        {
            currentVelocity -= velocityIncreasePerClick;
        }

        if (!Input.GetKey(KeyCode.W) && Mathf.Abs(currentVelocity) > baseVelocity)
        {
            currentVelocity += velocityDecreaseRate * Time.deltaTime;
            currentVelocity = Mathf.Min(currentVelocity, baseVelocity);
        }
        }else{
           if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(currentVelocity) < maxVelocity && isGround)
        {
            currentVelocity += velocityIncreasePerClick;
        }

        if (!Input.GetKey(KeyCode.UpArrow) && Mathf.Abs(currentVelocity) > baseVelocity)
        {
            currentVelocity -= velocityDecreaseRate * Time.deltaTime;
            currentVelocity = Mathf.Max(currentVelocity, baseVelocity);
        }
        }

        rb.velocity = new Vector2(currentVelocity*(movementForce* Time.deltaTime),rb.velocity.y);
        if (Mathf.Abs(currentVelocity) > baseVelocity) {
            anim.SetBool("Walk", true);
        }else{
            anim.SetBool("Walk", false);
        }
        // animatiom


    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;
    }
}
