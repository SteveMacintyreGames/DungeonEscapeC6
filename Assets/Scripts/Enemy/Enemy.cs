using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _health;
    [SerializeField] protected int _gems;
    
    [SerializeField] protected Transform _pointA;
    [SerializeField] protected Transform _pointB;


    public virtual void Attack()
    {
        Debug.Log(this.gameObject.name + " : BASH AND SMASH!");
    }

    public abstract void Update();

}
