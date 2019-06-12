using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine;

public class shop : MonoBehaviour
{
    public ShopUtility[] shopUtilities;
    public TextMeshProUGUI starScore;
    
    public ParticleSystem moneyReducedEffect;
    public GameObject ItemSelected;
    public GameObject confirmation;
    public GameObject notEnoughMoney;

    private int currentInd;
    
    
    private void Start()
    {
        starScore.text = PlayerPrefs.GetInt("StarScore",0).ToString();
        Debug.Log("test");
        foreach(ShopUtility items in shopUtilities)
        {
            if(PlayerPrefs.GetInt(items.spriteName, 0)!= 0)
            {
                items.panel.SetActive(false);
            }
        }
       
    }
    public void SetImage(int ind)
    {
        Buy(ind);
    }

     void Buy(int ind)
    {
        currentInd = ind;
        if (PlayerPrefs.GetInt(shopUtilities[ind].spriteName,0) == 0)
        {
            if (PlayerPrefs.GetInt("StarScore",0)>= shopUtilities[ind].cost)
            {
                confirmation.SetActive(true);
                
            }
            else
            {
                notEnoughMoney.SetActive(true);
                StartCoroutine(wait(notEnoughMoney));
            }


        }

        else
        {
            
            ItemSelected.SetActive(true);
            PlayerPrefs.SetInt("CurrentSprite", ind+1);
            StartCoroutine(wait(ItemSelected));
            

        }

    }

    IEnumerator wait(GameObject toDisable)
    {
        yield return new WaitForSecondsRealtime(1.2f);
        toDisable.SetActive(false);
    }

    public void confirmBuy(string opt)
    {
        
        if (opt == "yes")
        {
            Debug.Log("bought");
            moneyReducedEffect.Play();
            PlayerPrefs.SetInt(shopUtilities[currentInd].spriteName, 1);
            PlayerPrefs.SetInt("StarScore", PlayerPrefs.GetInt("StarScore", 0) - shopUtilities[currentInd].cost);
            starScore.text = PlayerPrefs.GetInt("StarScore", 0).ToString();
            PlayerPrefs.SetInt("CurrentSprite", currentInd+1);
            shopUtilities[currentInd].panel.SetActive(false);


        }
        confirmation.SetActive(false);

    }
        

   


    
}
