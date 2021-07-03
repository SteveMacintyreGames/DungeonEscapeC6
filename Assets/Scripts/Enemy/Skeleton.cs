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

    public void Damage()
    {
        Debug.Log("Skeletons damaged!");
        Health --;

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
