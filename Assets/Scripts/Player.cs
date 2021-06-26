using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
     private int _horizontalInput;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 5f;
    private float _raycastDistance = 1.1f;
    PlayerAnimation _anim;
    SpriteRenderer _spriteRenderer;
 
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        CheckMovement();
        FlipCharacter();        
    }
    private void CheckMovement()
    {
        _horizontalInput = (int)Input.GetAxisRaw("Horizontal");   
        _anim.Move(_horizontalInput);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }

        _rigidbody2D.velocity = new Vector2(_horizontalInput * _speed, _rigidbody2D.velocity.y);
             
    }
     bool IsGrounded()
    {
        var _hit = Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance, 1 << 8);
       
        if (_hit.collider !=null)
            {        
                return true;
            }
            return false;
    }

    void FlipCharacter()
    {
        if(_horizontalInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        if (_horizontalInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

}
