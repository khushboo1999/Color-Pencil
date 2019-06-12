using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    Vector3 vel;
    
    private void Start()
    {
        offset.z = transform.position.z - player.transform.position.z;
        offset.x = 0f;
        offset.y = 0f;

    }

    private void OnGUI()
    {
        //float horizRatio = Screen.width / 1024f;
        //float vertRatio = Screen.height / 768;
        //GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(horizRatio, vertRatio, 1f));

        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = 600f / currentAspect / 200f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset.y =  player.transform.position.y+1f;
        
        transform.position = Vector3.SmoothDamp(transform.position, offset,ref vel,0.2f);//new Vector2(offset.x, player.transform.position.y - offset.y);
    }
}
