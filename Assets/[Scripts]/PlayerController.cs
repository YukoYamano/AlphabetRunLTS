using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;


    private bool isGround = false;
    private bool isWin = false;
    private bool isLose = false;

    [SerializeField]
    private float groundCheckRadius = 0.15f;
    [SerializeField]
    private Transform groundCheckPos;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private int targetScore = 100;

    public float speed = 2.0f;
    public float jumpForce = 5.0f;
    public Text winText;
    public Text loselastText;
    public Text CorrectAnswer;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isWin)
        {
            rBody.velocity = new Vector2(speed, rBody.velocity.y);
            isGround = GroundCheck();
        }

       

    }

    private void Update()
    {
        anim.SetBool("isGrounded", isGround);
        

        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(rBody.velocity.y);
            rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
            
            isGround = false;
            anim.SetBool("isGrounded", isGround);
        }

    }

    private bool GroundCheck()
    {
        
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ExitSign"))
        {
           // Debug.Log(CorrectAnswer.text);
            int score = int.Parse(CorrectAnswer.text);

            if (score >= targetScore)
            {
                //if score >=100
                anim.SetBool("isWin", true);
                winText.gameObject.SetActive(true);
                isWin = true;
            }
            else
            {
                isLose = true;
                loselastText.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                anim.SetBool("isDead",isLose);
            }



            


        }
    }
    

}
