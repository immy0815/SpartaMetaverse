using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject howtoPopup; // 게임 방법 팝업 (튜토리얼)

    private void Start()
    {
        // 게임 방법 팝업 미리 꺼두기 
        howtoPopup.SetActive(false);
    }

    // 방법 팝업 버튼 OnClick
    public void SetHowToActive()
    {
        howtoPopup.SetActive(!howtoPopup.activeSelf);
    }
}
