using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour, Interactable
{

    /* --------------------------------- PUBLIC --------------------------------- */

    public Types.PlayerOwner playerOwner;
    public Types.Team team;
    public UnitStats unitStats { get; protected set; }
    public bool isSelected = false;

    /* --------------------------------- PRIVATE -------------------------------- */

    public UnitMovement unitMovement;
    protected UnitAttack unitAttack;

    // public StatsSO stats { get; protected set; }
    public StatsSO defaultStats;

    protected Renderer _renderer;
    protected GameObject renderGO;
    private LayerMask groundLayer;
    private Camera myCam;

    private float delayOnDestroy = 2.5f;

    protected virtual void Start()
    {
        if (defaultStats == null)
        {
            Debug.LogError("StatsSO is not assigned for " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        if (!gameObject.GetComponent<NavMeshAgent>())
        {
            gameObject.AddComponent<NavMeshAgent>();
        }

        groundLayer = LayerMask.GetMask("Ground");

        SetupComponents();

        SetupRender();

        UnitsSelection.Instance.unitsList.Add(this.gameObject);
        // transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
    // protected abstract void Setup();

    void OnDestroy()
    {
        UnitsSelection.Instance.unitsList.Remove(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (unitStats.isDead == true)
        {
            OnDie();
        }

        CheckIfSelected();
    }

    private void SetupComponents()
    {
        // unitMovement = gameObject.AddComponent<UnitMovement>();
        // unitMovement.HandleStart(stats.speed);
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        unitMovement = new UnitMovement(this);

        unitStats = new UnitStats(this);

        unitAttack = new UnitAttack(this);
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

    private IEnumerator OnDie()
    {
        yield return new WaitForSeconds(delayOnDestroy);
        Destroy(gameObject);
    }


    public void CheckIfSelected()
    {
        if (unitStats.isDead && isSelected)
        {
            isSelected = false;
            return;
        }

        if (UnitsSelection.Instance.unitsSelected.Contains(gameObject))
        {
            isSelected = true;
        }
        else
        {
            isSelected = false;
        }
    }

    public void InteractWithUnit(Unit unit)
    {
        Debug.Log("INTERACT WITH UNIT");
        unitMovement.MoveTo(unit.transform.position);
    }
}
