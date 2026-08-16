using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipe : MonoBehaviour {

    private Touch initTouch = new Touch();
    public Camera cam;

    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 origRot;

    public float rotSpeed = 0.5f;
    public float dir = -1f;

	void Start () {
        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
	}
	
	void FixedUpdate () {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                initTouch = t;
            }

            else if (t.phase == TouchPhase.Moved)
            {
                float deltaX = initTouch.position.x - t.position.x;
                float deltaY = initTouch.position.y - t.position.y;

                rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                rotY += deltaY * Time.deltaTime * rotSpeed * dir;
                rotX = Mathf.Clamp(rotX, -45f, 45f);

                cam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
            }

            else if (t.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
        
	}
}
