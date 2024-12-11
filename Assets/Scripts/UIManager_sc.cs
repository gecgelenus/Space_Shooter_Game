using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class UIManager_sc : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    private int score = 0; 

    public Image livesImage; 
    public Sprite threeLivesSprite; 
    public Sprite twoLivesSprite; 
    public Sprite oneLifeSprite; 
    public Sprite noLivesSprite; 

    public TextMeshProUGUI gameOverText; 
    public TextMeshProUGUI gameOverRestartText; 
    private bool isGameOver = false; 

    void Start(){UpdateScore(0); HideGameOver();}

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score; 
    }

    public void UpdateLivesUI(int lives)
    {
        if (lives == 3) livesImage.sprite = threeLivesSprite;
        else if (lives == 2) livesImage.sprite = twoLivesSprite;
        else if (lives == 1) livesImage.sprite = oneLifeSprite;
        else if (lives <= 0)
        {
            livesImage.sprite = noLivesSprite;
            ShowGameOver(); 
        }
    }

    public void ShowGameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true); 
        gameOverRestartText.gameObject.SetActive(true); 
        Time.timeScale = 0f; 
        StartCoroutine(FlickerGameOverText()); 
    }

    public void HideGameOver()
    {
        gameOverText.gameObject.SetActive(false); 
        gameOverRestartText.gameObject.SetActive(false); 
    }

    private IEnumerator FlickerGameOverText()
    {
        while (true)
        {
            gameOverText.gameObject.SetActive(true); 
            yield return new WaitForSecondsRealtime(0.5f); 
        }
    }

    public void RestartGame()
    {Time.timeScale = 1f; SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
