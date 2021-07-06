using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Animation_Event : MonoBehaviour
{
    public void Fire()
    {
        this.GetComponentInParent<Spider>().Attack();
    }
}
