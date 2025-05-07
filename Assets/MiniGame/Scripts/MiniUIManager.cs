using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI updateScoreText;
    [SerializeField] GameObject resultPopup;
    [SerializeField] GameObject howtoPopup;
    [SerializeField] TMP_Text resultScoreText;
    [SerializeField] TMP_Text bestScoreText;

    private void Start()
    {
        if(updateScoreText == null)
            Debug.LogError("score text is null"); 
        if(resultPopup == null)
            Debug.LogError("resultPopup is null");

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
