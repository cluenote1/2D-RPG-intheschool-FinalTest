using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Character : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D Rigidbody2d;
    private AudioSource audioSource;

    public AudioClip JumpClip;
    public float Speed = 4f;
    public float JumpPower = 5f;

    private bool isFloor;
    private bool isLadder;
    private bool isClimbing;
    private float inputVertical;

    public GameObject AttackObj;
    public float AttackSpeed = 3f;
    public AudioClip AttackClip;

    private bool justAttack, justJump;

    private float originalSpeed; // ���� �ӵ��� ������ ���� �߰�
    private float attackPower; // �⺻ ���ݷ�
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        originalSpeed = Speed; // ���� �ӵ��� �����մϴ�
    }

    void Update()
    {
        Move();
        AttackCheck(); // ���⿡ �߰�
        JumpCheck();
        ClimbingCheck();
    }

    private void FixedUpdate()
    {
        Jump();
        Attack();
        Climbing();
    }

    private void ClimbingCheck()
    {
        inputVertical = Input.GetAxis("Vertical");
        if (isLadder && Math.Abs(inputVertical) > 0) 
        {
            isClimbing = true;
        }
    }
    
    private void Climbing()
    {
        if (isClimbing)
        {
            Rigidbody2d.gravityScale = 0f;
            Rigidbody2d.velocity = new Vector2(Rigidbody2d.velocity.x, inputVertical * Speed);
        }
        else
        {
            Rigidbody2d.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    private void Move()
    {
        //�̵�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            animator.SetBool("Move" , true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        // �¿� �̵��� ���� ����
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = false;
        }
    }
    private void Jump()
    {
        if (justJump)
        {
            justJump = false;

            Rigidbody2d.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            audioSource.PlayOneShot(JumpClip);
        }
    }

    private void JumpCheck()
    {
        if (isFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                justJump = true;
            }
        }
    }

    private void AttackCheck()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Attack key pressed");
            justAttack = true;
        }
    }

    private void Attack()
    {
        if (justAttack)
        {
            justAttack = false;

            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(AttackClip);

            if (spriteRenderer.flipX)
            {
                GameObject obj = Instantiate(AttackObj, transform.position, Quaternion.Euler(0, 180f, 0));
                obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * AttackSpeed, ForceMode2D.Impulse);
                Destroy(obj, 3f);
            }
            else
            {
                GameObject obj = Instantiate(AttackObj, transform.position, Quaternion.Euler(0, 0, 0));
                obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * AttackSpeed, ForceMode2D.Impulse); // ������ �κ�
                Destroy(obj, 3f);
            }
        }
    }

    public void IncreaseSpeed()
    {
        Speed += originalSpeed * 0.5f;
    }

    public void IncreaseAttack()
    {
        attackPower += 5f;
    }


    private void SetAttackObjInactive()
    {
        if (AttackObj != null && AttackObj.activeSelf) // AttackObj�� �����ϰ� Ȱ��ȭ�� ��쿡�� ����
        {
            AttackObj.SetActive(false);
        }
    }
    
}
