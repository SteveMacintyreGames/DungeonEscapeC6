using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is null");
            }
            return _instance;
        }
    }

    

    void Awake()
    {
        _instance = this;
    }


    public Text playerGemCountText;
    public Text gemCountText;
    public Image selectionImg;

    public Image[] lifeUnit;



    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "Gems: " + gemCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        Vector2 currentPos = selectionImg.rectTransform.anchoredPosition;

        selectionImg.rectTransform.anchoredPosition = new Vector2(currentPos.x ,yPos);
    }

    public void UpdateGemCount(int gemCount)
    {
        gemCountText.text = gemCount.ToString();
    }

    public void UpdateHealth(int health)
    {
        for(int x = 0; x <= health; x++)
        {
            if (x == health)
            {
                lifeUnit[x].enabled = false;
            }
        }
    }
  
}
