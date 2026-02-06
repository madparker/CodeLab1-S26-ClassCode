using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages score, level progression and persists across scenes.
/// Attach to a GameObject and assign `scoreText` in the Inspector.
/// </summary>
public class GameManager : MonoBehaviour
{
    // Current player score (can be modified by other scripts)
    public int score = 0;

    // Score required to advance to the next level
    public int targetScore = 3;

    // Current level / scene index
    public int currentLevel = 0;

    // Singleton instance so the GameManager persists and is globally accessible
    public static GameManager instance;

    // Reference to a TextMeshPro UI element that displays score and target
    // Must be assigned in the Inspector to avoid a null reference at runtime
    public TMP_Text scoreText;

    // Template string used to format the displayed score and target
    string defaultScoreText = "Score: <score> Target: <target>";

    // Start is called once before the first frame update
    void Start()
    {
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
    {
        // Build the display string from the template
        string updatedScoreText = defaultScoreText;

        // Replace placeholders with current values
        updatedScoreText = updatedScoreText.Replace("<score>", score + "");
        updatedScoreText = updatedScoreText.Replace("<target>", targetScore + "");

        // Update the UI text if assigned (avoid null reference)
        if (scoreText != null)
        {
            scoreText.text = updatedScoreText;
        }
        // If scoreText is null, no UI will be updated. Assign it in the Inspector.

        // Check if player reached or exceeded the target score
        if (score >= targetScore)
        {
            // Advance to the next level (increment scene index)
            currentLevel++;

            // Increase the target for the next level (example: double it)
            targetScore = targetScore * 2;

            // Load the scene with the new index
            SceneManager.LoadScene(currentLevel);
        }
    }
}