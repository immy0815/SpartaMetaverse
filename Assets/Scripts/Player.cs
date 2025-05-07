using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어 이동 변수
    [SerializeField] float speed = 5f;
    private Rigidbody2D rigid;

    private float inputX;
    private float inputY;

    // 애니메이션
    [SerializeField] SpriteRenderer spriteRndrr;
    [SerializeField] Animator anim;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Input 정보 저장
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // 이동
        Run();
    }

    void LateUpdate()
    {
        // 이동 애니메이션
        RunAnimaion();
    }

    void Run()
    {
        Vector2 velocity = new Vector2(inputX, inputY).normalized * speed;
        rigid.velocity = velocity;
    }

    void RunAnimaion()
    {
        if (inputX != 0)
            spriteRndrr.flipX = inputX < 0;

        anim.SetBool("IsRun", rigid.velocity.sqrMagnitude > 0.1f);
    }

    // 상호작용 오브젝트와 상호작용
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space)
            && collision.gameObject.CompareTag("Interact"))
        {
            Interact interact = collision.gameObject.GetComponent<Interact>();
            interact.InteractObj();
        }
    }
}
