using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private UnitMovement unitMovement;
    private UnitAttack unitAttack;
    private UnitStats unitStats;
    public bool isSelected = false;
    public Types.PlayerOwner playerOwner;
    public Types.Team team;
    private StatsSO stats;
    private Renderer renderer_;
    private GameObject renderGO;

    public void HandleStart(StatsSO givenStats)
    {
        stats = givenStats;

        unitMovement = gameObject.AddComponent<UnitMovement>();
        unitMovement.HandleStart(stats.speed);

        //unitStats = GetComponent<UnitStats>();
        unitStats = gameObject.AddComponent<UnitStats>();
        unitStats.HandleStart(stats);

        unitAttack = gameObject.AddComponent<UnitAttack>();
        unitAttack.HandleStart(stats);

        renderGO = transform.Find("Render").gameObject;
        renderer_ = renderGO.GetComponent<Renderer>();

        Color color = Color.gray;
        if (team == Types.Team.team1)
        {
            color = Color.blue;
        }
        if (team == Types.Team.team2)
        {
            color = Color.red;
        }
        renderer_.material.color = color;

        UnitsSelection.Instance.unitsList.Add(this.gameObject);
        // transform.position = new Vector3(transform.position.x, 0, transform.position.z);

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
