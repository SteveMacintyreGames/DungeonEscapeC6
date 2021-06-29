using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _anim;
    Animator _swordArc;

    void Start()
    {
       _anim = GetComponentInChildren<Animator>();
       _swordArc = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(int move)
    {
        _anim.SetInteger("Move", Mathf.Abs(move));
    }

    public void Jump(bool isJumping)
    {
        _anim.SetBool("isJumping",isJumping);     
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordArc.SetTrigger("SwordArc");
    }

}
