using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : Enemy, IDamagable
{
  public int Health{ get; set;}
  void Start()
  {
      Health = base.health;

  }

  public override void Movement()
  {
      //don't move
  }

  public void Damage()
  {
      Health --;

      if (Health <= 0)
      {
          base.GemSplash();          
          this.gameObject.SetActive(false);
      }          
          
  }

}
