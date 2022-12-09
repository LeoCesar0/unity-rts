using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsClick : MonoBehaviour
{

    public LayerMask clickable;
    public LayerMask ground;
    Camera myCam;


    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        //clickable = LayerMask.NameToLayer("Clickable");
       // ground = LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                GameObject hitObject = hit.collider.gameObject;
                // SHIFT SELECT
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    UnitsSelection.Instance.ShiftClickSelect(hitObject);
                }
                else
                {
                    // SELECT UNIT
                    UnitsSelection.Instance.ClickSelect(hitObject);
                }

            }
            else
            {
                //DESELECT ALL IF NOT HOLDING SHIFT

                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitsSelection.Instance.DeselectAll();
                }
                
            }

        }
        
    }
}
