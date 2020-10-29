using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeathWall : MonoBehaviour
{	
	public Vector3 originalPos;
	public void Start(){
		originalPos = GameObject.Find("Character").transform.position;
	}
	private void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			print("Trigger Enter Death Wall");
            GameObject.Find("Character").transform.position = originalPos;
			GameObject.Find("Character").GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	
	}
}