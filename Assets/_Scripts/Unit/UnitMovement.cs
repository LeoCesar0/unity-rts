using UnityEngine;
using UnityEngine.AI;

public class UnitMovement
{
    private bool isSelected = false;
    private LayerMask ground;
    private NavMeshAgent navMeshAgent;
    private Camera myCam;
    private Unit unit;

    public UnitMovement(Unit unit, Camera cam)
    {
        navMeshAgent = unit.GetComponent<NavMeshAgent>();
        myCam = cam;
        this.unit = unit;

        HandleStart();
    }

    private bool started = false;
    public void HandleStart()
    {
        // myCam = Camera.main;
        ground = LayerMask.GetMask("Ground");
        // myAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = unit.defaultStats.speed;
        navMeshAgent.acceleration = 999;
        started = true;

        Debug.Log("UnitMovement");
    }

    // Update is called once per frame

    public void HandleMovement()
    {
        if (!started || unit.unitStats.isDead) return;

        if (UnitsSelection.Instance.unitsSelected.Contains(unit.gameObject))
        {
            isSelected = true;
            unit.isSelected = isSelected;
        }
        else
        {
            isSelected = false;
            unit.isSelected = isSelected;
        }

        if (isSelected && Input.GetMouseButtonDown(1))
        {
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
    }
}
