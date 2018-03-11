using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float speed = 10.0f;
    public float scrollSpeed = 10.0f;

    private float border = 50.0f;

    private float minY = 10.0f;
    private float maxY = 60.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {   
        
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y > Screen.height - border)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y < border)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
		
        if (Input.GetKey("a") || Input.mousePosition.x < border)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x > Screen.width - border)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= 100 * scroll * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;


    }
}
