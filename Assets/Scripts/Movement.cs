using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 50f;
    [SerializeField] AudioClip mainEngineProcess;
    [SerializeField] AudioClip RCSEngine;
    

    AudioSource audioSource;
    Rigidbody rb;
    bool mainEnginePlays = false;
    bool RCSEnginePlays = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {   
            //TODO - add thruster particle system
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            PlayIfNotPlaying(audioSource, mainEnginePlays, mainEngineProcess);
        }
    }

    private void PlayIfNotPlaying(AudioSource audioSource, bool audioClipPlays, AudioClip audioClip)
    //TODO - make it to be possible to play multiple different sounds simultaneously
    // audioSource.isPlaying detects all the sound clips but we need to detect only the current one
    // check https://docs.unity3d.com/ScriptReference/AudioSource.html
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
 //           audioSource.Stop();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {   
            //TODO - add RCS particle system
            ApplyRotation(rotationThrust);
            PlayIfNotPlaying(audioSource, RCSEnginePlays, RCSEngine);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            PlayIfNotPlaying(audioSource, RCSEnginePlays, RCSEngine);
        }
        
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
    
}
