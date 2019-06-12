using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternPrefab : MonoBehaviour
{
    public Material green;
    public Material red;
    public Material blue;
    public Material yellow;
    public  GameObject[] randomColorObjs;


    public void ChangeColor()
    {
        if (randomColorObjs.Length == 0)
            return;

        foreach(GameObject obj in randomColorObjs)
        {
            int randomNo = Random.Range(1, 5);
            obj.GetComponent<SpriteRenderer>().material=CheckColor(randomNo);
            obj.tag = CheckColor(randomNo).name;

        }
       
    }

    Material CheckColor(int ind)
    {
        
        switch (ind)
        {
            case 1: return red;
            case 2: return green;
            case 3: return blue;
            case 4: return yellow;
            default: return null;
        }
    }
}
