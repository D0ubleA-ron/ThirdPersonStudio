using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance

    private int score = 0; // Current score

    private void Awake()
    {
        // Set up the singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to add to the score
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score); // Display the score in the console
    }

    // Method to get the current score
    public int GetScore()
    {
        return score;
    }
}