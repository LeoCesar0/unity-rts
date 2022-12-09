using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 15f;

    private float maxZoomheight = 30f;
    private float minZoomHeight = 10f;

    private float panBorderThichkness = 20f;
    private float mapLimitX = 100f;
    private float mapLimitZ = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float scrollAxis = Input.GetAxisRaw("Mouse ScrollWheel");

        if (Input.mousePosition.y >= (Screen.height - panBorderThichkness)) {
            verticalAxis = 1;
        }

        if (Input.mousePosition.y <= panBorderThichkness)
        {
            verticalAxis = -1;
        }

        if (Input.mousePosition.x >= (Screen.width - panBorderThichkness))
        {
            horizontalAxis = 1;
        }

        if (Input.mousePosition.x <= panBorderThichkness)
        {
            horizontalAxis = -1;
        }


        pos.z += Mathf.Clamp(verticalAxis * panSpeed * Time.deltaTime,-mapLimitZ, mapLimitZ);
        pos.x += Mathf.Clamp(horizontalAxis * panSpeed * Time.deltaTime,-mapLimitX, mapLimitX);


        float zoomPosition = pos.y + (scrollAxis * 100 * -1 * panSpeed * Time.deltaTime);
        pos.y = Mathf.Clamp(zoomPosition, minZoomHeight, maxZoomheight);

        transform.position = pos;
    }
}
