using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float Bounciness;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.left * Bounciness * -1, ForceMode.VelocityChange);
        }
    }
}
