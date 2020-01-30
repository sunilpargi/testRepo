using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentSelectedItem = 0;
    public int currentItemCost;
    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
             player = other.GetComponent<Player>();

            if(player != null)
            {
                UIManager.Instance.openShop(player.diamond);
            }

            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }

    }

    public void selection(int item)

    {
        Debug.Log("item");
        switch(item)
        {
            case 0: //flame sword
                UIManager.Instance.UpdateSelection(86);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1: //Boots of flight
                UIManager.Instance.UpdateSelection(-7);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2: //key to castle
                UIManager.Instance.UpdateSelection(-108);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if(player.diamond >= currentItemCost)
        {
            if(currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            player.diamond -= currentItemCost;
            Debug.Log("purchsed item:" + currentSelectedItem);
            Debug.Log("remaining gems" + currentItemCost);
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("You dont have enough gems");
            shopPanel.SetActive(false);
        }
    }

}
