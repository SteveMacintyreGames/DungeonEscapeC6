using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private int _amount = 1;

  void OnTriggerEnter2D(Collider2D other)
  {
      if(other.tag == "Player")
      {
          other.GetComponent<Player>().AddDiamonds(_amount);
          this.gameObject.SetActive(false);
      }
      
  }
}
