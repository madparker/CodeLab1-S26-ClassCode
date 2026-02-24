using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    //prefab in Unity for a wall gameObject
    public GameObject wall;
    public GameObject player;
    public GameObject goal;
    public GameObject obstacle;

    public string fileLocation;

    string fullPath; //the full pather to the current level file
    
    int currentLevel = 0;

    GameObject loadedLevel;

    public int CurrentLevel
    {
        set
        {
            currentLevel = value;
            LoadLevel();
        }
        get
        {
            return currentLevel;
        }
    }

    //offset for the origin of the level
    public int xOffset = 5;
    public int yOffset = 4;
    
    public static ASCIILevelLoader instance;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //creating the full path to the file location
        fullPath = Application.dataPath + "/" + fileLocation;
        
        //Pulls information from the file to create a new level based on file contents
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Load the ASCII level
    public void LoadLevel()
    {
        //Destroy the old container for the level objects and create a new one
        Destroy(loadedLevel);
        loadedLevel = new GameObject("Level " + currentLevel);
        
        //replace "<num>" with the currentLevel
        string fullPath = this.fullPath.Replace("<num>", currentLevel + "");
        
        //Read the file, put each line into a slot of the "lines" string array
        string[] lines = File.ReadAllLines(fullPath);

        //display what's in the file
        foreach (string line in lines) //go through evey element in an Array
        {
            Debug.Log(line);
            
            //check to see how long the offset for this line should be
            int lengthOfLine = line.Length/2; 

            //if the offset for this line is greater than the current offset
            //replace the current offset with this one
            if (lengthOfLine > xOffset)
            {
                xOffset = lengthOfLine; //offset x by the length of the string on the first line
            }
        }

        yOffset = lines.Length / 2; //offset y based on how many lines there are in the file
        
        //loop through all the lines in the file
        for (int y = 0; y < lines.Length; y++) //y determines the y position in world
        {
            string currentLineFromFile = lines[y];
            //look at every character on each line
            for (int x = 0; x < currentLineFromFile.Length; x++) //x determines the x position in world
            {
                char currentChar = currentLineFromFile[x]; //get the character on from this line at x

                GameObject newObject = null;
                
                switch (currentChar)
                {
                    case 'W':  
                        //create a wall prefab
                        newObject = Instantiate<GameObject>(wall);
                        break;
                    case 'P':
                        newObject = Instantiate<GameObject>(player);
                        break;
                    case 'G':
                        newObject = Instantiate<GameObject>(goal);
                        break;
                    case 'O':
                        newObject = Instantiate<GameObject>(obstacle);
                        break;
                    default:
                        break;
                }

                if (newObject != null)
                {
                    //position it based on the it's position in the file
                    newObject.transform.position = new Vector2(-xOffset + x, yOffset - y);
                    newObject.transform.SetParent(loadedLevel.transform);
                }

                //create a new gameObject based on the character at the position in the file
                // if (currentChar == 'W') //if I see a 'W' I make a wall
                // {
                //     //create a wall prefab
                //     GameObject newWall = Instantiate<GameObject>(wall);
                //     //position it based on the it's position in the file
                //     newWall.transform.position = new Vector2(-xOffset + x, yOffset - y);
                // }
                //
                // if (currentChar == 'P')
                // {
                //     GameObject newPlayer = Instantiate<GameObject>(player);
                //     newPlayer.transform.position = new Vector2(-xOffset + x, yOffset - y);
                // }
            }
        }

    }
}
