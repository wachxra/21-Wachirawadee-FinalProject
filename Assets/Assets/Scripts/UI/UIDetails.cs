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
        // ��͹ Panel ��������������
        detailPanel.SetActive(false);

        // ��駤���������Դ Panel ����͡�
        openPanelButton.onClick.AddListener(OpenPanel);

        // ��駤�������� Back �Դ Panel ����͡�
        backButton.onClick.AddListener(ClosePanel);
    }

    // �ѧ��ѹ�Դ Panel
    void OpenPanel()
    {
        detailPanel.SetActive(true);  // �ʴ� Panel
    }

    // �ѧ��ѹ�Դ Panel
    void ClosePanel()
    {
        detailPanel.SetActive(false); // ��͹ Panel
    }
}