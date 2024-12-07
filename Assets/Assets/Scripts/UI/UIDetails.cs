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
        // ซ่อน Panel เมื่อเริ่มต้นเกม
        detailPanel.SetActive(false);

        // ตั้งค่าให้ปุ่มเปิด Panel เมื่อกด
        openPanelButton.onClick.AddListener(OpenPanel);

        // ตั้งค่าให้ปุ่ม Back ปิด Panel เมื่อกด
        backButton.onClick.AddListener(ClosePanel);
    }

    // ฟังก์ชันเปิด Panel
    void OpenPanel()
    {
        detailPanel.SetActive(true);  // แสดง Panel
    }

    // ฟังก์ชันปิด Panel
    void ClosePanel()
    {
        detailPanel.SetActive(false); // ซ่อน Panel
    }
}