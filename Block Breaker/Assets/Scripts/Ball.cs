using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    Rigidbody2D rb;
    private bool hasStarted = false;
	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector);
        rb = this.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {

            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                print("MouseClicked, launch Ball");
                rb.velocity = new Vector2(Random.Range(-2f, 2f), 12f);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       // Vector2 tweak = new Vector2(Random.Range(-0.15f, 2f), Random.Range(-0.15f, 2f));

        if(hasStarted)
        {
            this.GetComponent<AudioSource>().Play();
            //rb.velocity += tweak;
        }
    }
}
