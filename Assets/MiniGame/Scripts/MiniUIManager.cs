using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI updateScoreText;   // 실시간 점수 텍스트
    [SerializeField] GameObject resultPopup;            // 게임 결과 팝업
    [SerializeField] GameObject howtoPopup;             // 게임 방법 팝업 (튜토리얼)
    [SerializeField] TMP_Text resultScoreText;          // 최종 스코어 텍스트 (결과창)
    [SerializeField] TMP_Text bestScoreText;            // 최고 스코어 텍스트 (결과창)

    private void Start()
    {
        // 하이어라키 연결 안내
        if(updateScoreText == null)
            Debug.LogError("score text is null"); 
        if(resultPopup == null)
            Debug.LogError("resultPopup is null");

        // 결과 팝업 미리 꺼두기
        resultPopup.gameObject.SetActive(false);
    }

    // 게임 설명 On/Off
    public void SetTutorialActive(bool active)
    {
        howtoPopup.gameObject.SetActive(active);
    }

    // 결과창 On
    public void SetResult(int curScore, int bestScore)
    {
        resultPopup.gameObject.SetActive(true);
        resultScoreText.text = curScore.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    // 점수 업데이트
    public void UpdateScore(int score)
    {
        updateScoreText.text = score.ToString();
    }
}
