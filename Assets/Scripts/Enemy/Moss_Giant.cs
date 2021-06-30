using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss_Giant : Enemy
{
   Transform _currentPosition;
   private float _step;
   Animator _anim;
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

   }

   private void Movement()
   {
      if (_currentPosition.position == _pointA.position)
      {
         _spriteRenderer.flipX = false;
      }
      else if(_currentPosition.position == _pointB.position)
      {
          _spriteRenderer.flipX = true;
      }

       if (transform.position.x >= _pointA.position.x)
      {
         _anim.SetTrigger("Idle");
         _currentPosition = _pointB;
      }

      if (transform.position.x <= _pointB.position.x)
      {         
         
         _anim.SetTrigger("Idle");
         _currentPosition = _pointA;

         
      }
      
      this.transform.position = Vector2.MoveTowards(transform.position, _currentPosition.position, _step);
   }


}
