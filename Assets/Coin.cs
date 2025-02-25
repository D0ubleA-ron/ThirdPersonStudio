using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1; // Amount of score to add when collected

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Add to the score
            ScoreManager.Instance.AddScore(scoreValue);

            // Remove the coin from the scene
            Destroy(gameObject);
        }
    }
}