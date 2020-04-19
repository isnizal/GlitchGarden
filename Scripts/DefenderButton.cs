using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] GameObject defenderPrefab;
  
    SpriteRenderer my_Sprite;
    DefenderSpawner defenderspawner;
    BoxCollider2D defendboxcol;
    Text costText;
    // Start is called before the first frame update
    void Start()
    {
        
        my_Sprite = GetComponent<SpriteRenderer>();
        defenderspawner = FindObjectOfType<DefenderSpawner>();
        
        if (defendboxcol = defenderspawner.GetComponent<BoxCollider2D>())
        {
            defendboxcol.enabled = false;
        }
        else
        {
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCost();

    }
    public void DisplayCost()
    {
        
        costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetComponent<Defender>().GetStarCost().ToString();
    }



    private void OnMouseDown()
    {
        var defenderButn = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton defender in defenderButn)
        {
            defender.my_Sprite.color = new Color32(89, 89, 89, 255);
        }
        my_Sprite.color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        defendboxcol.enabled = true;
    }



}
