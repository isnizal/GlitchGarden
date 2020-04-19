using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    GameObject defenderPrefab;
    GameObject parentDefender;
    string defender = "defenderSpawn";
    // Start is called before the first frame update
    private void Start()
    {
        CreateParent();
    }

    private void CreateParent()
    {
        parentDefender = GameObject.Find(defender);
        if (!parentDefender)
        {
            parentDefender = new GameObject(defender);
        }
    }
    private void Update()
    {

    }

    private void OnMouseDown()
    {
        GetCostDefender(GetSquareClick());
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
    void GetCostDefender(Vector2 snapGrid)
    {
        int cost = defenderPrefab.GetComponent<Defender>().GetStarCost();

        var displayStar = FindObjectOfType<DisplayStar>();
        if (displayStar.haveEnoughStar(cost))
        {
            displayStar.SpendStar(cost);
            SpawnDefender(snapGrid);

        }
        else
        {
            return;
        }

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
        newDefender.transform.parent = parentDefender.transform;
        
    }
}
