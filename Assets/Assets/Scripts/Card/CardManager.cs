using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnemyHP enemyStats;
    public int remaining = 7;
    public int discardRemaining = 5;
    public Text remainingText;
    public Text discardText;
    public Text gameOverText;
    public Button playHandButton;
    public Button discardButton;

    private int enemyHealth;

    void Start()
    {
        if (enemyStats == null || playHandButton == null || discardButton == null || remainingText == null || gameOverText == null || discardText == null)
        {
            Debug.LogError("Missing references! Please ensure all UI elements and scripts are assigned in the Inspector.");
            return;
        }

        enemyHealth = enemyStats.currentHealth;
        Debug.Log("Initial Enemy Health: " + enemyHealth);

        playHandButton.onClick.RemoveAllListeners();
        playHandButton.onClick.AddListener(() =>
        {
            Debug.Log("Play Hand button clicked");
            PlayHand();
        });

        discardButton.onClick.RemoveAllListeners();
        discardButton.onClick.AddListener(() =>
        {
            Debug.Log("Discard button clicked");
            Discard();
        });

        UpdateUI();
        gameOverText.gameObject.SetActive(false);
    }

    void PlayHand()
    {
        if (remaining > 0)
        {
            remaining--;
            UpdateUI();

            int damage = Random.Range(1, 4);
            enemyHealth -= damage;
            Debug.Log($"Enemy Health after Play Hand: {enemyHealth}, Damage: {damage}");

            CheckGameOver();
        }
        else
        {
            Debug.Log("No remaining actions for Play Hand.");
        }
    }

    void Discard()
    {
        if (discardRemaining > 0)
        {
            discardRemaining--;
            UpdateUI();

            Debug.Log("Discard action used.");
            CheckGameOver();
        }
        else
        {
            Debug.Log("No remaining actions for Discard.");
        }
    }

    void UpdateUI()
    {
        remainingText.text = "Remaining: " + remaining.ToString();

        discardText.text = "Remaining: " + discardRemaining.ToString();

        remainingText.fontSize = 25;
        discardText.fontSize = 25;
    }

    void CheckGameOver()
    {
        if (remaining == 0 && enemyHealth > 0)
        {
            GameOver();
        }

        else if (enemyHealth <= 0)
        {
            PlayerWins();
        }
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You Lost!";
    }

    void PlayerWins()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You Win!";
    }
}