using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacker : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float health = 10;
    [SerializeField] float damage = 10;
    [SerializeField] GameObject deadParticleVFX;
    [SerializeField] GameObject HealthBar;
    [SerializeField] GameObject HealthBarPosition;
    [SerializeField] GameObject attackerSlider;
    float attackerValue;
    [Range(0f, 4f)] [SerializeField] float currentSpeed = 1f;
    Animator animator;
    GameObject currentTarget;
    // Start is called before the first frame update

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawn();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController == null)
        {
            return;
        }
        else
        {
            FindObjectOfType<LevelController>().AttackerKilled();
        }
        
    }
    void Start()
    {

        InstantiateHealthBar();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthStatus();
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
        updateHealthBar(HealthBar);
        //put instantiatehealth bar on update
        
        
        
    }
    void updateHealthBar(GameObject healthBar)
    {
        Slider slide = healthBar.GetComponentInChildren<Slider>();
        HealthValue(slide);
    }

    void InstantiateHealthBar()
    {
        GameObject healthBar = Instantiate(HealthBar, HealthBarPosition.transform.position, transform.rotation) as GameObject;
        //if healthbar more than 1 destroy it
        healthBar.transform.parent = transform;
        updateHealthBar(healthBar);

    }
    void HealthValue(Slider slide)
    {
        attackerValue = health / health;
        slide.value = attackerValue;
        Debug.Log(attackerValue);
        
    }

    void UpdateAnimationState()
    {
        if (!currentTarget)
        {
           
            GetComponent<Animator>().SetBool("isAttacking", false);
            GetComponent<Animator>().SetBool("isJump", false);

        }

    }
    public float SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
        return currentSpeed;
    }
    public float GetHealth(float damage)
    {
        health -= damage;
        
        return health;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void HealthStatus()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject deadParticle = Instantiate(deadParticleVFX, transform.position, transform.rotation)
                as GameObject;
            Destroy(deadParticle, 3f);
            FindObjectOfType<LevelController>().AttackerKilled();
        }

        return;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
        
    }
    public void Jump(GameObject target)
    {
        GetComponent<Animator>().SetTrigger("isJump");
        currentTarget = target;

    }
 

    public void AttackCurrentTarget(float damage)
    {
        if (!currentTarget)
            return;
       Defender health = currentTarget.GetComponent<Defender>();

        if (health)
        {
            health.Health(damage);
           
        }

    }



}