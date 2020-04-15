using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winCondition;

    int attackerspawn = 0;
    bool timeHasfinished = false;

    private void Start()
    {
        winCondition.SetActive(false);

    }
    public void AttackerSpawn()
    {
        attackerspawn++;
    }

    public void AttackerKilled()
    {
        attackerspawn--;
        if (attackerspawn <= 0 && timeHasfinished)
        {
           
            StartCoroutine(HandleWinCondition());
        }
    }

    public void hasFinished()
    {
        timeHasfinished = true;
        StopSpawner();
    }

    private void StopSpawner()
    {
        AttackerSpawn[] attackerSpawn = FindObjectsOfType<AttackerSpawn>();
        foreach (AttackerSpawn spawn in attackerSpawn)
        {
            spawn.StopSpawning();
        }
 
    }

    IEnumerator HandleWinCondition()
    {
        GetComponent<AudioSource>().Play();
        winCondition.SetActive(true);
        yield return new WaitForSeconds(7f);
        GetComponent<Level>().LoadLevel();

    }

}
