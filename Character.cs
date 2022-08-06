using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   
    public float speed = 10f;
    public float speedjump = 10f;
    private bool isJump;
    private bool isFall;
    public Animator animator;//tao bien quan ly
    bool iskeyDown;
    private bool isRun;
    
    void Start()
    {
        isFall = false;
        isJump = false;
        transform.position = new Vector2(-12.7f, -4.66f);
    }
    //Time.delta la thoi gian giua 2 frame
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("Run");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJump)
        {
            
            isJump = true;
            animator.SetTrigger("Jump");
        }
       if(Input.anyKey)
        {
            iskeyDown = true;

        }
        if (!Input.anyKey && iskeyDown)
        {
            iskeyDown = false;
            isRun = false;
            
        }

        if (isJump)
        {
            transform.Translate(Vector2.up * speedjump * Time.deltaTime);
            
        }
        if (transform.position.y>=0)
        {

            //Debug.Log("==========isJump");
            isFall = true;
            isJump = false;

        }
        if(isFall)
        {
            transform.Translate(Vector2.down * speedjump * Time.deltaTime);

        }
        if (transform.position.y < -4.66f)
        {

            transform.position = new Vector2(transform.position.x, -4.66f);
            isFall = false;
            if(isRun)
            {
                animator.SetTrigger("Run");
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
            isRun = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
            isRun = true;
        }

        
    }
}
