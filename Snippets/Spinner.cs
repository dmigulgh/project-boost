using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] Vector3 rotation_angle = new Vector3(0,0.1f,0);
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation_angle);
    }
}
