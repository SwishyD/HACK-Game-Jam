using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector3 pos;
    float edgeSize = 50f;
    float speed = 20f;

    public Vector2 panLimit;
    
    void Start () {
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.mousePosition.x > Screen.width - edgeSize)
            {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.mousePosition.x < edgeSize)
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.mousePosition.y < edgeSize)
        {
            pos.y -= speed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
        transform.position = pos;
    }
}
