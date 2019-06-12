using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelUtility 
{
    public string levelNo;
    public string patternSequence;
    public string pencilSequence;
    public float spawnGap;
    public bool applyBoosters=false;
    public bool removeAnimations=true;

    //public GameObject[] patternsPrefabs;
    //public GameObject[] colorChanger;
    //  public float spawnGap;


    //private int Pindex;
    //private int Cindex;
    //private int ind;

    //private void Start()
    //{
        
    //    yGap = 0f;
    //    Debug.Log("test");
    //    Spawn();
    //}

    

    //public void Spawn()
    //{
    //    for(int i=0;i<4 ; i++)
    //    {
    //        SpawnPattern();
    //        SpawnPattern();
    //        SpawnColorChanger();
    //        SpawnPattern();
    //        SpawnPattern();
    //        StartCoroutine(Wait());
    //    }
    //}


    //void SpawnPattern()
    //{
    //    yGap += spawnGap;
    //    Pindex = Random.Range(0, patterns.Length);
    //   GameObject GO= Instantiate(patterns[Pindex], new Vector2(0f, yGap),Quaternion.identity);
    //   // Destroy(GO, 10f);
    //}

    //void SpawnColorChanger()
    //{
    //    yGap += 3f;
        
    //        do
    //    {
    //        ind = Cindex;
    //        Cindex = Random.Range(0, colorChanger.Length);
           
    //    } while( ind!=Cindex);
       
        
    //    GameObject GO= Instantiate(colorChanger[Cindex], new Vector2(3.5f, yGap ), Quaternion.identity);
    //   // Destroy(GO, 10f);
    //}

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(spawnTime);
    //}
}
