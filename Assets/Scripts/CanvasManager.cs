using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    /*private static CanvasManager instance;
    
    public static CanvasManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("No canvas Manager");
            }
            return instance;
        }
    }

    
    private void Awake()
    {
        Debug.LogWarning("created");
        instance = this;
    }*/

    public Button start;
    public Text HighScore;
    private PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        setHighScoreText(getHighScore());
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Level one");
    }

    public int getHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

     public void setHighScoreText(int score)
    {
        HighScore.text = score.ToString();
    }
    
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        setHighScoreText(0);
    }
}
