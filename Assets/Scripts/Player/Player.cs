using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamagable
{
    Rigidbody2D _rigidbody2D;
     private int _horizontalInput;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 5f;
    private float _raycastDistance = 1.2f;
    PlayerAnimation _anim;
    SpriteRenderer _spriteRenderer;
    [SerializeField] private bool _grounded = false;
    private bool _facingRight = true;

    public int Health { get; set; }

    public int diamonds = 0;
    private bool _isDead = false;
   

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Health = 4;
    

    }
    void Update()
    {
        if (!_isDead)
        {
            CheckMovement();
            CheckAttack();
        }
        
        
    }
    private void CheckMovement()
    {
        _grounded = IsGrounded();
        //_horizontalInput = ((int)Input.GetAxisRaw("Horizontal"));
        _horizontalInput = ((int)CrossPlatformInputManager.GetAxisRaw("Horizontal"));
        FlipCharacter();   
        _anim.Move(_horizontalInput);
        
        if ((Input.GetButtonDown("Jump") || CrossPlatformInputManager.GetButtonDown("Jump")) && _grounded)
        {
            _anim.Jump(true);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }

        _rigidbody2D.velocity = new Vector2(_horizontalInput * _speed, _rigidbody2D.velocity.y);
             
    }

    private void CheckAttack()
    {
        if ((Input.GetButtonDown("Fire1") || CrossPlatformInputManager.GetButtonDown("Fire1")) && _grounded)
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

    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }
        Health--;
        UIManager.Instance.UpdateHealth(Health);
        if (Health == 0)
        {
            _anim.Death();
            _isDead = true;
            
        }
    }

    public void AddDiamonds(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }

}
