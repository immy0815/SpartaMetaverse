using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI updateScoreText;   // �ǽð� ���� �ؽ�Ʈ
    [SerializeField] GameObject resultPopup;            // ���� ��� �˾�
    [SerializeField] GameObject howtoPopup;             // ���� ��� �˾� (Ʃ�丮��)
    [SerializeField] TMP_Text resultScoreText;          // ���� ���ھ� �ؽ�Ʈ (���â)
    [SerializeField] TMP_Text bestScoreText;            // �ְ� ���ھ� �ؽ�Ʈ (���â)

    private void Start()
    {
        // ���̾��Ű ���� �ȳ�
        if(updateScoreText == null)
            Debug.LogError("score text is null"); 
        if(resultPopup == null)
            Debug.LogError("resultPopup is null");

        // ��� �˾� �̸� ���α�
        resultPopup.gameObject.SetActive(false);
    }

    // ���� ���� On/Off
    public void SetTutorialActive(bool active)
    {
        howtoPopup.gameObject.SetActive(active);
    }

    // ���â On
    public void SetResult(int curScore, int bestScore)
    {
        resultPopup.gameObject.SetActive(true);
        resultScoreText.text = curScore.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    // ���� ������Ʈ
    public void UpdateScore(int score)
    {
        updateScoreText.text = score.ToString();
    }
}
