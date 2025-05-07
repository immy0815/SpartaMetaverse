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

    // ���� ����
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

    // ���� ����
    public void GameStart()
    {
        miniUIManager.SetTutorialActive(false);
        SetTimeScale(1);
    }

    // ���� ����
    public void GameOver()
    {
        Debug.Log("Game Over");

        SetBestScore();
        miniUIManager.SetResult(currentScore, GetBestScore());
        SetTimeScale(0);
    }

    // �����
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // �̴ϰ��� ���� �� ����
    public void Exit()
    {
        SetTimeScale(1);
        SceneManager.LoadScene("GameScene");
    }

    // Time Scale ����
    void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }

    // ���� �߰�
    public void AddScore(int score)
    {
        // �־��� score�� currentScore�� ����
        currentScore += score;

        // ���� �α� ��� 
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