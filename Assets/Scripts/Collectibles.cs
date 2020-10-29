using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip GotIt;
    private int counter = 0;
    private Collider col;


    // Update is called once per frame
    void Start()
    {
       col = gameObject.GetComponent<Collider>();

    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && counter == 0)
        {
            col.isTrigger = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);

            transform.GetChild(4).gameObject.SetActive(true);

            AudioSource.PlayClipAtPoint(GotIt, transform.position);

            


        counter = 1;

      }
    }
}
