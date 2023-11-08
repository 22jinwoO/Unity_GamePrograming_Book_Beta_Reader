using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI ���� Ŭ������ ����ϱ� ����
using UnityEngine.AI;   // AI ���� Ŭ������ ����ϱ� ����

public class Enemy : MonoBehaviour
{
    // ���� ���� �� �ִ� ���� ���
    public enum EnemyState
    {
        Idle, // �⺻
        Walk, // �̵�
        Attack, // ����
        Damaged, // �ǰ�
        Dead    // ����
    }

    public Slider hpBar; // ���� ü�¹�
    public float hp = 100; // ���� ü��

    Transform player; // �÷��̾�
    NavMeshAgent agent; // NavMeshAgent ������Ʈ
    Animator anim; // Animator ������Ʈ
    float distance; // �÷��̾���� �Ÿ�


    // ���¸� ��Ƶ� ������ �����, �⺻ ���·� ����
    public EnemyState eState = EnemyState.Idle;

    void Damaged(float damage)
    {
        // ���� ���� ��������ŭ ü�� ����
        hp -= damage;

        // ������ ü���� ü�¹ٿ� ǥ��
        hpBar.value = hp;

        agent.isStopped = true; // �̵� �ߴ�
        agent.ResetPath();  // ��� �ʱ�ȭ
        if(hp > 0 ) // ü���� �����ִٸ�
        {
            anim.SetTrigger("damaged"); // �ǰ� �ִϸ��̼� ����
            eState = EnemyState.Damaged; // �ǰ� ���·� ��ȯ
        }
        else // ü���� �������� �ʴٸ�
        {
            anim.SetTrigger("dead"); // ���� �ִϸ��̼� ����
            eState = EnemyState.Dead; // ���� ���·� ��ȯ
        }
    }

    // �ǰ� �ִϸ��̼��� ������ ȣ��
    void DamageEnd()
    {
        eState = EnemyState.Idle; // �⺻ ���·� ��ȯ
    }
    void Start()
    {
        // Player ������Ʈ�� ã�� �÷��̾��� Transform ������Ʈ ��������
        player = FindObjectOfType<Player>().transform;

        // ���� NaviMeshAgent ������Ʈ ��������
        agent = GetComponent<NavMeshAgent>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �÷��̾� ������ �Ÿ� ���
        distance = Vector3.Distance(transform.position, player.position);

        //// ���� �÷��̾� ������ �Ÿ� ���
        //print(distance);

        // �̵��� ���� �޶����� NavMeshAgent ������Ʈ�� �ӵ��� �ִϸ��̼� ��ȯ
        anim.SetFloat("velocity", agent.velocity.magnitude);
        // �⺻, �̵�, ���� ������ �� �� �� ������
        switch (eState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Walk:
                Walk();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            default:
                break;
        }

    }
    void Idle() // �⺻ ������ �� ��� �� ��
    {
        //�÷��̾���� �Ÿ��� 8 ���϶��
        if (distance <=8)
        {
            eState = EnemyState.Walk; // �̵� ���·� ��ȯ
            agent.isStopped = false; // �̵�����
        }
    }

    void Walk() // �̵� ������ �� ��� �� ��
    {
        // �÷��̾���� �Ÿ��� 8���� ũ�ٸ�
        if(distance > 8)
        {
            eState = EnemyState.Idle; // �⺻ ���·� ��ȯ
            agent.isStopped = true; // �̵� �ߴ�
            agent.ResetPath(); // ��� �ʱ�ȭ
        }

        // �÷��̾���� �Ÿ��� 2 ���϶��
        else if (distance <=2)
        {
            eState = EnemyState.Attack; // ���ݻ��·� ��ȯ
            agent.isStopped = true; // �̵� �ߴ�
            agent.ResetPath(); // ��� �ʱ�ȭ
            attackCoolTime = 1; // ���� ���°� ���ڸ��� ���� ����
        }
        // �ٸ� ���·� ��ȯ���� ���� ����
        else
        {
            // �÷��̾���� ��ġ�� �������� ����
            agent.SetDestination(player.position);
        }
    }
    float attackCoolTime;   // ���� �ֱ⸦ ���� ��Ÿ��
    void Attack() // ���� ������ �� ��� �� ��
    {
        // �÷��̾���� �Ÿ��� 2���� ũ�ٸ�
        if(distance >2)
        {
            eState = EnemyState.Walk; // �̵� ���·� ��ȯ
            agent.isStopped = false; // �̵�����
        }
        // �ٸ� ���·� ��ȯ���� ���� ����
        else
        {
            // ���� ������ �� ��Ÿ�� ���
            attackCoolTime += Time.deltaTime;

            // ���� ��Ÿ���� 1�� �̻��� �Ǹ�
            if (attackCoolTime>=1)
            {
                anim.SetTrigger("attack"); // ���� �ִϸ��̼� ����
                attackCoolTime = 0; // �ٽ� 1�ʸ� �� �� �ְ� �ʱ�ȭ
            }
            
        }
    }
    
    // ���� �ִϸ��̼� �߰��� ȣ��
    void RealAttack()
    {
        // �÷��̾�� 10��ŭ ���� ������� ����
        player.SendMessage("Damaged", 10);
    }

}


