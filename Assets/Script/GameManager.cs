using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range(1, 10)] public int itemCount;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemCount; i++)
        {
            SpawnItem(Vector3.one * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem(Vector3 location)
    {
        GameObject item = Instantiate(itemPrefab, location, Quaternion.identity);
        item.GetComponent<Item>().itemColor = Random.ColorHSV();
    }
}
