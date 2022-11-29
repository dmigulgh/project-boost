using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreCounter;
    int counter = 0; 
    private void OnCollisionEnter(Collision wall)
    {   
        if (wall.gameObject.tag != "Hit") 
        {
            counter++;
            scoreCounter.text = counter.ToString();
        }
        
    }
}
