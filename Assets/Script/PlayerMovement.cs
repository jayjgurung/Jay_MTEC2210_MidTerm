using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed =  5;
    float turboSpeed = 10;
    float currentSpeed;
    public Color turboColor;
    private Color defaultColor;
    public SpriteRenderer sr;

    private Item lastItemCollidedWith;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = Color.white;
       // sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
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

       

        float xMove = Input.GetAxis("Horizontal");       //Smooth movement
        float yMove = Input.GetAxis("Vertical");        //Smooth movement
        transform.Translate(currentSpeed * xMove * Time.deltaTime, currentSpeed * yMove * Time.deltaTime, 0);
        //Time.deltaTime = makes it frame independent so that different computers dont have different speed

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("We Collided");
            lastItemCollidedWith = collision.gameObject.GetComponent<Item>();
            defaultColor = lastItemCollidedWith.itemColor;
            sr.color = defaultColor;
            Destroy(collision.gameObject);
        }
    }


}
