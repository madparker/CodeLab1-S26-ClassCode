using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject timerTextObject; //the gameObject with the timer text

    TextMeshPro textMeshComponent; //Timer dislay
    
    public static GameManager instance; //Singleton

    float time = 0; //keeps track of how much time has ellapsed

    public int gameTime = 5; //when the game ends
    
    private int score = 0; //private var for score
    
    public int Score //property for score
    {
        set
        {
            score = value;
        }

        get
        {
            return score;
        }
    }
    
    bool isGameOver = false; //is the game over yet

    List<int> highScores; //List for highScores

    //create a basic property for score
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TODO: This is not a real todo item, just put it here as an example
        
        textMeshComponent = timerTextObject.GetComponent<TextMeshPro>(); //get text displays
        
        //Singleton Code
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        //calls IncreaseTime function in 1 second and then repeatedly every 1 second
        InvokeRepeating("IncreaseTime", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //time  += Time.deltaTime;
        
        textMeshComponent.SetText("Time: " + Math.Floor(time)); //set the timer display
        
        if(time >= gameTime) { //is the timer up?
            Debug.Log("Game Over");

            if (!isGameOver) //is this our first time here?
            {
                UpdateHighScores(); //Update the High Scores file
            }

            isGameOver = true; //flip this flag so we don't save to the file over and over
        }
    }

    //function used by invoke to increase time
    void IncreaseTime()
    {
        time++;
        //if you just want to use Invoke to repeatedly call something
        //Invoke ("IncreaseTime", 1f);
    }

    //updates the high scores list and saves it in the file
    void UpdateHighScores()
    {
        //the path to the high scores file
        string filePath = Application.dataPath + "/Resources/HighScores.txt";
        
        
        if (highScores == null) //we don't have the high scores
        {
            highScores = new List<int>();    

            //if the file does not exist
            if (!File.Exists(filePath))
            {
                //add some default values
                //(var to change over time; do we stay in the loop; what to change with each loop
                for (int i = 0; i < 10; i++)
                {
                    highScores.Add(i * 10);
                }
            }
            else
            {
                //read value from the file and put them into the list
                string scores = File.ReadAllText(filePath);
                
                string[] scoresArray = scores.Split(",");

                for (int i = 0; i < scoresArray.Length; i++)
                {
                    Debug.Log("Parse: " + scoresArray[i]);

                    try //try to do some code that might produce an exception
                    {
                        highScores.Add(int.Parse(scoresArray[i]));
                    } 
                    catch (FormatException fe){ //if this exception occurs, run the code below
                        Debug.Log(fe.Message);
                        Debug.Log(fe.StackTrace);
                    }
                }
            }
        }
        
        //check to see if I have a new high score
        
        
        //compare score to each part of the list
        for (int i = 0; i < highScores.Count; i++)
        {
            if (highScores[i] > score)
            {
                
                //put the new high score in the list
                //insert high score into list at this point
                highScores.Insert(i, score);
                break;
            }
        }

        //remove the high score that is no longer in the list
        highScores.RemoveAt(0);
        
        //save new high scores
        string fileContents = "";
        
        //go through every high score in the list and
        //make it a string and add it to fileContents
        //with a delimiter
        for (int i = 0; i < highScores.Count; i++)
        {
            fileContents += highScores[i] + ","; //or "|"
        }

        File.WriteAllText(filePath, fileContents);
    }
}
