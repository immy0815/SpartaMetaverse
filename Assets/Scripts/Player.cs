using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾� �̵� ����
    [SerializeField] float speed = 5f;
    private Rigidbody2D rigid;

    private float inputX;
    private float inputY;

    // �ִϸ��̼�
    [SerializeField] SpriteRenderer spriteRndrr;
    [SerializeField] Animator anim;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Input ���� ����
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // �̵�
        Run();
    }

    void LateUpdate()
    {
        // �̵� �ִϸ��̼�
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

    // ��ȣ�ۿ� ������Ʈ�� ��ȣ�ۿ�
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
