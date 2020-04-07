using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    
    SpriteRenderer my_Sprite;
    // Start is called before the first frame update
    void Start()
    {
        my_Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        var defenderButn = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton defender in defenderButn)
        {
            defender.my_Sprite.color = new Color32(89, 89, 89, 255);
        }
        my_Sprite.color = Color.white;
    }



}
