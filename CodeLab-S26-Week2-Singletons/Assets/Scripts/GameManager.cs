using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    
    public int targetScore = 3;
    
    public int currentLevel = 0;

    public static GameManager instance;
    
    public TMP_Text scoreText;

    string defaultScoreText = "Score: <score> Target: <target>";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string updatedScoreText = defaultScoreText;

        updatedScoreText = updatedScoreText.Replace("<score>", score + "");
        updatedScoreText = updatedScoreText.Replace("<target>", targetScore + "");
        
        scoreText.text = updatedScoreText;

        if (score >= targetScore)
        {
            currentLevel++;
            targetScore = targetScore * 2;
            SceneManager.LoadScene(currentLevel);
        }

    }
}
