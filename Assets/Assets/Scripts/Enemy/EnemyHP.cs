using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image healthFillImage;      // Fill Image �ͧᶺ��ѧ���Ե
    public TextMeshProUGUI healthText; // ��ͤ����ʴ���Ҿ�ѧ���Ե

    public int CurrentHealth => currentHealth;

    public int currentHealth;         // ��ѧ���Ե�Ѩ�غѹ
    private int maxHealth;            // ��ѧ���Ե�٧�ش

    void Start()
    {
        // ��˹���ѧ���Ե�٧�شẺ����㹪�ǧ 2000 �֧ 5000
        maxHealth = Random.Range(1000, 3000);

        // ��˹����������鹾�ѧ���Ե
        currentHealth = maxHealth;

        // ���� GameObjects � Scene ����ѧ�������ҧ�ԧ
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

    // �ѧ��ѹ�ѻവ UI
    private void UpdateHealthUI()
    {
        if (healthFillImage != null)
            healthFillImage.fillAmount = (float)currentHealth / maxHealth;

        if (healthText != null)
            healthText.text = currentHealth.ToString();
    }

    // �ѧ��ѹŴ��ѧ���Ե
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