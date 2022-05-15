using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManeger : MonoBehaviour
{
    public GameObject text_;
    public float time;
    public List<GameObject> gObjList = new List<GameObject>(3);
    public GameObject panel;
    public bool gameOver;
    
    void Start()
    {
        gameOver = false;
        StartCoroutine(timer());
    }

    public void spawnStart(Vector3 vec3)
    {
        StartCoroutine(spawn(vec3));
    }

    IEnumerator spawn(Vector3 vec3)
    {
        yield return new WaitForSeconds(10f);
        int select = Random.Range(0, 2);
        Instantiate(gObjList[select], vec3, quaternion.identity);
    }
    
    IEnumerator timer()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
        }

        if (time == 0)
        {
            Debug.Log("game Finished");
            panel.gameObject.SetActive(true);
            gameOver = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        text_.gameObject.GetComponent<Text>().text = time.ToString();
    }
}
