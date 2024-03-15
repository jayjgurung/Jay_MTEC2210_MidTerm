using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import TMpro setting
using TMPro;
using Unity.VisualScripting;

public class GameManagerv2 : MonoBehaviour
{
    // Start is called before the first frame update

    /// Screen Edges
    ///
    public Transform northPoint;
    public Transform southPoint;
    public Transform westPoint;
    public Transform eastPoint;
    /// Screen Edges


    public float itemSpawnDelay = 2;
    // private float delayTime = 0.25f;
    //    private int n = 1;

    float timeElapsed = 0;
    [Range(1, 100)] public int itemCount = 100; // creates a slider with default value at 40
    int currentItemCount = 0;

    public GameObject coinPrefab;
    public GameObject harmPrefab;
    public GameObject itemPrefab;

    //score
    public int score;
    public int health;
    public TextMeshPro scoreText;
    public TextMeshPro healthText;
    //randomize coin or hazard
    public GameObject[] items;
    //private PlayerMovement pm;
    public GameObject themeBox;

    private void Start()
    {
        Screen.SetResolution(3840, 2160, true);
        SpawnItem();
        //InvokeRepeating("SpawnCoin", 2, 2); // iterattion , run spawncoin , wait 2 second for first, and 2 in between every other run.
        health = 100;
    }


    public void Update()
    {
        // if health is zero enter a differ
        //{
        //    if (health <= 0)
        //    {
        //        Application.LoadLevel(/ here write number of the level(or name of the level) which you want to load /)
        //    }
        //}


        //Timer
        if (timeElapsed < itemSpawnDelay)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed == 0.5)
            {
                // create timer sound
            }
        }
        else
        {
            SpawnItem();
            timeElapsed = 0;
        }

      
        //score
        scoreText.text = "SCORE : " + score.ToString();
        healthText.text = "HEALTH : " + health.ToString() + "%";

        if (health <= 0)
        {
            GameOver();
            Debug.Log("END PROMT RAN");
        }
    }


    // FUNTION TO OPEN A PROMT THAT GIVES USER OPTIONS : RESTART, MENUT OR QUITGAME
    void GameOver()
    {
        //
    }


    // Update is called once per frame
    void SpawnItem()
    {
        if (currentItemCount % 5 == 0 & currentItemCount != 0)
        {
            if (currentItemCount > 60)
            {
                itemSpawnDelay = itemSpawnDelay - 0.14f;
            }
            else
            // delayTime = currentItemCount / 50;
            itemSpawnDelay = itemSpawnDelay - 0.2f;

        }



        //GameObject coinClone = Instantiate(coinPrefab, SpawnPos(), Quaternion.identity);  //quaternion means rotation and identity mean default, vector2.zero is x and y values at 0 
        //Debug.Log(coinClone.transform.position);
        if (currentItemCount != 0 && currentItemCount % 10 == 0)
        {
            Instantiate(themeBox, SpawnPos(), Quaternion.identity);
            currentItemCount++;
        }


        else if (currentItemCount < itemCount )
        {
            //if (currentItemCount > 5 && currentItemCount % 3 == 1)
            //{
            //    itemPrefab = harmPrefab;
            //}
            //else
            //{
            //    itemPrefab = coinPrefab;
            //

            int randomIndex = Random.Range(0, items.Length); 

            GameObject coinClone = Instantiate(items[randomIndex], SpawnPos(), Quaternion.identity);
            currentItemCount++;
        }

        //else if(currentItemCount % 10 == 0)
        //{
        //    Instantiate(themeBox, SpawnPos(), Quaternion.identity);
        //}
    }

    private Vector2 SpawnPos()
    {
        //float xValue = Random.Range(westPoint.position.x, eastPoint.position.x);
        //float yValue = Random.Range(northPoint.position.y , southPoint.position.y);
        //Vector2 temp = new Vector2(xValue, yValue);

        //have it only spawn from the top of the screen

        

        float xValue = Random.Range(westPoint.position.x, eastPoint.position.x);
        float yValue = northPoint.position.y;
        Vector2 temp = new Vector2(xValue, yValue);



        // return Camera.main.ScreenToWorldPoint(temp);
        return temp;
    }

    public void IncreaseScore()
    {
        score += 10;
    }


    public void UpdateHealth()
    {
        health -= 25;
    }

    public void DestroyPlayer()
    {
        Destroy (themeBox);

    }    

}
