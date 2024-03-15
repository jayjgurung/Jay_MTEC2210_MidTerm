using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range(1, 40)] public int itemCount;
    public GameObject itemPrefab;
    public GameObject itemPrefabbad;
    public GameObject itemDrop;

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
        if (itemCount>5 && itemCount % 3 == 1)
        {
            itemDrop = itemPrefabbad;
        }
        else
        {
            itemDrop = itemPrefab;
        }
        GameObject item = Instantiate(itemDrop, location, Quaternion.identity);
        item.GetComponent<Item>().itemColor = Random.ColorHSV();
    }

    
}
