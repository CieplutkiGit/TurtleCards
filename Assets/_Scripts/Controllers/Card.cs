using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public int cardID;

    public Sprite cardSplashArt;
    public UnitScriptableObject unit;
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
        Debug.Log("droping card "+cardID);
        Destroy(this.transform.gameObject);
        Instantiate(unit.unitPrefab,transform.position,Quaternion.identity);

    }
}
