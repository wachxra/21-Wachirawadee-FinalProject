using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDetails : MonoBehaviour
{
    public GameObject detailPanel;
    public Button openPanelButton;
    public Button backButton;

    void Start()
    {
        detailPanel.SetActive(false);

        openPanelButton.onClick.AddListener(OpenPanel);

        backButton.onClick.AddListener(ClosePanel);
    }

    void OpenPanel()
    {
        detailPanel.SetActive(true);
    }

    void ClosePanel()
    {
        detailPanel.SetActive(false);
    }
}