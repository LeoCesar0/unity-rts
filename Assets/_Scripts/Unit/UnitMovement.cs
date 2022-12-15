using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    private bool isSelected = false;
    private LayerMask ground;
    NavMeshAgent myAgent;
    Camera myCam;

    private bool started = false;
    public void HandleStart(float speed)
    {
        myCam = Camera.main;
        ground = LayerMask.GetMask("Ground");
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.speed = speed;
        myAgent.acceleration = 999;
        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started) return;

        if (isSelected && Input.GetMouseButtonDown(1))
        {
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
            }
        }

    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
    }


}
