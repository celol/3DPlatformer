using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FallingMat : MonoBehaviour
{

    private Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            transform.position = originalPos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    }
