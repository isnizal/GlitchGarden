using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawn : MonoBehaviour
{

    [SerializeField] bool spawnAttacker;
    [SerializeField] Attacker attackerSpawn;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawnAttacker == true)
        {
            float spawnRandomly = Random.Range(1f, 5f);
            yield return new WaitForSeconds(spawnRandomly);
            SpawnAttacker();
        }
        
    }

    public void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackerSpawn, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }






}
