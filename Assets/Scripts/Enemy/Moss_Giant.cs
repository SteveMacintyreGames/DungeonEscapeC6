using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss_Giant : Enemy, IDamagable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
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
            Destroy(this.gameObject);
        }
    }
}
