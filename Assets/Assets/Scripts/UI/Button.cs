using UnityEngine;
using UnityEngine.UI;

public class Botton : MonoBehaviour
{
    public int playHandRemaining = 7;
    public int discardsRemaining = 5;

    public Text playHandText;
    public Text discardsText;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        playHandText.text = "remaining: " + playHandRemaining;

        discardsText.text = "remaining: " + discardsRemaining;
    }

    public void PlayHand()
    {
        if (playHandRemaining > 0)
        {
            playHandRemaining--;
            UpdateUI();
            Debug.Log("PlayHand clicked. Remaining: " + playHandRemaining);
        }
        else
        {
            Debug.Log("No Play Hand remaining.");
        }
    }

    public void Discard()
    {
        if (discardsRemaining > 0)
        {
            discardsRemaining--;
            UpdateUI();
            Debug.Log("Discard clicked. Remaining: " + discardsRemaining);
        }

        else
        {
            Debug.Log("No Discards remaining.");
        }
    }
}