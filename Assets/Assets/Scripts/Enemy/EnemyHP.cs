using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image healthFillImage;  // ตัวแปรสำหรับ Fill Image ของเลือด
    public TextMeshProUGUI healthText;  // ตัวแปรสำหรับแสดงค่าหมายเลขเลือด

    private int currentHealth;  // ค่าปัจจุบันของเลือดศัตรู
    private int maxHealth = 1000;  // เลือดสูงสุดของศัตรู

    // Start is called before the first frame update
    void Start()
    {
        // เริ่มต้นเลือดแบบสุ่ม
        currentHealth = Random.Range(100, maxHealth);

        // ตั้งค่า Fill Amount ให้เต็ม
        healthFillImage.fillAmount = (float)currentHealth / maxHealth;

        // แสดงค่าปัจจุบันของเลือดใน Text
        healthText.text = currentHealth.ToString();
    }

    // ฟังก์ชันลดเลือดจาก Poker Hand
    public void ApplyPokerHandDamage(PokerHand.Hand hand)
    {
        int damage = PokerHand.GetDamage(hand);

        // ลดเลือดตามค่า damage
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        // ปรับค่า Fill Amount ให้ตรงกับเลือด
        healthFillImage.fillAmount = (float)currentHealth / maxHealth;

        // อัพเดตค่าตัวเลขเลือด
        healthText.text = currentHealth.ToString();
    }

    // ฟังก์ชันใช้สำหรับเพิ่มเลือด
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        // ปรับค่า Fill Amount ให้ตรงกับเลือด
        healthFillImage.fillAmount = (float)currentHealth / maxHealth;

        // อัพเดตค่าตัวเลขเลือด
        healthText.text = currentHealth.ToString();
    }

    float CalculateDamage(string pokerHand)
    {
        switch (pokerHand)
        {
            case "Royal Flush":
                return 100f;  // Royal Flush ลดเลือด 100
            case "Straight Flush":
                return 80f;  // Straight Flush ลดเลือด 80
            case "Four of a Kind":
                return 60f;  // Four of a Kind ลดเลือด 60
            case "Full House":
                return 50f;  // Full House ลดเลือด 50
            case "Flush":
                return 40f;  // Flush ลดเลือด 40
            case "Straight":
                return 30f;  // Straight ลดเลือด 30
            case "Three of a Kind":
                return 20f;  // Three of a Kind ลดเลือด 20
            case "Two Pair":
                return 10f;  // Two Pair ลดเลือด 10
            case "One Pair":
                return 5f;   // One Pair ลดเลือด 5
            case "High Card":
                return 2f;   // High Card ลดเลือด 2
            default:
                return 0f;   // ไม่มีดาเมจจากการเล่นการ์ดที่ไม่ถูกต้อง
        }
    }
}