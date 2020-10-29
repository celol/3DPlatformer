using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Door : MonoBehaviour
{
    private GameObject leftdoor;
    private GameObject rightdoor;
    private Vector3 leftstartPos;
    private Vector3 leftendPos;
    private Vector3 rightstartPos;
    private Vector3 rightendPos;
    private bool Opening;
    public AudioClip sound;
    private int Counter = 0;
    // Start is called before the first frame update
    void Start() {
        Opening = false;
        leftdoor = GameObject.FindGameObjectWithTag("LeftDoor");
        rightdoor = GameObject.FindGameObjectWithTag("RightDoor");
        leftstartPos = leftdoor.transform.position;
        rightstartPos = rightdoor.transform.position;
        rightendPos = rightstartPos;
        rightendPos.x = -20f;
        leftendPos = leftstartPos;
        leftendPos.x = 30f;


    }
    void OnTriggerEnter(Collider other) {
            
            if (other.tag == "Player" && Counter == 0) {
            Opening = true;
            print("Collision detected");
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Counter = Counter + 1;

        }
    }

    void Update() {
        if (Opening == true)
        {
            leftdoor.transform.position = Vector3.MoveTowards(leftdoor.transform.position, leftendPos,2*Time.deltaTime);
            rightdoor.transform.position = Vector3.MoveTowards(rightdoor.transform.position, rightendPos, 2 * Time.deltaTime);
        }
    }


    
}
