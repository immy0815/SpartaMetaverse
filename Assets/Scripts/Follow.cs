using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;  // ���󰡱� ���
    [SerializeField] bool isLerp;       // �ε巴�� ���󰡰� ����
    [SerializeField] float smoothSpeed = 5f; // �󸶳� �ε巴��?
    private Vector3 offset;             // �� ������Ʈ�� ������

    // �̵� ����
    [SerializeField] Vector2 boundaryMin;
    [SerializeField] Vector2 boundaryMax;

    // SmoothDamp�� �ʿ��� �ӵ�
    private Vector3 velocity = Vector3.zero;


    void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        // ���󰡱�
        Vector3 destination = target.position + offset;

        // ��ġ ���� ����
        destination.x = Mathf.Clamp(destination.x, boundaryMin.x, boundaryMax.x);
        destination.y = Mathf.Clamp(destination.y, boundaryMin.y, boundaryMax.y);
        destination.z = transform.position.z;

        // ���󰡱�
        if (isLerp)
        {
            // �ε巴�� �̵�
            //transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * smoothSpeed);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 1f / smoothSpeed);
        }
        else
        {
            transform.position = destination;

        }
    }
}
