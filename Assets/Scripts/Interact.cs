using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    enum Type
    {
        None,
        NPC,
        StartButton
    }

    [SerializeField] Type type;
    [SerializeField] Sprite changeSprite = null;
    [SerializeField] SpriteRenderer spriteRndrr = null;

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

    void StartButton()
    {
        SceneManager.LoadScene("FlappyPlane");
        spriteRndrr.sprite = changeSprite;

        StartCoroutine(WaitSeconds(1));
    }

    IEnumerator WaitSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        yield break;
    }
}
