using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    
    private Vector3 p;

    private void Start()
    {
        p = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        p.x = Mathf.Lerp(transform.position.x, target.position.x, Time.deltaTime * speed);
        // p.y = Mathf.Lerp(transform.position.y, target.position.y, Time.deltaTime * speed);
        p.z = Mathf.Lerp(transform.position.z, target.position.z, Time.deltaTime * speed);
        transform.position = p;
    }
}
