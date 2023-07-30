using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJunkRemover : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a GameObject on the "Pellet" layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pellet"))
        {
            // Destroy the pellet GameObject
            Destroy(collision.gameObject);
        }
    }
}