using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int health;
    [SerializeField] protected int gems;
    
    [SerializeField] protected Transform pointA;
    [SerializeField] protected Transform pointB;

    protected Transform currentTarget;
    protected Animator anim;

    protected SpriteRenderer spriteRenderer;
    protected float step;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        step = speed * Time.deltaTime;
        currentTarget = pointA;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
          if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
      {
         return;
      } 
      Movement();
    }


public virtual void Movement()
{
        if (currentTarget.position == pointA.position)
        {
            spriteRenderer.flipX = false;
        }
        else if(currentTarget.position == pointB.position)
        {
            spriteRenderer.flipX = true;
        }


        if(transform.position.x >= pointA.position.x)
        {
            anim.SetTrigger("Idle");
            currentTarget = pointB;
        }
        else if (transform.position.x <= pointB.position.x)
        {
            anim.SetTrigger("Idle");
            currentTarget = pointA;
        }

        this.transform.position =
        Vector2.MoveTowards(transform.position, currentTarget.position, step);
    }

}
