using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
  public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
       
    }

    public override void Update()
    {
        base.Update(); 

    }

    public override void Movement()
    {
        base.Movement();
        Vector2 direction = player.transform.position - this.transform.position;
        if (direction.x > 0 && anim.GetBool("InCombat")==true )
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat")==true )
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Damage()
    {        
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
        Health --;
        isHit = true;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }



    
}
