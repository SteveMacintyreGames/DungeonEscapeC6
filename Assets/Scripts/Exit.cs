﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(GameManager.Instance.hasKeyToCastle)
            {
                UIManager.Instance.ExitWin();
            }
            else
            {
                UIManager.Instance.ExitNoKey();
            }
        }
        
    }
}
