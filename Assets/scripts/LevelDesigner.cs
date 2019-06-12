using System.Collections;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
   // public GameObject[] patternsPrefabs;
    //public GameObject[] colorChangerPrefabs;
   
    public GameObject end;
    public GameObject lastLevelEnd;
   
   
    public LevelUtility[] Levels;

    private string[] colorChanger;
    private string[] patterns;
    private LevelUtility Level;

    private static float yGap;
    public static int ind=1;
    private int j;
    public static LevelDesigner instance;
    private ObjectPooler objectPooler;


    private void Awake()
    {
       
        Time.timeScale = 1f;
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this);
        }

        else Destroy(this);
       

        return;
        
    }

    void Start()
    {
        StartCoroutine(Wait());
        
        objectPooler = ObjectPooler.instance;        
        yGap = 0;
    }

    public IEnumerator Wait()
    {
        
        yield return new WaitForSecondsRealtime(1f);
        DesignLevel(ind);
    }

    //public int NextLevel()
    //{
       
    //    return ++ind;
    //}
   
    public void DesignLevel(int index)
    {
        yGap = 1f;
        ind = index;
        
        if (ind > 0)
        {
            
            Level = Levels[ind - 1];
            Split(Level.pencilSequence, Level.patternSequence);
        }
        
        
       
    }
    void Split(string colorChangerData, string PatternData)
    {
        colorChanger = colorChangerData.Split(',');
        
        patterns = PatternData.Split(',');
       
        SpawnPattern();
    }



    private void SpawnPattern()
    {
        j = 0;

        
        for (int i =0;i<patterns.Length;i++)
        {
           
            if (i %2 == 0 &&i!=0)
            {
                spawnPencil();
                
            }
            else
            {
                yGap += Level.spawnGap;
            }

            int index = int.Parse(patterns[i]);
            index++;
            
            GameObject pattern = objectPooler.SpawnFromPool("pattern" + index, new Vector2(0f, yGap), Quaternion.identity);

            if (pattern.GetComponent<Animator>() != null && Level.removeAnimations)
            {
                
                pattern.GetComponent<Animator>().enabled = false;

            }
                



            //Instantiate(patternsPrefabs[int.Parse(patterns[i])], new Vector2(0f, yGap), Quaternion.identity);

            
        }

        yGap += 7f;
        if (ind == Levels.Length)
           
        lastLevelEnd.transform.position = new Vector2(0f, yGap);
        else end.transform.position = new Vector2(0f, yGap);





    }

    void spawnPencil()
    {
        
        yGap += 5f;
        objectPooler.SpawnFromPool("colorChanger" + colorChanger[j++], new Vector2(3.5f, yGap), Quaternion.Euler(0f, 0f, -18f));
        //Instantiate(colorChangerPrefabs[int.Parse(colorChanger[j++])], new Vector2(3.5f, yGap), Quaternion.Euler(0f, 0f, -18f));
        
        yGap += 1f;
        if(Level.applyBoosters&&j%3==0&&j>0)
        {
            objectPooler.SpawnFromPool("booster", new Vector2(Random.Range(-2.5f, 2.5f), yGap), Quaternion.identity);
            //Instantiate(booster, new Vector2(Random.Range(-2.5f,2.5f), yGap), Quaternion.identity);
        }
        yGap += 4f;

    }


    
    }
    

    



