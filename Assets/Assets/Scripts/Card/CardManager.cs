using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnemyHP enemyStats; // สคริปต์ศัตรูที่เก็บค่า HP
    public int remaining = 7;  // จำนวนครั้งที่เหลือ (ใช้สำหรับ Play Hand)
    public int discardRemaining = 5; // จำนวน Discards ที่เหลือ
    public Text remainingText;  // UI แสดงจำนวน remaining (Play Hand)
    public Text discardText;    // UI แสดงจำนวน discardRemaining
    public Text gameOverText;   // UI แสดงข้อความ Game Over
    public Button playHandButton;  // ปุ่ม Play Hand
    public Button discardButton;   // ปุ่ม Discard

    private int enemyHealth; // ค่าเลือดศัตรู

    void Start()
    {
        // ตรวจสอบการอ้างอิง
        if (enemyStats == null || playHandButton == null || discardButton == null || remainingText == null || gameOverText == null || discardText == null)
        {
            Debug.LogError("Missing references! Please ensure all UI elements and scripts are assigned in the Inspector.");
            return;
        }

        // ดึงค่าเลือดจาก EnemyStats
        enemyHealth = enemyStats.currentHealth;
        Debug.Log("Initial Enemy Health: " + enemyHealth);

        // กำหนดฟังก์ชันให้ปุ่มแต่ละปุ่ม
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

        // อัปเดต UI เริ่มต้น
        UpdateUI();
        gameOverText.gameObject.SetActive(false);  // ซ่อนข้อความ Game Over ตอนเริ่ม
    }

    void PlayHand()
    {
        if (remaining > 0)
        {
            remaining--;  // ลด remaining ลง 1
            UpdateUI();  // อัปเดต UI

            // ลดเลือดศัตรูเป็นตัวอย่าง
            int damage = Random.Range(1, 4); // สุ่มค่าความเสียหาย 1-3
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
            discardRemaining--;  // ลด discardRemaining ลง 1
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
        // อัปเดต UI แสดงจำนวน remaining (Play Hand)
        remainingText.text = "Remaining: " + remaining.ToString();

        // อัปเดต UI แสดงจำนวน discardRemaining (เฉพาะ Discard)
        discardText.text = "Remaining: " + discardRemaining.ToString();

        remainingText.fontSize = 25;
        discardText.fontSize = 25;
    }

    void CheckGameOver()
    {
        // หาก remaining หมดและศัตรูยังเหลือเลือด
        if (remaining == 0 && enemyHealth > 0)
        {
            GameOver();
        }
        // หากศัตรูเลือดหมด
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
