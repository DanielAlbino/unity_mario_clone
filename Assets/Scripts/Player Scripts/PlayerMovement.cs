using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;

    private Rigidbody2D myBody;
    private Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        float h = Input.GetAxis("Horizontal");
        if(h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        } else if(h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        } else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }
    }

}// class
