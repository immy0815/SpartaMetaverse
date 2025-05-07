using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    // 상호작용 오브젝트 타입  
    enum Type 
    {
        None,
        NPC,
        StartButton
    }

    // 타입 설정
    [SerializeField] Type type;

    // Sprite 변경이 필요한 오브젝트 변수
    [SerializeField] Sprite changeSprite = null;
    [SerializeField] SpriteRenderer spriteRndrr = null;

    // 타입에 상호작용 결과
    public void InteractObj()
    {
        switch (type)
        {
            case Type.NPC:

                break;
            case Type.StartButton:
                StartButton();
                break;

            case Type.None:
            default:
                break;
        }
    }

    // 미니게임 시작 버튼
    void StartButton()
    {
        SceneManager.LoadScene("FlappyPlane");
        spriteRndrr.sprite = changeSprite;

        StartCoroutine(WaitSeconds(1));
    }

    // 설정 시간에 따라 잠시 기다리는 Invoke 느낌
    IEnumerator WaitSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        yield break;
    }
}
