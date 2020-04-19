using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defender : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float defenderHealth = 10f;
    [SerializeField] int defenderCost;
    [SerializeField] public float wallhitpoints = 1000f;
    [SerializeField] float projectileSpeed;
    [SerializeField] Text baseHealth;
    [Header("None Serialize")]
    [SerializeField] public Text baseWallText;
    AttackerSpawn attackerSpawner;
    GameObject attacker;

    Animator animator;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform gunLoad;
    // Start is called before the first frame update
    void Start()
    {
        baseWallText = FindObjectOfType<Text>();
        animator = GetComponent<Animator>();
        SetLaneAttacker();
    }

    // Update is called once per frame
    void Update()
    {
        HealthStatus();
        
        
        if (isAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
            
        }
        else
        {
            animator.SetBool("isAttacking", false);

        }
        
    }

    public int GetStarCost()
    {
        
        return defenderCost;
    }
    public void UpdateBaseWallText()
    {
        
        baseWallText.text = wallhitpoints.ToString();
    }


    public void Shoot()
    {
        GameObject defenderProjectile = Instantiate(projectile, gunLoad.transform.position, gunLoad.transform.rotation) ;
        defenderProjectile.transform.parent = this.transform;
        
        
    }

    public float Health(float damage)
    {
        defenderHealth -= damage;
        return defenderHealth;
    }

    public float wallHealth(float damage)
    {
        wallhitpoints -= damage;
        return defenderHealth;
    }

    public void HealthStatus()
    {
        if (defenderHealth <= 0)
        {
           
            Destroy(gameObject);
        }
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

        attackerSpawner = FindObjectOfType<AttackerSpawn>();
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
