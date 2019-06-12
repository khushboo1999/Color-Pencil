using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheckChange : MonoBehaviour
{
    public Sprite[] playerFaces;
    public ScoreBoard scoreBoard;
    public Transform endPos;
    
    public GameObject boosterEffect;
   // public GameObject correctColorEffect;
    
    public GameObject colorPencilEffect;
    public GameObject starEffect;
    public TrailRenderer trailRenderer;
  
    public Material green;
    public Material red;
    public Material blue;
    public Material yellow;
    public GameOver gameOver;
    public LayerMask layerMask;
    
    private string currentColor ;
    private Sprite CurrentSprite;
    private ParticleSystem[] particleEffects;
    private bool boosterEnabled=false;
    ObjectPooler objectPooler;
    

    private void Start()
    {
        currentColor = endPos.parent.gameObject.tag;
        int ind = PlayerPrefs.GetInt("CurrentSprite", 0);
      
        CurrentSprite =playerFaces[ind];
        
        this.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
        this.gameObject.AddComponent<PolygonCollider2D>();

        objectPooler = ObjectPooler.instance;

    }

    // Update is called once per frame
    void LateUpdate()
    {
     
        RaycastHit2D hit= Physics2D.Raycast(transform.position, endPos.position,0.4f,layerMask);
        
        
        if (hit.collider!=null)
        {
           
            Debug.DrawRay(transform.position, new Vector2(0, 1) * 2f, Color.yellow);

            if (hit.collider.tag != currentColor && !boosterEnabled && hit.collider.gameObject.layer == LayerMask.NameToLayer("checkColor"))
            {
               gameOver.EnableGameOverCanva();
            }

            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("colorChanger"))
            {
                


                if (boosterEnabled)
                {
                    boosterEnabled = false;
                    gameObject.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
                    boosterEffect.SetActive(false);

                }
                    
               
                trailRenderer.material = CheckColor(hit.collider.tag);
                this.gameObject.GetComponent<SpriteRenderer>().color= trailRenderer.material.color;
                particleEffects = objectPooler.SpawnFromPool("colorPencilEffect", transform.position, Quaternion.identity).GetComponentsInChildren<ParticleSystem>();
               
                foreach(ParticleSystem partEffect in particleEffects)
                {
                    
                    partEffect.Play();
                    ParticleSystem.MainModule newMain = partEffect.main;
                    newMain.startColor = new ParticleSystem.MinMaxGradient(trailRenderer.material.color);
                }
               
                
                float y = gameObject.transform.position.y;
                
                 //new Vector3(3.6f, y, 0f)
                //GameObject GO = Instantiate(colorPencilEffect, gameObject.transform.position, Quaternion.identity);
                // Destroy(GO, 1f);
                hit.collider.gameObject.SetActive(false);
            }

            


        }
        

    }

     void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "star")
        {
             GameObject go =objectPooler.SpawnFromPool("starEffect", collisionInfo.collider.transform.position, Quaternion.identity);
            go.GetComponent<ParticleSystem>().Play();

               // Instantiate(starEffect, collisionInfo.collider.transform.position, Quaternion.identity);
            // Destroy(GO, 0.3f);
            collisionInfo.gameObject.SetActive(false);
            scoreBoard.UpdateStarScore();

            
        }
        if (collisionInfo.collider.tag == "booster")
        {
            // GameObject GO = Instantiate(starEffect, collisionInfo.collider.transform.position, Quaternion.identity);
            //Destroy(GO, 0.3f);
            boosterEffect.SetActive(true);
           // this.gameObject.GetComponent<SpriteRenderer>().sprite = boosterSprite;
            collisionInfo.gameObject.SetActive(false);
            boosterEnabled = true;
           


        }
        else if ((collisionInfo.collider.tag == currentColor||boosterEnabled==true) && collisionInfo.collider.gameObject.layer == 9)
        {
            //Destroy(collisionInfo.gameObject);
            collisionInfo.gameObject.SetActive(false);
            ParticleSystem PS = objectPooler.SpawnFromPool("correctColorEffect", collisionInfo.collider.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            PS.Play();
            ParticleSystem.MainModule newMain =PS.main;
            newMain.startColor = new ParticleSystem.MinMaxGradient(CheckColor(collisionInfo.collider.tag).color);

            if(AudioManager.instance.Sound().isActiveAndEnabled)
            AudioManager.instance.Sound().Play();

            //GameObject GO = Instantiate(correctColorEffect, collisionInfo.collider.transform.position, Quaternion.identity);
            //Destroy(GO, 0.5f);

            scoreBoard.UpdateColorScore();

        }

        else if (collisionInfo.collider.tag != "star")
        {

            //GameObject GO = Instantiate(psgreen, collisionInfo.contacts[0].point + new Vector2(1.4f, 0.5f), Quaternion.identity);
            //Destroy(GO, 0.5f);
           
            gameOver.EnableGameOverCanva();
        }

    }
    Material CheckColor(string color)
    {
        currentColor = color;
        switch (color)
        {
            case "red": return red;
            case "green": return green;
            case "blue": return blue;
            case "yellow": return yellow;
            default: return null;
        }
    }
   




}
