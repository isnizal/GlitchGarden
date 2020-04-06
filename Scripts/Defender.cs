using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float defenderHealth = 10f;
    [SerializeField] float projectileSpeed;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform gunLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
       Instantiate(projectile, gunLoad.transform.position, gunLoad.transform.rotation) ;
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float attackerHealth = FindObjectOfType<Attacker>().GetHealth(defenderHealth);
        defenderHealth = attackerHealth;
        Debug.Log("Hello");
        
    }
}
