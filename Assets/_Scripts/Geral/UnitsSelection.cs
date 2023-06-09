
using System.Collections.Generic;
using UnityEngine;

public class UnitsSelection : MonoBehaviour
{
   
    public List<GameObject> unitsList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();
    private static UnitsSelection instance_;
    public static UnitsSelection Instance { get { return instance_; } }

    void Awake()
    {

        if(instance_ != null && instance_ != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance_ = this;
        }

    }


    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        SetSelectMark(unitToAdd, true);
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!unitsSelected.Contains(unitToAdd)) {
            unitsSelected.Add(unitToAdd);
            SetSelectMark(unitToAdd, true);
        }
        else
        {
            unitsSelected.Remove(unitToAdd);
            SetSelectMark(unitToAdd, false);
        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd)){
            unitsSelected.Add(unitToAdd);
            SetSelectMark(unitToAdd, true);
        }
    }

    public void Deselect(GameObject unitToAdd)
    {

    }

    public void DeselectAll()
    {
        foreach (GameObject unit in unitsSelected)
        {
            SetSelectMark(unit, false);
        }
        unitsSelected.Clear();
    }

    private void SetSelectMark(GameObject unit, bool boolean)
    {
        Transform SelectMark = unit.transform.Find("SelectMark");
        if (SelectMark)
        {
            SelectMark.GetComponent<MeshRenderer>().enabled = boolean;
        }
    }
 
}
