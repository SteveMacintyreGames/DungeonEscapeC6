using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _anim;

    void Start()
    {
       _anim = GetComponentInChildren<Animator>(); 
    }


    void Update()
    {
        
    }

    public void Move(int move)
    {
        _anim.SetInteger("Move", Mathf.Abs(move));
    }
}
