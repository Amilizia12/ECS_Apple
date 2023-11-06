using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreGT;
    void Start()
    {
        GameObject scoreGo = GameObject.Find("Score");
        scoreGT = scoreGo.GetComponent<Text>();
        scoreGT.text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousepos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousepos3D.x;
        this.transform.position = pos;
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidingwith = collision.gameObject;
        if (collidingwith.CompareTag("Apple")) 
        {
            Destroy(collidingwith);
        }
        else if (collidingwith.CompareTag("Bomb"))
        {
            Destroy(collidingwith);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call the public AppleDestroyed() method of apScript
            apScript.BombDestroyed();
        }

        int score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();

        if (score > Highscore.score)
        {
            Highscore.score = score;
        }
    }
}