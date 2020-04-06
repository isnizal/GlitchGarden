using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float health = 10;
    [SerializeField] GameObject deadParticleVFX;
    [Range(0f, 4f)] [SerializeField] float currentSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthStatus();
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
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

    public void HealthStatus()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject deadParticle = Instantiate(deadParticleVFX, transform.position, transform.rotation)
                as GameObject;
            Destroy(deadParticle, 3f);
        }

        return;
    }

}