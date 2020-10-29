using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class Unity101_CharacterController : MonoBehaviour
{
    [Header("Walk / Run Setting")] public float walkSpeed;
    public float runSpeed;

    [Header("Jump Force")] public float playerJumpForce;

    [Header("Double Jump")] public bool doubleJumpEnabled;


    private Collider col;
    private Rigidbody rb;

    private float distToGround;
    private bool playerIsJumping;
    private float currentSpeed;
    private float xAxis;
    private float zAxis;
    private bool leftShiftPressed;
    private int jumpCounter = 0;
    private float jumpDelay = 0.05f;
    private float timer = 0f;
    private bool jumpingHighSpeed;
    public TextMeshProUGUI countText;
    private int count;
    public TextMeshProUGUI Timer;
    public float timeStart = 0;
    public TextMeshProUGUI Ending;
    private int finalcount;
    private int finalTime;
    private int FinalScore;
    private Animator anim;
    private int once = 0;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        if(col == null) { Debug.LogError("Collision component missing"); enabled = false; }
        rb = GetComponent<Rigidbody>();
        if(rb == null) { Debug.LogError("Physic body component missing"); enabled = false; }
        anim = GetComponent<Animator>();
        if (anim == null) {
            print("No animator");
        }
        // To assert character doesn't fall on the side
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        distToGround = col.bounds.extents.y;
        count = 0;

        SetCountText();

    }



    // Update is called once per frame
    void Update()
    {
        // Walk
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        currentSpeed = (leftShiftPressed && !playerIsJumping) || jumpingHighSpeed ? runSpeed : walkSpeed;
        if (xAxis != 0 || zAxis != 0) {

            if (currentSpeed == walkSpeed) { anim.SetBool("isWalking", true); }

        
        else if (currentSpeed == runSpeed) {
            anim.SetBool("isRunning", true);

        }
        }
        else
        {
            anim.SetBool("isRunning",false);
            anim.SetBool("isWalking", false);
        }
        // Run
        leftShiftPressed = Input.GetKey(KeyCode.LeftShift);


        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentSpeed == runSpeed)
            {
                jumpingHighSpeed = true;
            }

            //Simple jump
            if (IsGrounded() && !playerIsJumping && jumpCounter < 1)
            {
                rb.velocity = Vector3.up * playerJumpForce;
                jumpCounter++;
                playerIsJumping = true;
                anim.SetBool("isJumping", true);
            }
            // Double jump
            else if (playerIsJumping && (doubleJumpEnabled && jumpCounter < 2))
            {
                rb.velocity = Vector3.up * playerJumpForce;
                jumpCounter++;
            }

            if (once == 1) {
                transform.Rotate(new Vector3(20, 45, 30) * 10 * Time.deltaTime);
            }
        }

        if (playerIsJumping)
        {
            timer += Time.deltaTime;

        }

        if(IsGrounded() && playerIsJumping && timer > jumpDelay)
        {
            playerIsJumping = false;
            jumpCounter = 0;
            timer = 0f;
            jumpingHighSpeed = false;
            anim.SetBool("isJumping", false);
        }
    }

    // Fixed Update is called once per frame, at fixed time
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + Time.deltaTime * currentSpeed * transform.TransformDirection(xAxis, 0f, zAxis));
        timeStart += Time.deltaTime;
        Timer.text = "Timer : "+ Mathf.Round(timeStart).ToString() + " seconds";
    }


    // Check the distance between the player and a ground surface
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.05f);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {

            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Finish") && once == 0)
        {
            finalTime = (int) Mathf.Round(timeStart);
            finalcount = count;
            FinalScore = (int) Mathf.Round(finalcount * 1000 / finalTime);
            Ending.text = "Congrats you have done it ! \n" + "Your final score is : " + FinalScore.ToString() + "\n" + "Be faster or get more Collectibles to get a higher one !";
            countText.gameObject.SetActive(false);
            Timer.gameObject.SetActive(false);
            Ending.gameObject.SetActive(true);
            once = 1;
            rb.useGravity = false;     
        }
    }

    void SetCountText()
    {
        countText.text = "Collectibles: " + count.ToString() + " / 54";
    }
}
