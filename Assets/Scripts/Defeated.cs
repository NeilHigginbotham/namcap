using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeated : MonoBehaviour
{
    public LayerMask Pellet;

    public bool pelletInSightRange;
    public float sightRange;
    void Start()
    {

    }
    // This detects all pellets in the level. If there are no pellets, then the defeat function is triggered.
    void Update()
    {
        pelletInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, Pellet);


        if (!pelletInSightRange) Defeat();
    }
    public void Defeat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}