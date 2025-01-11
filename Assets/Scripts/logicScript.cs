using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public Text finalScoreText; // Reference to the final score text

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If pause screen already active, unpause and vice versa
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        finalScoreText.text = "Score:" + playerScore; // Update the final score
    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit(); // Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exits play mode (will only be executed in the editor)
#endif
    }

    public void PauseGame(bool status)
    {
        // If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        // When pause status is true, change timescale to 0 (time stops)
        // When it's false, change it back to 1 (time goes by normally)
        Time.timeScale = status ? 0 : 1;
    }
}
