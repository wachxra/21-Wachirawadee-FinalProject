using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int remaining = 7;  // �ӹǹ�����蹡������ͷ�������
    public int enemyHealth = 10;  // �ӹǹ���ʹ�ͧ�ѵ��
    public Text remainingText;  // UI Text ����ʴ��ӹǹ remaining
    public Text gameOverText;   // UI Text ����ʴ���ͤ��� Game Over
    public Button playCardButton;  // ������蹡���

    void Start()
    {
        // ź Listener �����͹��������
        playCardButton.onClick.RemoveAllListeners();
        playCardButton.onClick.AddListener(PlayCard);

        // ��Ѻ UI ��鹵͹�������
        UpdateRemainingUI();
        gameOverText.gameObject.SetActive(false);  // ��͹��ͤ��� Game Over �͹�����
    }

    void PlayCard()
    {
        Debug.Log("PlayCard called");

        // ��Ǩ�ͺ��� remaining �ѧ����������ѵ���ѧ��������ʹ
        if (remaining > 0 && enemyHealth > 0)
        {
            Debug.Log($"Remaining before: {remaining}");
            remaining--;  // Ŵ�ӹǹ remaining ŧ
            UpdateRemainingUI();
            Debug.Log($"Remaining after: {remaining}");

            // ��Ҩӹǹ remaining ��� ����ѵ���ѧ��������ʹ
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
        // �ʴ��ӹǹ remaining � UI Text
        remainingText.text = "Remaining: " + remaining.ToString();
    }

    void GameOver()
    {
        // �ʴ���ͤ��� Game Over
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You Lost!";
    }

    void PlayerWins()
    {
        // �ʴ���ͤ������
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You Win!";
    }
}
