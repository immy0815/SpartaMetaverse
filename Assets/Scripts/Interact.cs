using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    // ��ȣ�ۿ� ������Ʈ Ÿ��  
    enum Type 
    {
        None,
        NPC,
        StartButton
    }

    // Ÿ�� ����
    [SerializeField] Type type;

    // Sprite ������ �ʿ��� ������Ʈ ����
    [SerializeField] Sprite changeSprite = null;
    [SerializeField] SpriteRenderer spriteRndrr = null;

    // Ÿ�Կ� ��ȣ�ۿ� ���
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

    // �̴ϰ��� ���� ��ư
    void StartButton()
    {
        SceneManager.LoadScene("FlappyPlane");
        spriteRndrr.sprite = changeSprite;

        StartCoroutine(WaitSeconds(1));
    }

    // ���� �ð��� ���� ��� ��ٸ��� Invoke ����
    IEnumerator WaitSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        yield break;
    }
}
