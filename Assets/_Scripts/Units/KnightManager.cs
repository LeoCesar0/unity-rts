using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnightManager : MonoBehaviour
{

    public StatsSO stats;

    // public GameObject unitPrefab;

    // private GameObject unitGO;
    private UnitManager unitManager;


    // Start is called before the first frame update
    void Start()
    {
        // unitGO = Instantiate(unitPrefab, transform.position, transform.rotation);
        // unitGO.transform.parent = gameObject.transform;
        // unitManager = unitGO.GetComponent<UnitManager>();
        // unitManager.HandleStart(stats);


        if (!gameObject.GetComponent<NavMeshAgent>())
        {
            gameObject.AddComponent<NavMeshAgent>();

        }

        unitManager = gameObject.AddComponent<UnitManager>();
        unitManager.HandleStart(stats);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
