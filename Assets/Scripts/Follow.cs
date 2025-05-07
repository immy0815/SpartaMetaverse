using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;  // 따라가기 대상
    [SerializeField] bool isLerp;       // 부드럽게 따라가게 할지
    [SerializeField] float smoothSpeed = 5f; // 얼마나 부드럽게?
    private Vector3 offset;             // 이 오브젝트의 오프셋

    // 이동 제한
    [SerializeField] Vector2 boundaryMin;
    [SerializeField] Vector2 boundaryMax;

    // SmoothDamp에 필요한 속도
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
        // 따라가기
        Vector3 destination = target.position + offset;

        // 위치 제한 적용
        destination.x = Mathf.Clamp(destination.x, boundaryMin.x, boundaryMax.x);
        destination.y = Mathf.Clamp(destination.y, boundaryMin.y, boundaryMax.y);
        destination.z = transform.position.z;

        // 따라가기
        if (isLerp)
        {
            // 부드럽게 이동
            //transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * smoothSpeed);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 1f / smoothSpeed);
        }
        else
        {
            transform.position = destination;

        }
    }
}
