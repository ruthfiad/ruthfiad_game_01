using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Called when this object collides with another
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log ("Ball collision width " + collision.gameObject.name);

        // Check if the collided object has the "Target" tag
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Ball hit the Target!");
            Debug.Log("Loading next scene...");

            // Get current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Calculate next scene index
            int nextSceneIndex = currentSceneIndex + 1;

            // If the last scene is reached, restart from the first one
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }

            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    // (Optional) debug shortcut — press Space to skip to the next level manually
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Manual level skip");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
