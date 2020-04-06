using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] float delayTimeLoading = 25.9f;

    int currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            StartCoroutine(LoadGameScene());
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(delayTimeLoading);
        SceneManager.LoadScene(currentScene +1);

    }
}
