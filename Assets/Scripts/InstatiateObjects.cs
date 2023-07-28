using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class InstatiateObjects : MonoBehaviour
{
    public GameObject pellet;
    public int numberOfObjects = 30;
    //public int width = 10;
    //public int height = 10;

    void Start()
    {
        for (int i = 0; i < numberOfObjects ; ++i)
        {
                Vector3 pos = transform.position + new Vector3(i * 10f, 0f, 0f);
                Instantiate(pellet, pos, Quaternion.identity);
             
        }
    }
}