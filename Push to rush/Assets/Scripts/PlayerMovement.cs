using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject arrow;
    public float speed,jumpForce,arrowSpeed,angle; 
    float horizontal,direction;
    Rigidbody2D playerRB;
    Animator animator;
    bool isJumping;
    void Start()
    {
        
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isJumping = false;
        direction = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject arrowInstant = Instantiate(arrow);
            arrowInstant.transform.position = transform.position;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint
            (new Vector3(mousePosition.x,mousePosition.y,mousePosition.z));
            Vector3 forward = mousePosition - arrowInstant.transform.position;
            arrowInstant.transform.up = new Vector3(forward.x,forward.y,0);
            arrowInstant.transform.Rotate(0,0,forward.y+90);
            arrowInstant.GetComponent<Rigidbody2D>().velocity = arrowInstant.transform.right*arrowSpeed;
            Destroy(arrowInstant,2);
        }
        horizontal = Input.GetAxis("Horizontal");
        if(horizontal<0)
        {
            direction = -180;
            animator.SetBool("isMoving",true);
        }
        else if(horizontal>0)
        {
            direction = 0;
            animator.SetBool("isMoving",true);
        }
        else 
        {
            animator.SetBool("isMoving",false);
        }
        gameObject.transform.rotation = Quaternion.Euler(0,direction,0);
        gameObject.transform.position += new Vector3(horizontal,0,0)*speed*Time.deltaTime;
    }
    void FixedUpdate()
    {
        if((Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.Space))&& !isJumping)
        {
            isJumping = true;
            Jump();
        }
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        isJumping = false;
    }
    void Jump()
    {
        playerRB.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
    }
}
