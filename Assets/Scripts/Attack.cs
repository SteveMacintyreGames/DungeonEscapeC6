using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{   
    private bool _canHit = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable hit = other.GetComponent<IDamagable>();
        if(hit != null && _canHit)
        {
            hit.Damage();
            _canHit = false;
            StartCoroutine(ResetHit());
        }
    }

    IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(.5f);
        _canHit=true;
    }
}
