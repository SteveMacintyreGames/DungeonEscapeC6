using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;

      void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<player>();
            if (player != null)
            {
                UIManager.Instance.OpenShop(player._diamonds;)
            }
            _shopPanel.SetActive(true);
        }
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _shopPanel.SetActive(false);
        }
    }

   
}
