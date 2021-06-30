using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss_Giant : Enemy
{
   Transform _currentPosition;
   private float _step;
   Animator _anim;
   private bool _facingRight = true;
   private SpriteRenderer _spriteRenderer;


   void Start()
   {
      _anim = GetComponentInChildren<Animator>();
      _speed = 2f;
      _currentPosition = _pointA;
      _step = _speed * Time.deltaTime;
      _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

      
   }

    public override void Update()
   {
     if(_anim.GetCurrentAnimatorStateInfo(0).IsName("Moss_Giant_Idle"))
      {
         return;
      } 
     Movement();
     FacingCheck();
   }

   private void Movement()
   {
       if (transform.position.x >= _pointA.position.x)
      {
         _anim.SetTrigger("Idle");
         _currentPosition = _pointB;
         _facingRight = false;
      }

      if (transform.position.x <= _pointB.position.x)
      {         
         
         _anim.SetTrigger("Idle");
         _currentPosition = _pointA;
         _facingRight = true;
         
      }
      
      this.transform.position = Vector2.MoveTowards(transform.position, _currentPosition.position, _step);
   }

   private void FacingCheck()
   {
      if(_facingRight)
      {
         _spriteRenderer.flipX = false;
      }
      else
      {
        _spriteRenderer.flipX = true;  
      }
   }
}
