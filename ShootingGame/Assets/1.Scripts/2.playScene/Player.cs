using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun; // ���� ���� Ŭ������ ����ϱ� ����

public class Player : MonoBehaviour
{

    public float moveSpeed; // �̵� �ӵ�
    public float rotateSpeed; // ȸ�� �ӵ�
    public float jumpPower; // �����ϴ� ��

    int jumpCount; // ������ Ƚ��

    Rigidbody rb;   // �÷��̾��� Rigidbody ������Ʈ
    Animator anim; // �÷��̾��� Animator ������Ʈ
    PhotonView pv; // �÷��̾��� PhotonView ������Ʈ

    void Awake()
    {
        // �÷��̾��� RigidBody, Animator, PhotonView ������Ʈ �����ͼ� ����
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        pv = GetComponent<PhotonView>();

        // �� ĳ������ ���� ����
        if (pv.IsMine)
        {
            // Main Camera �˻��ؼ� ��������
            Transform camera = Camera.main.transform;

            // Main Camera�� �θ� ���� ����
            camera.SetParent(transform);

            // ���� �������� ������ ��ġ�� �̵�
            camera.localPosition = new Vector3(0, 1.2f, 0.4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //// ���콺 ��Ŭ���� ������ ����
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // "�ȳ�" �̶�� ���ڿ� ���
        //    print("�ȳ�");
        //}

        //// �� �Ʒ� ����Ű �Ǵ� WŰ�� SŰ �� �ϳ��� ������ �ִٸ�
        //if (Input.GetButton("Vertical"))
        //{
        //    // �÷��̾� ĳ���� ������ �̵�
        //}

        //// ���Ʒ� ����Ű �Ǵ� WŰ�� SŰ �Է��� ���ڷ� �޾Ƽ� ����
        //float v = Input.GetAxis("Vertical");
        //print(v);

        //// ����Ű �Ǵ� WASDŰ �Է��� ���ڷ� �޾Ƽ� ����
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //// x�࿡�� h�� ����, z�࿡�� v�� ���� ��� ���ϱ�
        //transform.position += new Vector3(h, 0, v) * moveSpeed;

        // �� ĳ���Ͱ� �ƴ϶�� �Լ� Ż���Ͽ� �Ʒ� �ڵ� ���� �Ұ�
        if (!pv.IsMine) return;


        // ����Ű �Ǵ� WASDŰ �Է��� ���ڷ� �޾Ƽ� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // x�࿡�� h�� ����, z�࿡�� v�� ���� ���� ���� ����
        Vector3 dir = new Vector3(h, 0, v);

        //��� ������ �ӵ��� �����ϵ��� ����ȭ
        dir.Normalize();

        // �÷��̾ �������� dir�� ���� ����
        dir = transform.TransformDirection(dir);

        //// �̵��� ���⿡ ���ϴ� �ӵ� ���ϱ�
        //transform.position += dir * moveSpeed*Time.deltaTime;

        // ���� �ۿ��� �̿��� �̵�
        rb.MovePosition(rb.position + (dir * moveSpeed * Time.deltaTime));

        // �̵��ϴ� �ӵ��� velocity ������ �Ҵ��Ͽ� �ִϸ��̼� ��ȯ
        anim.SetFloat("velocity", dir.magnitude);

        // �̵��ϰ� �ְ�, �������� ���� �� �̵� ȿ���� ���
        if (dir.magnitude > 0 && !anim.GetBool("isJump"))
        {
            AudioManager.instance.Audio_Walk(true);
        }
        // �̵��� ���߰ų� �����ϸ� �̵� ȿ���� ��� ����
        else AudioManager.instance.Audio_Walk(false);

        // �����̽��ٸ� ���� ����, ������ Ƚ���� 2ȸ �̸��̶��
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            // ���� �������� �� �߻�
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            // ���� �ִϸ��̼� ����
            anim.SetTrigger("jump");
            anim.SetBool("isJump", true);

            // ������ ������ ���� Ƚ�� ����
            jumpCount++;
        }

        // ���콺�� �¿� ������ �Է��� ���ڷ� �޾Ƽ� ����
        float mouseMoveX = Input.GetAxis("Mouse X");

        // ���콺�� ������ ��ŭ Y�� ȸ��
        transform.Rotate(0, mouseMoveX * rotateSpeed * Time.deltaTime, 0);
    }

    // � ��ü�� �浹�� ������ ������ ȣ��
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� �±װ� "Ground"�̰�, �� ĳ������ ����
        if (collision.gameObject.tag == "Ground" && pv.IsMine)
        {
            // ���� Ƚ�� �ʱ�ȭ
            jumpCount = 0;

            // ���� �ִϸ��̼� ����
            anim.SetBool("isJump", false);
        }
    }
}
