using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float righttCap;
    [SerializeField] private float jumplenght;
    [SerializeField] private float jumpheight;
    [SerializeField] private LayerMask foreground;

    private Collider2D coll;
    private bool facingLeft = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //transition from Jump to Fall
        if(anim.GetBool("Jumping")){
            if(rb.velocity.y < -.1){
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }

        //transition from Fall to Idle
        if(coll.IsTouchingLayers(foreground) && anim.GetBool("Falling")){
            anim.SetBool("Falling", false);
        }
        
    }

    private void Move()
    {
        if (facingLeft)
        {
            //test to see if we are on the left tab
            if (transform.position.x > leftCap)
            {
                //make sure sprite is facing right and if its not it goes to face right
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                //test to see if the frog is on the ground then jump
                if (coll.IsTouchingLayers(foreground))
                {
                    //Jump
                    rb.velocity = new Vector2(-jumplenght, jumpheight);
                    anim.SetBool("Jumping", true);

                }

            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < righttCap)
            {
                //make sure sprite is facing right and if its not it goes to face right
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                //test to see if the frog is on the ground then jump
                if (coll.IsTouchingLayers(foreground))
                {
                    //Jump
                    rb.velocity = new Vector2(jumplenght, jumpheight);
                    anim.SetBool("Jumping", true);

                }

            }
            else
            {
                facingLeft = true;
            }

        }
    }
   
}

