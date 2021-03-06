﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderProjectile : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float damage = 5f;
    [SerializeField] float speed = 1f;
    

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Fire();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
        FindObjectOfType<Attacker>().GetHealth(damage);

    }


    void Fire()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
