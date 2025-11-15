using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [Header("Game Over Settings")]
    public GameObject gameOverUI; // Canvas з Game Over меню

    private bool isGameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ball collision with " + collision.gameObject.name);

        // Якщо м'яч торкається Plane — Game Over
        if (!isGameOver && collision.gameObject.name == "Plane")
        {
            GameOver();
        }

        // Якщо м'яч торкається Target — перехід на наступну сцену
        if (collision.gameObject.CompareTag("Target"))
        {
            NextLevel();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // зупиняємо час
        gameOverUI.SetActive(true); // показуємо меню
        Debug.Log("GAME OVER!");
    }

    private void NextLevel()
    {
        Debug.Log("Ball hit the Target! Loading next scene...");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // якщо це остання сцена — повертаємось на першу
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    // Викликається кнопкою Restart
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
