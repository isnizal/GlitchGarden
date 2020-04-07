using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStar : MonoBehaviour
{
    [SerializeField] float star = 100f;
    Text starText;
    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void UpdateDisplay()
    {
        starText.text = star.ToString();
    }

    void AddStar(int amount)
    {
        star += amount;
        UpdateDisplay();
    }

    void SpendStar(int amount)
    {
        if (star >= amount)
        {
            star -= amount;
            UpdateDisplay();
        }
    }
}
