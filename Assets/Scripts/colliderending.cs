using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderending : MonoBehaviour
{
    public Camera cam;
    private AudioSource[] allAudios;
    private int counter;
    void Start()
    {
        allAudios = cam.GetComponents<AudioSource>();
        counter = 0;

    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "Player" && counter == 0) {
            allAudios[0].Stop();
            allAudios[1].Play();
            counter = 1;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);

        }
    }
}
