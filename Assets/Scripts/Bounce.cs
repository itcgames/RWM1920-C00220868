using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        // something like if the collision is from the top side
        if (col.gameObject.GetComponent<Transform>().position.y >= this.gameObject.GetComponent<Transform>().position.y)
        {
            bounce(col.gameObject);
        }
    }
    public void bounce(GameObject other)
    {
        // bounce maths
    }
}
