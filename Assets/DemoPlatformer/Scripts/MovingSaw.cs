using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    [SerializeField] Transform a;
    [SerializeField] Transform b;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    bool isATarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        if (isATarget)
        {
            transform.position += (a.position - transform.position).normalized * Time.deltaTime * speed;
            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                isATarget = false;
            }
        }
        else
        {
            transform.position += (b.position - transform.position).normalized * Time.deltaTime * speed;
            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                isATarget = true;
            }
        }
    }
}
