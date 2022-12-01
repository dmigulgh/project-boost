using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;
    bool isTransitioning = false;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision other)
    {   
        if (!isTransitioning)
        {
            switch (other.gameObject.tag)
        
            {
                case "Respawn":
                    Debug.Log("Hit respawn");
                    break;
                case "Finish":
                    StartSuccessSequence();
                    break;
                default:
    //                ReloadLevel();
                    StartCrashSequence();
                    break;
            }
        }
    }
    void StartCrashSequence()
    {   
        isTransitioning = true;
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        StartCoroutine(ReloadLevel(levelLoadDelay));
    }

    void StartSuccessSequence()
    {   
        isTransitioning = true;
        audioSource.PlayOneShot(success);
        successParticles.Play();
         GetComponent<Movement>().enabled = false;
        //TODO loadNextLevel
    }

    public IEnumerator ReloadLevel(float delay)
    {   
        yield return new WaitForSeconds(delay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}