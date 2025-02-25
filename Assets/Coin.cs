using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1; // Amount of score to add when collected
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    private void Update()
    {
        // Rotate the coin around its Y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

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