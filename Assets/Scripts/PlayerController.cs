using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private bool isStair;
    void Start()
    {
        isStair = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool gO = GameObject.Find("GameManeger").GetComponent<GameManeger>().gameOver;
        if (!gO)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed , Space.World);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed,Space.World);
            }

            if (isStair)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed,Space.World);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed,Space.World);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameObject.transform.eulerAngles = new Vector3(0, 180f, 0);
                gameObject.GetComponent<Animator>().SetBool("Run" , true);
            }
        
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0f, 0);
                gameObject.GetComponent<Animator>().SetBool("Run" , true);
            }

            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<Animator>().SetBool("Run" , false);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Meal")
        {
            Vector3 v3 = other.gameObject.transform.position;
            GameObject.Find("GameManeger").GetComponent<GameManeger>().time += 5;
            Destroy(other.gameObject);
            GameObject.Find("GameManeger").GetComponent<GameManeger>().spawnStart(v3);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stair")
        {
            isStair = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stair")
        {
            isStair = false;
        }
    }
}
