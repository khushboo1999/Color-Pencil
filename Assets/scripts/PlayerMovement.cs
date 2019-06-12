using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D playerRb;
    public float smoothTime;
    public float xBound;

    private void Start()
    {
       xBound= (Camera.main.orthographicSize / 2)+0.2f;
        
    }

    Vector2 vel;

    // Update is called once per frame
    void FixedUpdate()
    {

        playerRb.velocity = new Vector2(0f, playerSpeed);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 targetPos = new Vector3(pos.x, transform.position.y, transform.position.z);
                targetPos.x = Mathf.Clamp(targetPos.x, -xBound, xBound);
                transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref vel, smoothTime);
            
        }


    }
            

  
}
