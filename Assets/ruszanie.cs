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
    private bool _isJumping;
    private int _jumpCount;

    [SerializeField] private LayerMask layer;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        CheckGround();
    }

    // Update is called once per frame
    private void FixedUpdate()
     {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); 
        UpdateAnimationUpdate();    
     }

      private void UpdateAnimationUpdate()
     {
       //Debug.Log(rb.velocity);
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

        if (rb.velocity.y > 0.1f)
        {
            anim.SetBool("skok", true);
        }
        else
        {
            anim.SetBool("skok", false);
        }

        if (rb.velocity.y< 0f)
        {
            anim.SetBool("spadanie", true);
        }
        else
        {
            anim.SetBool("spadanie", false);
        }
    }    

    private void Jump(){
        if(_jumpCount < 0.1f){
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        _jumpCount++;
        }        
    }

    private void CheckGround(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, layer);
        if(hit.collider != null){
            Debug.Log("hit!");
            _jumpCount = 0;
        }
    }
}