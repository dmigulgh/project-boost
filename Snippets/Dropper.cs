using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{   
    MeshRenderer Renderer;
    Rigidbody rigidBody;
    [SerializeField] float timeToWait = 3f;
    // Start is called before the first frame update
    void Start()
    {   
        Renderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        Renderer.enabled = false;
        rigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Time.time > timeToWait)
        {
            Renderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }

}
