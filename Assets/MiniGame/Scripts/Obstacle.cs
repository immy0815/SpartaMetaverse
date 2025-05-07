using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    MiniGameManager gameManager; // GameManager �ν��Ͻ��� ������ ����

    public float highPosY = 1f; // ��ֹ��� ��ġ�� �� �ִ� Y�� ���Ѽ�
    public float lowPosY = -1f; // ��ֹ��� ��ġ�� �� �ִ� Y�� ���Ѽ�

    public float holeSizeMin = 1f; // ������ �ּ� ũ��
    public float holeSizeMax = 3f; // ������ �ִ� ũ��

    public Transform topObject; // ��ֹ� ��� ������Ʈ (�� ��ü�� ���� ��ġ)
    public Transform bottomObject; // ��ֹ� �ϴ� ������Ʈ (�� ��ü�� �Ʒ��� ��ġ)

    public float widthPadding = 4f; // �� ��ֹ� ���� X�� ���� (�ʺ� �е�)

    public void Start()
    {
        // ���� ���� �� GameManager�� �ν��Ͻ��� �����ͼ� ���
        gameManager = MiniGameManager.Instance;
    }

    // ��ֹ��� ���� ��ġ�� ��ġ�ϴ� �Լ�
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        // ���� ũ�� ���� ���� (min ~ max ���� ������)
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        // ���� ũ�⸦ ������ ������ ��ܰ� �ϴ� ��ü�� Y ��ġ ����
        float halfHoleSize = holeSize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize); // ��� ��ü�� ��ġ
        bottomObject.localPosition = new Vector3(0, -halfHoleSize); // �ϴ� ��ü�� ��ġ

        // ������ ��ġ���� X������ ������ ���� ���ο� ��ġ ���
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        // ���ο� ��ġ�� Y���� ���� ������ ���� (lowPosY�� highPosY ����)
        placePosition.y = Random.Range(lowPosY, highPosY);

        // ��ֹ��� ��ġ�� ���ο� ��ġ�� ����
        transform.position = placePosition;

        // ���� ������ ��ġ�� ��ȯ
        return placePosition;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        // �浹�� ��ü�� �÷��̾����� Ȯ��
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(1); // ���� �Ŵ����� ���� ���� 1 ����
        }
    }
}