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
                Debug.LogError("UI manager is null");
            }

            return _instance;
        }
    }

    public Text playerGemsCountText;
    public Image selectionImg;
    public Text gemsCountText;
    public Image[] healthBars;

    private void Awake()
    {
        _instance = this;
    }

    public void openShop(int gemsCount)
    {
        playerGemsCountText.text = "" + gemsCount + "G";
    }

    public void UpdateSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }
     
    public void UpdateGemsCount(int count)
    {
        gemsCountText.text = ""+count;
    }
  
    public void UpdateLives(int livesRemaining)
    {
        for(int i = 0; i <= livesRemaining; i++)
        {
            //do nothing till we hit the max
            if(i == livesRemaining)
            {
                healthBars[i].enabled = false;
            }
        }

    }
}
