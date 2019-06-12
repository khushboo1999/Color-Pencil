using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public static int BestColorScore;
    public TextMeshProUGUI colorS;
    public TextMeshProUGUI starS;
    
    
   

    // Start is called before the first frame update
    void Start()
    {

        if (gameManager.rewardVidPlayed)
        {
            colorS.text = gameManager.colorScore.ToString();
            playerStats.instance.colorScore = gameManager.colorScore;
            gameManager.rewardVidPlayed = false;
        }
            
        else
            colorS.text = "0";
        starS.text = PlayerPrefs.GetInt("StarScore",0).ToString();
    }


    public void UpdateStarScore()
    {
        starS.text = playerStats.instance.SetStarScore().ToString();
    }

    public void UpdateColorScore()
    {
       
        colorS.text = playerStats.instance.SetColorScore().ToString();
    }
}
