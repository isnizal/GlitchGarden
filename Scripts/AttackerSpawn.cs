using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawn : MonoBehaviour
{

    [SerializeField] bool spawnAttacker;
    [SerializeField] GameObject objPrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (spawnAttacker == true)
        {
            float spawnRandomly = Random.Range(1f, 5f);
            yield return new WaitForSeconds(spawnRandomly);
            SpawnPrefab();
        }
        
    }

    public void SpawnPrefab()
    {
        Instantiate(objPrefab, transform.position, transform.rotation);
    }






}
