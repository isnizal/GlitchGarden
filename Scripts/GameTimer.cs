using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTime;
    [SerializeField] float timeout = 60;
    bool timehasFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        float gameTimer = Time.timeSinceLevelLoad / levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timehasFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        
        bool timeisUp =  (Time.timeSinceLevelLoad >= timeout);
        
        if (timeisUp)
        {
            Debug.Log("time has finished");
            FindObjectOfType<LevelController>().hasFinished();
            timehasFinished = true;
           
        }
    }
}
