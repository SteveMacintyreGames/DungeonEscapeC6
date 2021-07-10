using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    private int _selectedItem;
    private int _playerDiamonds;
    private int _cost;
    private string _itemDescription = "";
    [SerializeField] private GameObject _shopPanel;

      void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            Player player = other.GetComponent<Player>();
            _playerDiamonds = player.diamonds;
            if (player != null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
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



   public void SelectItem(int item)
   {
       //0 - sword
       //1 - boots
       //2 - key
       _selectedItem = item;

       switch(item)
       {
           case 0://flame sword
           UIManager.Instance.UpdateShopSelection(271);
           break;
           case 1://boots
           UIManager.Instance.UpdateShopSelection(135);
           break;
           case 2://key
           UIManager.Instance.UpdateShopSelection(0);
           break;
       }
   }

   public void PurchaseItem()
   {
        switch(_selectedItem)
           {
                case 0:
                _itemDescription = "Sword of Flame";
                _cost = 200;
                break;
                case 1:
                _itemDescription = "Boots of Flight";
                _cost = 400;
                break;
                case 2:
                _itemDescription = "Key to the Castle";
                _cost = 100;
                break;
           }

       if (_playerDiamonds >= _cost)
       { 
           Debug.Log(_itemDescription + " purchased.");
           _shopPanel.SetActive(false);
       }
       else
       {
           _shopPanel.SetActive(false);
       }
   }
}
