
using System.Collections.Generic;
using UnityEngine;

public class UnitsSelection : MonoBehaviour
{

    public List<GameObject> unitsList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();
    private static UnitsSelection instance_;
    public static UnitsSelection Instance { get { return instance_; } }

    private Camera myCamera;

    private LayerMask groundLayer;


    void Awake()
    {

        if (instance_ != null && instance_ != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance_ = this;
        }

        myCamera = Camera.main;
        groundLayer = LayerMask.GetMask("Ground");
    }



    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        SetSelectMark(unitToAdd, true);
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
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
        if (!unitsSelected.Contains(unitToAdd))
        {
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


    public void ExecuteAction(GameObject interactedGameobject)
    {

        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {

            Interactable hitInteractable = hit.transform.GetComponent<Interactable>();

            foreach (var selectedGO in unitsSelected)
            {
                Interactable selectedInteractable = selectedGO.GetComponent<Interactable>();

                selectedInteractable.Interact(hitInteractable);
            }

        }
    }

}
