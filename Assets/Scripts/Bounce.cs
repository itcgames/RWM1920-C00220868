using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceAmount = 10;
    private Vector2 velocity;

    void OnCollisionEnter2D(Collision2D col)
    {
        // something like if the collision is from the top side
        if (col.gameObject.GetComponent<Transform>().position.y >= this.gameObject.GetComponent<Transform>().position.y)
        {
            bounce(col.gameObject);
        }
    }
    public void bounce(GameObject other)
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Stop();
        }
        GetComponent<AudioSource>().Play();
        velocity = other.GetComponent<Rigidbody2D>().velocity;
        velocity.y = 0;
        other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, bounceAmount));
        animate();
    }

    IEnumerator animate()
    {
        Debug.Log("Animate");
        this.GetComponent<SpriteRenderer>().transform.localScale += new Vector3(10, -20, 0);
        yield return new WaitForSeconds(1);
        this.GetComponent<SpriteRenderer>().transform.localScale -= new Vector3(10, -20, 0);
    }
}
