using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image healthFillImage;      // Fill Image ของแถบพลังชีวิต
    public TextMeshProUGUI healthText; // ข้อความแสดงค่าพลังชีวิต

    public int CurrentHealth => currentHealth;

    public int currentHealth;         // พลังชีวิตปัจจุบัน
    private int maxHealth;            // พลังชีวิตสูงสุด

    void Start()
    {
        // กำหนดพลังชีวิตสูงสุดแบบสุ่มในช่วง 2000 ถึง 5000
        maxHealth = Random.Range(1000, 3000);

        // กำหนดค่าเริ่มต้นพลังชีวิต
        currentHealth = maxHealth;

        // ค้นหา GameObjects ใน Scene ถ้ายังไม่ได้อ้างอิง
        if (healthFillImage == null)
        {
            GameObject fillObject = GameObject.Find("FillHP");
            if (fillObject != null)
                healthFillImage = fillObject.GetComponent<Image>();
        }

        if (healthText == null)
        {
            GameObject textObject = GameObject.Find("TextEnemyHPScore");
            if (textObject != null)
                healthText = textObject.GetComponent<TextMeshProUGUI>();
        }

        UpdateHealthUI();
    }

    // ฟังก์ชันอัปเดต UI
    private void UpdateHealthUI()
    {
        if (healthFillImage != null)
            healthFillImage.fillAmount = (float)currentHealth / maxHealth;

        if (healthText != null)
            healthText.text = currentHealth.ToString();
    }

    // ฟังก์ชันลดพลังชีวิต
    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthUI();
    }

    public void Attack(PokerHand.Hand handType)
    {
        int damage = PokerHand.GetDamage(handType);
        ApplyDamage(damage);
        Debug.Log($"Enemy took {damage} damage from {handType}");
    }

    int CalculateDamage(string pokerHand)
    {
        switch (pokerHand)
        {
            case "Royal Flush":
                return 450;
            case "Straight Flush":
                return 400;
            case "Four of a Kind":
                return 350;
            case "Full House":
                return 300;
            case "Flush":
                return 280;
            case "Straight":
                return 250;
            case "Three of a Kind":
                return 200;
            case "Two Pair":
                return 150;
            case "One Pair":
                return 100;
            case "High Card":
                return 50;
            default:
                return 0;
        }
    }
}