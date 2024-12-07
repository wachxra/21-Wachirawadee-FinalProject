using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int remaining = 7;  // จำนวนการเล่นการ์ดในมือที่เหลือ
    public int enemyHealth = 10;  // จำนวนเลือดของศัตรู
    public Text remainingText;  // UI Text ที่แสดงจำนวน remaining
    public Text gameOverText;   // UI Text ที่แสดงข้อความ Game Over
    public Button playCardButton;  // ปุ่มเล่นการ์ด

    void Start()
    {
        // ลบ Listener เดิมก่อนเพิ่มใหม่
        playCardButton.onClick.RemoveAllListeners();
        playCardButton.onClick.AddListener(PlayCard);

        // ปรับ UI ขึ้นตอนเริ่มเกม
        UpdateRemainingUI();
        gameOverText.gameObject.SetActive(false);  // ซ่อนข้อความ Game Over ตอนเริ่ม
    }

    void PlayCard()
    {
        Debug.Log("PlayCard called");

        // ตรวจสอบว่า remaining ยังไม่หมดและศัตรูยังเหลือเลือด
        if (remaining > 0 && enemyHealth > 0)
        {
            Debug.Log($"Remaining before: {remaining}");
            remaining--;  // ลดจำนวน remaining ลง
            UpdateRemainingUI();
            Debug.Log($"Remaining after: {remaining}");

            // ถ้าจำนวน remaining หมด และศัตรูยังเหลือเลือด
            if (remaining == 0 && enemyHealth > 0)
            {
                GameOver();
            }
            else if (remaining >= 0 && enemyHealth <= 0)
            {
                PlayerWins();
            }
        }
    }

    void UpdateRemainingUI()
    {
        // แสดงจำนวน remaining ใน UI Text
        remainingText.text = "Remaining: " + remaining.ToString();
    }

    void GameOver()
    {
        // แสดงข้อความ Game Over
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You Lost!";
    }

    void PlayerWins()
    {
        // แสดงข้อความชนะ
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You Win!";
    }
}
