using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grasshopper : Enemy
{
    [SerializeField] private float jumpheight;
    [SerializeField] private LayerMask foreground;

    private Collider2D coll;
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        
    }
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
    void GrassJump(){
    if (coll.IsTouchingLayers(foreground))
                {
                    //Jump
                    rb.velocity = new Vector2(rb.velocity.x, jumpheight);
                    anim.SetBool("Jumping", true);

                }
    }
}
