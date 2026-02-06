using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

/// <summary>
/// Manages score, level progression and persists across scenes.
/// Attach to a GameObject and assign `scoreText` in the Inspector.
/// </summary>
public class GameManager : MonoBehaviour
{
    //const variables can never be changed once they are set
    //static variables can change, but they are the same across instance of a class and the class itself
    
    const string DIR_DATA = "/Data/"; //folder we will put our data file into
    const string FILE_SCORES = DIR_DATA + "highScore.txt"; //file we will put data into
    
    
    //Keys for saving data to PlayerPrefs
    const string KeyScore = "Score";
    const string KeyForTheHighScorePlayerPref = "High Score";
    
    // private int haw;
    // public int Haw { set; get; }

    // Current player score (can be modified by other scripts)
    private int score;

    public int Score //C# Property that is a wrapper around "score",
                     //must be a capitalized version of that  
    {
        set //gets called whenever Score is set
        {
            Debug.Log("Set Score: " + value);
            
            score = value; //sets the var "score" to the value of Score
            
            //Replaced PlayerPrefs with File IO
            PlayerPrefs.SetInt(KeyScore, score); //Saving the score to player prefs so it can be retrieved later (even after closing the game)
            
            // Debug.Log("Where we save: " + fullFilePath);
            
            //play a sound?
            //add juice?
            //spawn enemy?
            //you can do whatever you want in this function
            //and it will happen whenever you set the value
            //of the Score property
            
            if (score > HighScore) //int var score > the property HighScore
            {
                HighScore = score;
            }
        }
        get
        {
            score = PlayerPrefs.GetInt(KeyScore, 0); //Retrieving the score from player prefs
            
            Debug.Log("Got Score: " + score);
            return score;  //return the value of the "score" var
        }
    }


    private int highScore;

    public int HighScore  //a property that wraps the var highScore that calls
    {
        get
        {
            //highScore = PlayerPrefs.GetInt(KeyForTheHighScorePlayerPref, 5);
            
            //getting the path to the highScore.txt file
            string fullFilePath = Application.dataPath + FILE_SCORES;


            //if there is no file
            if (!File.Exists(fullFilePath))
            {
                highScore = 1; //default high score is 1
            }
            else //otherwise
            {
                //get the contents out of the highScore file
                string fileContents = File.ReadAllText(fullFilePath);
                
                //turn the string version of those contents into an int
                highScore = int.Parse(fileContents);
            }

            return highScore;
        }

        set
        {
            Debug.Log("Got High Score!!! : " + value);
            highScore = value;
            //PlayerPrefs.SetInt(KeyForTheHighScorePlayerPref, highScore);

            string fileContents = highScore + ""; //turn the score into a string we can put in a file
            
            //get the full data path with Unity's help
            //NOTE: If you were releasing this, you should use
            //Application.persistentDataPath instead of just
            //Application.dataPath, which is better for debuggin
            string fullFilePath = Application.dataPath + FILE_SCORES;
            
            Debug.Log(fullFilePath);

            if (!File.Exists(fullFilePath))  //if we haven't saved already
            {
                //create the folder to save
                Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            }
            
            //Save the fileContents (highScore string) to the file "highScore.txt"
            File.WriteAllText(fullFilePath, fileContents);
        }
    }

    // Current level / scene index
    public int currentLevel = 0;

    // Singleton instance so the GameManager persists and is globally accessible
    public static GameManager instance;

    // Reference to a TextMeshPro UI element that displays score and target
    // Must be assigned in the Inspector to avoid a null reference at runtime
    public TMP_Text scoreText;

    // Template string used to format the displayed score and target
    string defaultScoreText = "Score: <score> High Score: <high>";

    // Start is called once before the first frame update
    void Start()
    {
        //If you want to delete all the keys in a playerPref, use this
        //PlayerPrefs.DeleteAll();

        Score = 0;
        
        // Establish singleton: keep the first instance and destroy duplicates
        if (instance == null)
        {
            instance = this;
            // Prevent this GameObject from being destroyed when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy duplicate GameManager instances to enforce single instance
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() 
        //updating the text could be done in a property, since it only needs
        //to change when the score changes
    {
        // Build the display string from the template
        string updatedScoreText = defaultScoreText;

        // Replace placeholders with current values
        updatedScoreText = updatedScoreText.Replace("<score>", Score + ""); //always use the property to make sure the value is properly loaded
        updatedScoreText = updatedScoreText.Replace("<high>", HighScore + "");

        // Update the UI text if assigned (avoid null reference)
        if (scoreText != null)
        {
            scoreText.text = updatedScoreText;
        }
        // If scoreText is null, no UI will be updated. Assign it in the Inspector.
    }
}