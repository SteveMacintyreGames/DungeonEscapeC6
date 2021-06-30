using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
   void Start()
   {
       Attack();
   }

   public override void Attack()
   {
       base.Attack();
       Debug.Log("I NEED MILK!");
   }

    public override void Update()   
    {
       
    }
}
