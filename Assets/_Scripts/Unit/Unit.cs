using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour
{

    public Types.PlayerOwner playerOwner;
    public Types.Team team;
    protected UnitMovement unitMovement;
    protected UnitAttack unitAttack;
    protected UnitStats unitStats;
    public bool isSelected = false;
    protected StatsSO stats;
    protected Renderer _renderer;
    protected GameObject renderGO;

    protected virtual void Start()
    {
        if (stats == null)
        {
            Debug.LogError("StatsSO is not assigned for " + gameObject.name);
            return;
        }

        if (!gameObject.GetComponent<NavMeshAgent>())
        {
            gameObject.AddComponent<NavMeshAgent>();

        }

        SetupComponents();

        SetupRender();

        UnitsSelection.Instance.unitsList.Add(this.gameObject);
        // transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
    protected abstract void Setup();

    void OnDestroy()
    {
        UnitsSelection.Instance.unitsList.Remove(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (UnitsSelection.Instance.unitsSelected.Contains(gameObject))
        {
            bool state = true;
            isSelected = state;
            unitMovement.SetSelected(state);
        }
        else
        {
            bool state = false;
            isSelected = state;
            unitMovement.SetSelected(state);
        }

    }

    private void SetupComponents()
    {
        unitMovement = gameObject.AddComponent<UnitMovement>();
        unitMovement.HandleStart(stats.speed);

        //unitStats = GetComponent<UnitStats>();
        unitStats = gameObject.AddComponent<UnitStats>();
        unitStats.HandleStart(stats);

        unitAttack = gameObject.AddComponent<UnitAttack>();
        unitAttack.HandleStart(stats);
    }

    private void SetupRender()
    {
        renderGO = transform.Find("Render").gameObject;
        _renderer = renderGO.GetComponent<Renderer>();

        if (_renderer)
        {
            Color color = Color.gray;
            if (team == Types.Team.team1)
            {
                color = Color.blue;
            }
            if (team == Types.Team.team2)
            {
                color = Color.red;
            }
            _renderer.material.color = color;
        }

    }



}
