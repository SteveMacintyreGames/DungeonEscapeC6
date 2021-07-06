using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    //move right at 3meters per second
    //detect player and deal damage (Idamagable interface);
    //destroy after 5 seconds.


    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToDeath = 5f;

    void Start()
    {
        Destroy(this.gameObject, _timeToDeath);
    }

    void Update()
    {
        transform.Translate (Vector3.right *_speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            IDamagable hit = other.GetComponent<IDamagable>();
            if(hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }

}
