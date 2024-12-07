using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image healthFillImage;  // ���������Ѻ Fill Image �ͧ���ʹ
    public TextMeshProUGUI healthText;  // ���������Ѻ�ʴ���������Ţ���ʹ

    private int currentHealth;  // ��һѨ�غѹ�ͧ���ʹ�ѵ��
    private int maxHealth = 1000;  // ���ʹ�٧�ش�ͧ�ѵ��

    // Start is called before the first frame update
    void Start()
    {
        // ����������ʹẺ����
        currentHealth = Random.Range(100, maxHealth);

        // ��駤�� Fill Amount ������
        healthFillImage.fillAmount = (float)currentHealth / maxHealth;

        // �ʴ���һѨ�غѹ�ͧ���ʹ� Text
        healthText.text = currentHealth.ToString();
    }

    // �ѧ��ѹŴ���ʹ�ҡ Poker Hand
    public void ApplyPokerHandDamage(PokerHand.Hand hand)
    {
        int damage = PokerHand.GetDamage(hand);

        // Ŵ���ʹ������ damage
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        // ��Ѻ��� Fill Amount ���ç�Ѻ���ʹ
        healthFillImage.fillAmount = (float)currentHealth / maxHealth;

        // �Ѿവ��ҵ���Ţ���ʹ
        healthText.text = currentHealth.ToString();
    }

    // �ѧ��ѹ������Ѻ�������ʹ
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        // ��Ѻ��� Fill Amount ���ç�Ѻ���ʹ
        healthFillImage.fillAmount = (float)currentHealth / maxHealth;

        // �Ѿവ��ҵ���Ţ���ʹ
        healthText.text = currentHealth.ToString();
    }

    float CalculateDamage(string pokerHand)
    {
        switch (pokerHand)
        {
            case "Royal Flush":
                return 100f;  // Royal Flush Ŵ���ʹ 100
            case "Straight Flush":
                return 80f;  // Straight Flush Ŵ���ʹ 80
            case "Four of a Kind":
                return 60f;  // Four of a Kind Ŵ���ʹ 60
            case "Full House":
                return 50f;  // Full House Ŵ���ʹ 50
            case "Flush":
                return 40f;  // Flush Ŵ���ʹ 40
            case "Straight":
                return 30f;  // Straight Ŵ���ʹ 30
            case "Three of a Kind":
                return 20f;  // Three of a Kind Ŵ���ʹ 20
            case "Two Pair":
                return 10f;  // Two Pair Ŵ���ʹ 10
            case "One Pair":
                return 5f;   // One Pair Ŵ���ʹ 5
            case "High Card":
                return 2f;   // High Card Ŵ���ʹ 2
            default:
                return 0f;   // ����մ�����ҡ�����蹡��촷�����١��ͧ
        }
    }
}