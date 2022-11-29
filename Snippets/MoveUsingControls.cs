using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUsingControls : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float xpos = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float ypos = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(xpos,0,ypos);
    }
}
