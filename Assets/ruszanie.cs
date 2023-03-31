using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruszanie : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;


    private float dirX = 0;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float maxVelocity = 3f;
   

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
     {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x , jumpForce);
        }

     

    
        UpdateAnimationUpdate();
    
    
     }
      private void UpdateAnimationUpdate()
     {
        if (dirX > 0f)
        {
            anim.SetBool("chodzenie", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("chodzenie", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("chodzenie", false);
        }
     }
}