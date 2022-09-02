using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffect : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform SwordTransform;
    public int TimeThreshold = 3;
    public int Speed = 1;
    private double time;
    private Vector3 direction;
    
    void Start()
    {
        gameObject.transform.position = SwordTransform.position + new Vector3(-0.021f, 0.031f, 0f);
        gameObject.transform.rotation = SwordTransform.rotation;
        time = 0;
        direction = PlayerTransform.TransformDirection(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Speed * Time.deltaTime * direction;

        time += Time.deltaTime;
        if(time >= TimeThreshold)
        {
            time = 0;
            Destroy(gameObject);
        }
    }
}
