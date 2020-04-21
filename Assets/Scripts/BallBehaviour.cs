using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    public Transform paddle;
    public AudioSource audioBall;
    public AudioSource audioScore;
    public bool gameStarted = false; //Cuando no se inicializa un bool el por default se pone en false.

    public Rigidbody2D Ballrb;
    float posDif;
    float maxSpeed;
    Vector3 vel;

    // Use this for initialization
    void Start () {
        posDif = paddle.position.x - transform.position.x;
        maxSpeed = 35f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 vel = Ballrb.velocity;
        if (vel.magnitude > maxSpeed)
        {
            Ballrb.velocity = vel.normalized * maxSpeed;
        }

        if (!gameStarted) //if(gameStarted == false) es lo mismo que poner if(!gameStarted).
        {          
            transform.position = new Vector3(paddle.position.x - posDif, paddle.position.y, 0);
            

            if (Input.GetMouseButtonDown(0))
            {
                if(SceneChanger.gameplaySetting == 0)
                {
                    Ballrb.velocity = new Vector2(8.8f, 8.8f);
                    gameStarted = true;
                }
                else
                {
                    Ballrb.velocity = new Vector2(-8.8f, 8.8f);
                    gameStarted = true;
                }               
            }
        }
       
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioBall.Play();
        if(collision.gameObject.tag == "topWall")
        {            
            Ballrb.AddForce(new Vector2(0,-5));
        }else if (collision.gameObject.tag == "bottomWall")
        {            
            Ballrb.AddForce(new Vector2(0, 5));
        }
        else if (collision.gameObject.tag == "playerWall")
        {
            if (SceneChanger.gameplaySetting == 1)
            {
                int ramdonNumber = Random.Range(-5, -5);
                int verticalSpeed = ramdonNumber * 50;
                Debug.Log(verticalSpeed + " " + ramdonNumber);
                Ballrb.AddForce(new Vector2(-150, verticalSpeed));
            }
            else
            {
                int ramdonNumber = Random.Range(-5, 5);
                int verticalSpeed = ramdonNumber * 50;
                Debug.Log(verticalSpeed + " " + ramdonNumber);
                Ballrb.AddForce(new Vector2(150, verticalSpeed));
            }
                
        }
        else if (collision.gameObject.tag == "enemyWall")
        {
            if (SceneChanger.gameplaySetting == 1)
            {
                  
                Ballrb.AddForce(new Vector2(150, 0));
            }
            else
            {

                Ballrb.AddForce(new Vector2(-150, 0));
            }
        }

    }


}
