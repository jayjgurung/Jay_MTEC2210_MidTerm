using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed =  5;
    public float turboSpeed = 10;

    //x-axis limiter
    //public Transform westPoint;
    //public Transform eastPoint;

    private float xLimitLeft;
    private float xLimitRight;

    public AudioClip clip;
    AudioSource audioSource;
    public AudioClip harmClip;
    public AudioClip deathClip;
    public AudioClip themeClip;

    float currentSpeed;
    public Color turboColor;
    private Color defaultColor;
    public SpriteRenderer sr;

    private Item lastItemCollidedWith;

    //import gamemanager
    public GameManagerv2 gm;



    //rotation
    public float rotationSpeed = 50f;

    private Animator anim;
    //  private Transform transform;

    // Start is called before the first frame update


    void Start()
    {
        xLimitLeft = gm.westPoint.position.x;         //         Limit horizontal movement
        xLimitRight = gm.eastPoint.position.x;        //         Limit horizontal movement

        audioSource = GetComponent<AudioSource>();
        defaultColor = Color.white;

        anim = GetComponent<Animator>();
        //transform = GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {

        float xMove = Input.GetAxis("Horizontal");       //Smooth movement
        // float yMove = Input.GetAxis("Vertical");        //Smooth movement

        transform.Translate(currentSpeed * xMove * Time.deltaTime, 0, 0);

        //transform.Translate(currentSpeed * xMove * Time.deltaTime, currentSpeed * yMove * Time.deltaTime, 0);
        // TurnPlayer();

        if (xMove != 0)
        {
            anim.SetBool("Walking", true);

        }

        else
        {
            anim.SetBool("Walking", false);
        }


        //if (xMove < 0)
        //{
        //    //raotate left 30 degrees
        //    //transform.rotation= Quaternion.Euler(0, 0, -30f) ;
        //}

        //else if (xMove > 0)
        //{
        //    //raotate right 30 degrees
        //    //transform.rotation = Quaternion.Euler(0, 0, 30f);
        //}

        //else
        //{
        //    // do nothing
        //    //transform.rotation = Quaternion.Euler(0, 0, 0);
        //}


        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed = turboSpeed;
            sr.color = turboColor;
        }
        else
        {
            currentSpeed = speed;
            sr.color = defaultColor;
        }


    

 
        ///////////         Limit horizontal movement
        ///

        if (transform.position.x < xLimitLeft)
        {
            transform.position = gm.westPoint.position;
        }
        else if (transform.position.x > xLimitRight)
        {
            transform.position = gm.eastPoint.position;
        }
        //if (transform.position.x < xLimitLeft)
        //{
        //    transform.position = gm.westPoint.position ;
        //}
        //else if (transform.position.x > xLimitRight)
        //{
        //    transform.position = gm.eastPoint.position;
        //}
        ///
        ///////////         Limit horizontal movement


        //        //Time.deltaTime = makes it frame independent so that different computers dont have different speed

        //    }
        //}
    }

    //turn player from left to right by z axix rotation

    //private void TurnPlayer()
    //{
    //    if (Input.GetAxis("Horizontal") < 0)
    //    {
    //    transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    //    }
    //    else if(Input.GetAxis("Horizontal") > 0)
    //    {

    //    }
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            audioSource.PlayOneShot(clip);
            gm.IncreaseScore();
            Destroy(collision.gameObject);

            Debug.Log("Coin Triggered");

        }
        else if (collision.gameObject.tag == "harm")
        {
            audioSource.PlayOneShot(harmClip);
            gm.UpdateHealth();

            //gm.IncreaseScore();

            Destroy(collision.gameObject);
            Debug.Log("Harzard!!");

            if (gm.health <= 0)
            {
                audioSource.PlayOneShot(deathClip);
                Destroy(gameObject);
                // gm.EndPrompt();
            }

        }
        else if (collision.gameObject.tag == "themeBox")
        {
            audioSource.PlayOneShot(themeClip);

            // THEME CHANGES insert code here


            //

            //gm.IncreaseScore();

            Destroy(collision.gameObject);
            Debug.Log("Theme Captured !");

        }
    }


            
}
    //void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //    if (collision.gameObject.tag == "coin")
    //    {
    //        audioSource.PlayOneShot(clip);
    //        Destroy(collision.gameObject);
    //        Debug.Log("Collided");
            
    //    }
     







    //    //if (collision.gameObject.tag == "Item")
    //    //{
    //    //    Debug.Log("We Collided");
    //    //    lastItemCollidedWith = collision.gameObject.GetComponent<Item>();
    //    //    defaultColor = lastItemCollidedWith.itemColor;
    //    //    sr.color = defaultColor;
    //    //    Destroy(collision.gameObject);
    //    //}
    //}

