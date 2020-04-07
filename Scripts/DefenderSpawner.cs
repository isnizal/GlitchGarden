using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    GameObject defenderPrefab;
    // Start is called before the first frame update


    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClick());
    }
    public void SetSelectedDefender(GameObject defenderSelect)
    {
        defenderPrefab = defenderSelect;
    }
    Vector2 GetSquareClick()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 snapToGrid = GetSnapClick(worldPos);
        return snapToGrid;
    }

    Vector2 GetSnapClick(Vector2 worldPos)
    {
        float x = Mathf.RoundToInt(worldPos.x);
        float y = Mathf.RoundToInt(worldPos.y);
        return new Vector2(x,y);
    }
    void SpawnDefender(Vector2 defenderPos)
    {
        GameObject newDefender = Instantiate(defenderPrefab,defenderPos,Quaternion.identity) as GameObject;
        Debug.Log(defenderPos);
    }
}
