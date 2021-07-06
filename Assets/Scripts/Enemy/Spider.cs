using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
  public int Health { get; set; }

  [SerializeField] GameObject acidBooger;

    public override void Init()
    {
        base.Init();
    }

    public override void Movement()
    {
        //Sit still
        //base.Movement();
    }

    public void Damage()
    {

    }

    public void Attack()
    {
      //instantiate the acid effect.
      Instantiate (acidBooger, transform.position, Quaternion.identity);
      
    }
}
