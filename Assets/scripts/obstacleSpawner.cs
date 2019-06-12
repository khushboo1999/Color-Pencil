using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    
 
    public float spawnGap;
    //public float spawnTime;
    public GameObject player;


    static float yDistance=0;

    public int spawnedObjectsCount = 5;

    //private float time;
    private ObjectPooler objectPooler;

    private void Start()
    {
        Time.timeScale = 1f;
        yDistance = 1f;
        
        objectPooler = ObjectPooler.instance;
        StartCoroutine(Wait());
       // time = spawnTime;
    }

    public void LateUpdate()
    {
        //if (time <= 0f)
        {
            if (player.transform.position.y + 10f > yDistance)
            {
                Spawn();
                if (yDistance % 25f == 0)
                {
                    player.GetComponent<PlayerMovement>().playerSpeed += 0.5f;
                }

            }
            else return;
            
        }
       // else time -= Time.fixedDeltaTime;

    }


    public void Spawn()
    {
       
        
            SpawnPattern();
            SpawnPattern();
            SpawnColorChanger();
            SpawnPattern();
            SpawnPattern();
            SpawnColorChanger();
        // StartCoroutine(Wait());

    }


    void SpawnPattern()
    {
        yDistance += spawnGap;
        // 
        objectPooler.CSpawnPatternFromPool("pattern" + Random.Range(1, objectPooler.obstacleCount), new Vector2(0f, yDistance), Quaternion.identity);
        //GO.Add(Instantiate(patterns[Random.Range(0, patterns.Length)], new Vector2(0f, yGap),Quaternion.identity));
       
        
    }

    void SpawnColorChanger()
    {

        //int randomNo = Random.Range(0, 4);
       // Debug.Log("colorChanger" + randomNo);
        
     objectPooler.SpawnFromPool("colorChanger" + Random.Range(0, 4), new Vector2(3.5f, yDistance + 5f), Quaternion.Euler(0f, 0f, -18f));
        yDistance += 3f;
        //GO.Add(Instantiate(colorChanger[Random.Range(0, colorChanger.Length)], new Vector2(3.5f, yGap+5f), Quaternion.Euler(0f,0f,-18f)));
   
        
        if (Random.Range(1,20)%5==0)
        {
            GameObject booster=objectPooler.SpawnFromPool("booster", new Vector2(Random.Range(-2.5f, 2.5f), yDistance + 3f), Quaternion.identity);
            booster.GetComponent<ParticleSystem>().Play();
            


        }


    }

    IEnumerator Wait()
    {
       
        yield return new WaitForSecondsRealtime(1f);
        Spawn();
        
        
    }

}
