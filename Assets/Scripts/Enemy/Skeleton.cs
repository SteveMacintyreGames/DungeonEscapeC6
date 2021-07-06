﻿using System.Collections;
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
    }

    public void Damage()
    {        
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
        Health --;
        isHit = true;
        if (Health <= 0)
        {
            anim.SetTrigger("Death");
            isDead = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }



    
}
