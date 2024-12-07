using UnityEngine;
using UnityEngine.UI;

public class Botton : MonoBehaviour
{
    // ตัวแปรสำหรับจำนวน Play Hand และ Discards
    public int playHandRemaining = 7; // จำนวน Play Hand ที่เหลือ
    public int discardsRemaining = 5; // จำนวน Discards ที่เหลือ

    // ตัวแปรสำหรับ UI Text ที่จะแสดงค่าต่างๆ
    public Text playHandText;   // Text ที่จะแสดงจำนวน Play Hand
    public Text discardsText;   // Text ที่จะแสดงจำนวน Discards

    void Start()
    {
        // อัปเดต UI ตอนเริ่มต้น
        UpdateUI();
    }

    // ฟังก์ชันสำหรับอัปเดต UI เมื่อค่าของ Play Hand หรือ Discards เปลี่ยนแปลง
    public void UpdateUI()
    {
        // อัปเดต Text ที่แสดง Play Hand
        playHandText.text = "remaining: " + playHandRemaining;

        // อัปเดต Text ที่แสดง Discards
        discardsText.text = "remaining: " + discardsRemaining;
    }

    // ฟังก์ชันที่เรียกใช้เมื่อเล่น Hand
    public void PlayHand()
    {
        if (playHandRemaining > 0)
        {
            playHandRemaining--; // ลดจำนวน Play Hand
            UpdateUI();          // อัปเดต UI
            Debug.Log("PlayHand clicked. Remaining: " + playHandRemaining);
        }
        else
        {
            Debug.Log("No Play Hand remaining.");
        }
    }

    // ฟังก์ชันที่เรียกใช้เมื่อ Discard
    public void Discard()
    {
        if (discardsRemaining > 0)
        {
            discardsRemaining--; // ลดจำนวน Discards
            UpdateUI();          // อัปเดต UI
            Debug.Log("Discard clicked. Remaining: " + discardsRemaining);
        }
        else
        {
            Debug.Log("No Discards remaining.");
        }
    }
}
