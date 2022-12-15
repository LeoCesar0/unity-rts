using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private UnitMovement unitMovement;
    private UnitAttack unitAttack;
    private UnitStats unitStats;
    public bool isSelected = false;
    public Types.PlayerOwner playerOwner;
    public Types.Team team;
    public StatsSO stats;

    void Start()
    {
        UnitsSelection.Instance.unitsList.Add(this.gameObject);

        unitMovement = gameObject.AddComponent<UnitMovement>();
        unitMovement.HandleStart(stats.speed);

        Debug.Log(stats.speed);

        unitStats = GetComponent<UnitStats>();
        unitStats.HandleStart(stats);

        unitAttack = gameObject.AddComponent<UnitAttack>();
        unitAttack.HandleStart(stats);
    }

    void onDestroy()
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
}
