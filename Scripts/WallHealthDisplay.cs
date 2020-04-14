using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WallHealthDisplay : Defender
{
    float damage = 20f;

    private void Start()
    {
        baseWallText.text = wallhitpoints.ToString();
    }
    private void Update()
    {
        UpdateBaseWallText();
        if (wallhitpoints <= 0)
        {
            SceneManager.LoadScene("LoseLevel");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wallHealth(damage);
    }
}
