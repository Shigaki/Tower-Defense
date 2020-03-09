using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //private Camera cam;
    //private float targetZoom;
    //private float minY = 80f;
    //private float maxY = 0f;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    //[SerializeField] public float zoomSpeed = 10f;

    void Start() {
        //cam = Camera.main;
        //targetZoom = cam.orthographicSize;
    }

    void Update() {

        if ((Input.GetKey("w")) || (Input.mousePosition.y >= Screen.height - panBorderThickness)) {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey("s")) || (Input.mousePosition.y <= panBorderThickness)) {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey("d")) || (Input.mousePosition.x >= Screen.width - panBorderThickness)) {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey("a")) || (Input.mousePosition.x <= panBorderThickness)) {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scroll);
        //targetZoom -= scroll * 3f;
        //targetZoom = Mathf.Clamp(targetZoom, minY, maxY);

        //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);

    }
}
