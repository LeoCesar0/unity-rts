using UnityEngine;
using UnityEngine.AI;

public class UnitMovement
{
    public NavMeshAgent navMeshAgent;
    private Unit unit;

    public UnitMovement(Unit unit)
    {
        navMeshAgent = unit.GetComponent<NavMeshAgent>();
        this.unit = unit;

        HandleStart();
    }

    private bool started = false;
    public void HandleStart()
    {
        navMeshAgent.speed = unit.defaultStats.speed;
        navMeshAgent.acceleration = 999;
        started = true;

        Debug.Log("UnitMovement");
    }


    public void MoveTo(Vector3 point)
    {
        navMeshAgent.SetDestination(point);
    }


}
