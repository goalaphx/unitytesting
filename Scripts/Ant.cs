using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Enemy
{
   [SerializeField] public float moveSpeed ; // Speed of movement
   [SerializeField] public float leftBound ; // Left bound of movement
   [SerializeField] public float rightBound ; // Right bound of movement

    private int direction = 1; // 1 for moving right, -1 for moving left
    private SpriteRenderer spriteRenderer;
    protected override void Start(){
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move the ant
        transform.Translate(Vector3.right * moveSpeed * direction * Time.deltaTime);

        // Check if ant reaches the left or right bound
        if (transform.position.x <= leftBound)
        {
            direction = 1; // Change direction to move right
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x >= rightBound)
        {
            direction = -1; // Change direction to move left
            spriteRenderer.flipX = false;
        }
    }
}

