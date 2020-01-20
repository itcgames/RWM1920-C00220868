using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceAmount = 10;
    private Vector2 velocity;
    private const float MOVE = -0.75f;
    private const float SCALE_X = 0.15f;
    private const float SCALE_Y = -0.25f;
    private Vector3 defaultPos;
    private Vector3 defaultScale;
    private void Start()
    {
        defaultPos = this.GetComponent<Transform>().position;
        defaultScale = this.GetComponent<Transform>().localScale;
    }

void OnCollisionEnter2D(Collision2D col)
    {
        // reset to defaults if a second collision starts before previous has finished
        StopAllCoroutines();
        this.GetComponent<Transform>().localScale = defaultScale;
        this.GetComponent<Transform>().position = defaultPos;
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
        StartCoroutine(animate());
    }

    IEnumerator animate()
    {
        this.GetComponent<Transform>().localScale += new Vector3(SCALE_X, SCALE_Y, 0);
        this.GetComponent<Transform>().position += new Vector3(0, MOVE, 0);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Transform>().localScale -= new Vector3(SCALE_X, SCALE_Y, 0);
        this.GetComponent<Transform>().position -= new Vector3(0, MOVE, 0);

    }
}
