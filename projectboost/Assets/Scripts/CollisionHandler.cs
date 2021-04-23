using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelDelay = 2.5f;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly obj");
                break;
            case "Finish":
                HitFinishLine();
                Debug.Log("You hit the finish");
                break;
            default:
                RocketCrash();
                Debug.Log("You're dead");
                break;
        }
    }

    void HitFinishLine()
    {
        GetComponent<RocketMovement>().enabled = false;
        Invoke("LoadNextScene", levelDelay);
    }

    void RocketCrash()
    {
        GetComponent<RocketMovement>().enabled = false;
        Invoke("ReloadScene", levelDelay);
    }
    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }

    void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    
}
