using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnemyHP enemyStats; // ʤ�Ի���ѵ�ٷ���纤�� HP
    public int remaining = 7;  // �ӹǹ���駷������� (������Ѻ Play Hand)
    public int discardRemaining = 5; // �ӹǹ Discards ��������
    public Text remainingText;  // UI �ʴ��ӹǹ remaining (Play Hand)
    public Text discardText;    // UI �ʴ��ӹǹ discardRemaining
    public Text gameOverText;   // UI �ʴ���ͤ��� Game Over
    public Button playHandButton;  // ���� Play Hand
    public Button discardButton;   // ���� Discard

    private int enemyHealth; // ������ʹ�ѵ��

    void Start()
    {
        // ��Ǩ�ͺ�����ҧ�ԧ
        if (enemyStats == null || playHandButton == null || discardButton == null || remainingText == null || gameOverText == null || discardText == null)
        {
            Debug.LogError("Missing references! Please ensure all UI elements and scripts are assigned in the Inspector.");
            return;
        }

        // �֧������ʹ�ҡ EnemyStats
        enemyHealth = enemyStats.currentHealth;
        Debug.Log("Initial Enemy Health: " + enemyHealth);

        // ��˹��ѧ��ѹ���������л���
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

        // �ѻവ UI �������
        UpdateUI();
        gameOverText.gameObject.SetActive(false);  // ��͹��ͤ��� Game Over �͹�����
    }

    void PlayHand()
    {
        if (remaining > 0)
        {
            remaining--;  // Ŵ remaining ŧ 1
            UpdateUI();  // �ѻവ UI

            // Ŵ���ʹ�ѵ���繵�����ҧ
            int damage = Random.Range(1, 4); // ������Ҥ���������� 1-3
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
            discardRemaining--;  // Ŵ discardRemaining ŧ 1
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
        // �ѻവ UI �ʴ��ӹǹ remaining (Play Hand)
        remainingText.text = "Remaining: " + remaining.ToString();

        // �ѻവ UI �ʴ��ӹǹ discardRemaining (੾�� Discard)
        discardText.text = "Remaining: " + discardRemaining.ToString();

        remainingText.fontSize = 25;
        discardText.fontSize = 25;
    }

    void CheckGameOver()
    {
        // �ҡ remaining �������ѵ���ѧ��������ʹ
        if (remaining == 0 && enemyHealth > 0)
        {
            GameOver();
        }
        // �ҡ�ѵ�����ʹ���
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
