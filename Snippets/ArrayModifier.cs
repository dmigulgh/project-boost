using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayModifier : MonoBehaviour
{
    [SerializeField] int Countx;
    [SerializeField] int County;
    [SerializeField] GameObject TheObject;
    
    void OnValidate()
    {
        Apply();
    }

    void Apply()
    {
        if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            return;
        if (TheObject == null)
            return;
        Renderer renderer = TheObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            foreach(Transform t in transform)
            {
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    DestroyImmediate(t.gameObject);
                };
            
            }
        }
    

        float lastX = 0;
        float lastY = 0;

        for(int i=0; i < County; i++)
        {
            for (int j=0; j < Countx; j++)
                {
                    Vector3 pos = new Vector3(lastX + transform.localPosition.x,
                        lastY + transform.localPosition.y,
                        transform.localPosition.z);
                    
                    GameObject go = Instantiate(TheObject, pos, Quaternion.identity, transform) as GameObject;
                    go.name = TheObject.name + "_" + i + "_" + j;

                    lastX = lastX - renderer.bounds.size.x;
                }
            lastX = 0;
            lastY = lastY + renderer.bounds.size.y;
        }   

    }

}
