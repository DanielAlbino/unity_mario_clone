using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{

    public float moveSpeed = 1f;
    public LayerMask playerLayer;
    private Rigidbody2D myBody;
    private Animator anim;
    private bool moveLeft;

    private bool canMove;
    private bool stunned;

    public Transform left_Collision, right_Collision, up_Collision ,down_Collision;
    private Vector2 left_Collision_Position, right_Collision_Position;
   
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        left_Collision_Position = left_Collision.position;
        right_Collision_Position = right_Collision.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (moveLeft)
            {
                myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
            }
            else
            {
                myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
            }
        }
        
        CheckCollision();
    }

    void CheckCollision()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(left_Collision.position, Vector2.left, 0.1f, playerLayer);
        RaycastHit2D righttHit = Physics2D.Raycast(right_Collision.position, Vector2.right, 0.1f, playerLayer);
        
        Collider2D topHit = Physics2D.OverlapCircle(up_Collision.position, 0.2f, playerLayer);
       
        if(topHit != null)
        {
            if(topHit.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);
                    canMove = false;
                    myBody.velocity = new Vector2(0, 0);
                    anim.Play("Stunned");
                    stunned = true;
                }
            }
        }

        if (leftHit)
        {
            if (leftHit.collider.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    //apply damage to player
                }
                else
                {
                    myBody.velocity = new Vector2(15f, myBody.velocity.y);

                }
            }
        }

        if (righttHit)
        {
            if (righttHit.collider.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    //apply damage to player
                }
                else
                {
                    myBody.velocity = new Vector2(-15f, myBody.velocity.y);

                }
            }
            
        }


        // if we don't detect collision
        if (!Physics2D.Raycast(down_Collision.position, Vector2.down, 0.1f))
        {
            ChangeDirection();
        }
    }
    void ChangeDirection()
        {
            Vector2 tempScale = transform.localScale;
            moveLeft = !moveLeft;

            if (moveLeft)
            {
                tempScale.x = Mathf.Abs(tempScale.x);
                left_Collision.position = left_Collision_Position;
                right_Collision.position = right_Collision_Position;
            }
            else
            {
                tempScale.x =- Mathf.Abs(tempScale.x);
                left_Collision.position = right_Collision_Position;
                right_Collision.position = left_Collision_Position;
            }

            transform.localScale = tempScale;
        }
    

   


}//class
