using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject howtoPopup; // ���� ��� �˾� (Ʃ�丮��)

    private void Start()
    {
        // ���� ��� �˾� �̸� ���α� 
        howtoPopup.SetActive(false);
    }

    // ��� �˾� ��ư OnClick
    public void SetHowToActive()
    {
        howtoPopup.SetActive(!howtoPopup.activeSelf);
    }
}
