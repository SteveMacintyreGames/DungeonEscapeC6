﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{   
    void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable hit = other.GetComponent<IDamagable>();
        if(hit != null)
        {
            hit.Damage();
        }
    }
}
