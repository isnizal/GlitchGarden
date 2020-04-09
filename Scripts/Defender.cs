using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float defenderHealth = 10f;
    [SerializeField] float projectileSpeed;
    [Header("AttackerSpawn")]
    AttackerSpawn attackerSpawner;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform gunLoad;
    // Start is called before the first frame update
    void Start()
    {
        SetLaneAttacker();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackerInLane())
        {
            
            Debug.Log("shoot pew pew");
        }
        else
        {
            Debug.Log("ready to fire");
        }
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
    private void SetLaneAttacker()
    {
        AttackerSpawn[] attackerSpawners = FindObjectsOfType<AttackerSpawn>();

        foreach (AttackerSpawn spawner in attackerSpawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                attackerSpawner = spawner;
            }
        }
    }

    private bool isAttackerInLane()
    {
        if (attackerSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
