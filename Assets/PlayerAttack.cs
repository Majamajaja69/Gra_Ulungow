using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    private Animator anim;
    public  float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatisEnemies;
 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <=0)
        {
            if(Input.GetKey(KeyCode.F))
            {

                anim.SetTrigger("atack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatisEnemies );
                for (int i = 0; i < enemiesToDamage.Length;i++)
                {
                   
                    Destroy(enemiesToDamage[i].gameObject);
                }

            }
            timeBtwAttack = startTimeBtwAttack;
            
        }
        else
        {
            timeBtwAttack -=Time.deltaTime;
        }

    

        
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    
}
