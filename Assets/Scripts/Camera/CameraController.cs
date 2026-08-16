using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    //Camera Movement
    public float panSpeed = 30f;
    public float panBorder = 2f;

    private bool move = true;

    //Scrolling
    private float scrollSpeed = 2f;
    public float minY = 10f;
    public float maxY = 15f;

    public Slider zoomSlider;
    public Camera cams;

    void Start() {
        zoomSlider = GetComponent<Slider>();
       // zoomSlider.value = zoomSlider.maxValue;
    }

	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            move = !move;

       /* if (Input.GetKeyDown(KeyCode.W))
            move = !move;

        if (Input.GetKeyDown(KeyCode.S))
            move = !move;

        if (Input.GetKeyDown(KeyCode.D))
            move = !move;

        if (Input.GetKeyDown(KeyCode.A))
            move = !move;
        */
        if (!move)
            return;

        if (Input.GetKey("w"))// ||Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

            if (transform.position.z >= -6f) {
                Debug.Log("Stop Camera Forward!");
               // move = !move;
            }
        }

        if (Input.GetKey("s"))// || Input.mousePosition.y <= panBorder)
        {
            Debug.Log("Move Backward");
            
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

            if (transform.position.z <= -24f) {
                Debug.Log("Stop Camera Backward!");
               // move = !move;
            }
        }

        if (Input.GetKey("d"))//|| Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

            if (transform.position.x >= 4f) {
                Debug.Log("Stop Camera Right!");
               // move = !move;
            }
        }

        if (Input.GetKey("a"))// || Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

            if (transform.position.x <= -6f) {
                Debug.Log("Stop Camera Left!");
               // move = !move;
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        //cams.fieldOfView = zoomSlider.value;
    }

}
