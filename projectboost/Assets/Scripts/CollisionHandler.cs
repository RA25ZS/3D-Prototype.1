using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] ParticleSystem crashPr;
    [SerializeField] ParticleSystem successPr;
    [SerializeField] float levelDelay = 2.5f;

    bool isTransitioning = false;

    AudioSource crashAndSuccess;

    private void Awake()
    {
        crashAndSuccess = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isTransitioning)
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
        
    }

    void HitFinishLine()
    {
        GetComponent<RocketMovement>().enabled = false;
        Invoke("LoadNextScene", levelDelay);
        crashAndSuccess.PlayOneShot(successSound);
        isTransitioning = true;
        successPr.Play();
    }

    void RocketCrash()
    {
        GetComponent<RocketMovement>().enabled = false;
        Invoke("ReloadScene", levelDelay);
        crashAndSuccess.PlayOneShot(crashSound);
        isTransitioning = true;
        crashPr.Play();
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
