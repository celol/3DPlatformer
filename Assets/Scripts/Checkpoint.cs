using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

	
	private int contact = 0;
	public DeathWall deathWall;
	public DeathWall deathWall1;
	public DeathWall deathWall2;
	public DeathWall deathWall3;
	public DeathWall deathWall4;
	public DeathWall deathWall5;
	public AudioClip Check;
    void Start()
	{

		

	}
	private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player" && contact == 0) {

    
			Debug.Log("Trigger enter Checkpoint");
            contact += 1;
            deathWall.originalPos = GameObject.Find("Character").transform.position;
			deathWall1.originalPos = GameObject.Find("Character").transform.position;
			deathWall2.originalPos = GameObject.Find("Character").transform.position;
			deathWall3.originalPos = GameObject.Find("Character").transform.position;
			deathWall4.originalPos = GameObject.Find("Character").transform.position;
			deathWall5.originalPos = GameObject.Find("Character").transform.position;
			transform.GetChild(2).gameObject.SetActive(true);
			transform.GetChild(3).gameObject.SetActive(true);
			transform.GetChild(4).gameObject.SetActive(true);
			transform.GetChild(5).gameObject.SetActive(true);
			transform.GetChild(6).gameObject.SetActive(true);
			AudioSource.PlayClipAtPoint(Check,transform.position);
		}


	}


}