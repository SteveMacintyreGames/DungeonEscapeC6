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
    [SerializeField] private bool _grounded = false;
    private bool _facingRight = true;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        CheckMovement();
        CheckAttack();
    }
    private void CheckMovement()
    {
        _grounded = IsGrounded();
        _horizontalInput = (int)Input.GetAxisRaw("Horizontal");
        FlipCharacter();   
        _anim.Move(_horizontalInput);
        
        if (Input.GetButtonDown("Jump") && _grounded)
        {
            _anim.Jump(true);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }

        _rigidbody2D.velocity = new Vector2(_horizontalInput * _speed, _rigidbody2D.velocity.y);
             
    }

    private void CheckAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _grounded)
        {
            _anim.Attack();
        }
    }


     bool IsGrounded()
    {
        var _hit = Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
       
        if (_hit.collider !=null)
            { 
                _anim.Jump(false);       
                return true;
                
            }
            return false;
    }

    void FlipCharacter()
    { 
        if((_horizontalInput < 0 && _facingRight) || (_horizontalInput > 0 && !_facingRight))
        {
            _facingRight = !_facingRight;
            transform.Rotate(new Vector3(0,180,0));
        }        
    }

}
