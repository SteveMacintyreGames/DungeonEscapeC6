using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
  public int Health { get; set; }

  [SerializeField] GameObject acidEffect;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        //Sit still
        //base.Movement();
    }

    public void Damage()
    {
      health --;
      if (health <= 0)
      {
        anim.SetTrigger("Death");
        isDead = true;
        GetComponent<BoxCollider2D>().enabled = false;
        base.GemSplash();
      }
    }

    public void Attack()
    {
      //instantiate the acid effect.
      Instantiate (acidEffect, transform.position, Quaternion.identity);
      
    }
}
