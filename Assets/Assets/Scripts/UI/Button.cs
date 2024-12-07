using UnityEngine;
using UnityEngine.UI;

public class Botton : MonoBehaviour
{
    // ���������Ѻ�ӹǹ Play Hand ��� Discards
    public int playHandRemaining = 7; // �ӹǹ Play Hand ��������
    public int discardsRemaining = 5; // �ӹǹ Discards ��������

    // ���������Ѻ UI Text �����ʴ���ҵ�ҧ�
    public Text playHandText;   // Text �����ʴ��ӹǹ Play Hand
    public Text discardsText;   // Text �����ʴ��ӹǹ Discards

    void Start()
    {
        // �ѻവ UI �͹�������
        UpdateUI();
    }

    // �ѧ��ѹ����Ѻ�ѻവ UI ����ͤ�Ңͧ Play Hand ���� Discards ����¹�ŧ
    public void UpdateUI()
    {
        // �ѻവ Text ����ʴ� Play Hand
        playHandText.text = "remaining: " + playHandRemaining;

        // �ѻവ Text ����ʴ� Discards
        discardsText.text = "remaining: " + discardsRemaining;
    }

    // �ѧ��ѹ������¡���������� Hand
    public void PlayHand()
    {
        if (playHandRemaining > 0)
        {
            playHandRemaining--; // Ŵ�ӹǹ Play Hand
            UpdateUI();          // �ѻവ UI
            Debug.Log("PlayHand clicked. Remaining: " + playHandRemaining);
        }
        else
        {
            Debug.Log("No Play Hand remaining.");
        }
    }

    // �ѧ��ѹ������¡������� Discard
    public void Discard()
    {
        if (discardsRemaining > 0)
        {
            discardsRemaining--; // Ŵ�ӹǹ Discards
            UpdateUI();          // �ѻവ UI
            Debug.Log("Discard clicked. Remaining: " + discardsRemaining);
        }
        else
        {
            Debug.Log("No Discards remaining.");
        }
    }
}
