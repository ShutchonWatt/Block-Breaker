using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float minX= 0.5f, maxX= 15.5f;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void AutoPlay()
    {
        //Vector2 PaddlePos = new Vector2(this.transform.position.x, this.transform.position.y);
        //PaddlePos.x = Mathf.Clamp(ball.transform.position.x, 0.5f, 15.5f);
        //this.transform.position = PaddlePos;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        float mousePosInBlocks;
        Vector3 PaddlePos = new Vector3(8, this.transform.position.y, 0f);
        //Vector3 PaddlePos = new Vector3(0.5f, 0f, 0f);
        //print(Input.mousePosition.x / Screen.width *16);
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        PaddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        this.transform.position = PaddlePos;
    }
}
