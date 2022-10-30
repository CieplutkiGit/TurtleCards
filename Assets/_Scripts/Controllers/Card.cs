using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Reflection;

public class Card : MonoBehaviour
{
    public int cardID;

    public Sprite cardSplashArt;
    public UnitScriptableObject unit;
    public BuildingScriptableObject building;
    public Canvas canvas;

    public float dropOffset;
    private Vector3 startPosition;
    
    private void OnEnable() {
        startPosition = transform.position;
    }
    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData) data;

        Vector2 position;
        RectTransformUtility
            .ScreenPointToLocalPointInRectangle((RectTransform)
            canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);

            transform.position= canvas.transform.TransformPoint(position);
    }

    public void DropHandler(BaseEventData data)
    {
        if(transform.position.z < startPosition.z + dropOffset)
        return;
        Destroy(this.transform.gameObject);

        if (unit)
        {
            GameObject newUnit = Instantiate(unit.unitPrefab, transform.position, Quaternion.identity);

            newUnit.GetComponent<UnitBase>().unitData = unit;

            newUnit.GetComponent<UnitBase>().isPlayer = true;
        }
        else 
        {
            GameObject newBuilding = Instantiate(building.buildPrefab, transform.position, Quaternion.identity);

            newBuilding.GetComponent<BuildingBase>().buildingData = building;

            newBuilding.GetComponent<BuildingBase>().isPlayer = true;
        }
    }

}
