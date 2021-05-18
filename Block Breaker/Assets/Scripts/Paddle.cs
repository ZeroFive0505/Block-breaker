using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoplay = false;
    private Ball ball;
    public float minRange;
    public float maxRange;

	// Use this for initialization
	void Start () {

        ball = GameObject.FindObjectOfType<Ball>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(autoplay==false)
        {
            MoveWithMouse();
        }
        else
        {
            Autoplay();
        }
    }

    void Autoplay()
    {

        Vector3 PaddlePos = new Vector3(7.5f, this.transform.position.y, this.transform.position.z);
        float ballPos = ball.transform.position.x;
        PaddlePos.x = Mathf.Clamp(ballPos, minRange, maxRange);
        this.transform.position = PaddlePos;
    }


    void MoveWithMouse()
    {
        Vector3 PaddlePos = new Vector3(7.5f, this.transform.position.y, this.transform.position.z);
        float MousePosition_X;
        MousePosition_X = Input.mousePosition.x / Screen.width * 16;
        print(MousePosition_X);
        PaddlePos.x = Mathf.Clamp(MousePosition_X, minRange, maxRange);
        this.transform.position = PaddlePos;
    }
}
