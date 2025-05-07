using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    static MiniGameManager miniGameManager;
    public static MiniGameManager Instance { get { return miniGameManager; } }

    MiniUIManager miniUIManager;
    public MiniUIManager MiniUManager { get { return miniUIManager; } }

    // 현재 점수
    private int currentScore = 0;

    private void Awake()
    {
        miniGameManager = this;
        miniUIManager = FindObjectOfType<MiniUIManager>();
    }

    private void Start()
    {
        SetTimeScale(0);
        miniUIManager.UpdateScore(0);
        miniUIManager.SetTutorialActive(true);
    }

    // 게임 시작
    public void GameStart()
    {
        miniUIManager.SetTutorialActive(false);
        SetTimeScale(1);
    }

    // 게임 오버
    public void GameOver()
    {
        Debug.Log("Game Over");

        SetBestScore();
        miniUIManager.SetResult(currentScore, GetBestScore());
        SetTimeScale(0);
    }

    // 재시작
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 미니게임 종료 후 복귀
    public void Exit()
    {
        SetTimeScale(1);
        SceneManager.LoadScene("GameScene");
    }

    // Time Scale 조정
    void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }

    // 점수 추가
    public void AddScore(int score)
    {
        // 주어진 score를 currentScore에 더함
        currentScore += score;

        // 점수 로그 출력 
        Debug.Log("Score: " + currentScore);
        miniUIManager.UpdateScore(currentScore);
    }

    public void SetBestScore()
    {
        if (GetBestScore() < currentScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            PlayerPrefs.Save();
        }
    }

    int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore");
    }
}