using UnityEngine.UI;
using UnityEngine;

public class playerStats : MonoBehaviour
{
   
    [HideInInspector]
    public int starScore;
    [HideInInspector]
    public int colorScore;
    [HideInInspector]
    public int BestcolorScore;

    public static playerStats instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    public void Start()
    {
       starScore= PlayerPrefs.GetInt("StartScore", 0);
        BestcolorScore=PlayerPrefs.GetInt("BestColorScore", 0);
      //  colorScore = 0;
    }

    public int SetStarScore()
    {
        starScore = PlayerPrefs.GetInt("StarScore", 0)+ 1;
        
        PlayerPrefs.SetInt("StarScore", starScore);
        return PlayerPrefs.GetInt("StarScore",0);
    }

    public int SetColorScore()
    {
        colorScore += 5;
        if (colorScore > BestcolorScore)
        {
            PlayerPrefs.SetInt("BestColorScore", colorScore);
        }
        return colorScore;
    }

  

}
