using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class ShopUtility 
{
    public string spriteName;
    public int cost;
    public Sprite playerFace;
    public GameObject panel;
    
    

    public void SetPrefs()
    {
        PlayerPrefs.SetInt(spriteName, 1);
    }

   
}
