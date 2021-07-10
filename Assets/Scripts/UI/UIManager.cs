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
    public Image selectionImg;


    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "Gems: " + gemCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        Vector2 currentPos = selectionImg.rectTransform.anchoredPosition;

        selectionImg.rectTransform.anchoredPosition = new Vector2(currentPos.x ,yPos);
    }
  
}
