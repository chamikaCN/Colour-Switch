using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D playerCircle;
    public GameObject Circle;
    public GameObject AntiCircle;
    public GameObject Square;
    public GameObject AntiSquare;
    public GameObject DoubleGear;
    public GameObject colourChanger;
    public GameObject[] obstacles;
    public float jumpforce;
    private bool rightbound;
    public string currentColor;
    public SpriteRenderer render;
    public Color blue;
    public Color green;
    public Color pink;
    public Color orange;
    private int score;
    public Text scoretext;
    private CanvasManager canvas;

    // Start is called before the first frame update
    void Start()
    {
        rightbound = true;
        setRandomColor();
        score = 0;
        scoretext.text = "0";
        obstacles = new GameObject[5];
        obstacles[0] = Circle;
        obstacles[1] = AntiCircle;
        obstacles[2] = Square;
        obstacles[3] = AntiSquare;
        obstacles[4] = DoubleGear;
        

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            playerCircle.velocity = Vector2.up * jumpforce;
        }
        /*if (Input.GetMouseButtonDown(1))
        {
            if (rightbound)
            {
                playerCircle.velocity = Vector2.right * jumpforce;
                rightbound = !rightbound;
            }
            else
            {
                playerCircle.velocity = Vector2.left * jumpforce;
                rightbound = !rightbound;
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Changer")
        {
            setRandomColor();
            Destroy(collision.gameObject);
            int rand = UnityEngine.Random.Range(0, 5);
            Instantiate(colourChanger, new Vector2(0f, transform.position.y + 14f),transform.rotation);
            Instantiate(obstacles[rand], new Vector2(0f, transform.position.y + 21f), transform.rotation);
            score = countScore(score);
            scoretext.text = score.ToString();
            Debug.Log(score);
            return;
        }
        else if (collision.tag != currentColor) 
        {
            Debug.Log("DIE");
            Highscorecheck(score);
            SceneManager.LoadScene("start screen"); 
        }
    }

    public void Highscorecheck(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            Debug.Log("going to set " + score);
            PlayerPrefs.SetInt("HighScore", score);
            Debug.Log("set " + PlayerPrefs.GetInt("HighScore"));
        }
    }

    private void setRandomColor()
    {
        int random = UnityEngine.Random.Range(0, 4);
        switch (random)
        {
            case 0:
                currentColor = "Blue";
                render.color = blue;
                break;
            case 1:
                currentColor = "Green";
                render.color = green;
                break;
            case 2:
                currentColor = "Pink";
                render.color = pink;
                break;
            case 3:
                currentColor = "Orange";
                render.color = orange;
                break;
        }
    }

    private int countScore(int currentscore)
    {
        int newScore = currentscore + 1;
        return newScore;
    }
}
