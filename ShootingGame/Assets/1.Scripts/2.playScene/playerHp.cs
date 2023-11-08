using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun; // ���� ���� Ŭ������ ����ϱ� ����

public class playerHp : MonoBehaviour
{
    public float hp = 100; // �÷��̾��� ü��
    public Slider hpBar_World;    // ���̾��� ü�¹� (�Ӹ� ��)

    Animator anim; // �÷��̾��� Animator ������Ʈ
    PhotonView pv; // �÷��̾��� PhotonView ������Ʈ
    Slider hpBar_Screen; // �÷��̾��� ü�¹� (ȭ��)
    Transform canvas; // Canvas ������Ʈ

    void Start()
    {
        anim = GetComponent<Animator>();
        pv = GetComponent<PhotonView>();

        // �� ĳ������ ���� ����
        if (pv.IsMine)
        {
            // Canvas �˻��ؼ� ��������
            canvas = GameObject.Find("Canvas").transform;

            // Canvas�� �θ� ���� ����
            canvas.SetParent(transform);

            // ȭ�� ���� ��ܿ� �ִ� �÷��̾��� ü�¹� ��������
            hpBar_Screen = canvas.GetComponentInChildren<Slider>();
        }
    }
    public void Damaged(float damage, int hitter)
    {
        // ���� �޾����� RPC ������� ��ο��� ����
        pv.RPC("RPC_Damaged", RpcTarget.All, damage, hitter);
    }


    void Update()
    {

    }

    //public void Damaged(float damage, int hitter)
    //{
    //     ���� �޾����� RPC ������� ��ο��� ����
    //    pv.RPC("RPC_Damaged", RpcTarget.All, damage);

    //    // ���� ���� ��������ŭ ü�� ����
    //    hp -= damage;

    //    // ü�¹ٿ� ü�� ǥ��
    //    hpBar_World.value = hp;

    //    // ȭ�� ü�¹ٿ� ǥ���ϴ� �� �� ĳ������ ����
    //    if (pv.IsMine)
    //        hpBar_Screen.value = hp;

    //    if(hp > 0)  // ü���� �����ִٸ�
    //    {
    //        // �ǰ� �ִϸ��̼� ����
    //        anim.SetTrigger("damaged");
    //    }
    //    else // ü���� �������� �ʴٸ�
    //    {
    //        // ���� �ִϸ��̼� ����
    //        anim.SetTrigger("dead");

    //        // �÷��̾��� ��� �ߴ�
    //        GetComponent<Player>().enabled = false;
    //        GetComponent<PlayerFire>().enabled = false;
    //        GetComponentInChildren<CameraRotate>().enabled = false;


    //        // ���� ���� ��� ���� ��� �ߴ�
    //        Enemy[] enemies = FindObjectsOfType<Enemy>();
    //        foreach (var enemy in enemies)
    //        {
    //            enemy.enabled = false;
    //        }
    //    }
    //}

    [PunRPC]
    void RPC_Damaged(float damage, int hitter)
    {
        // ���� ���� ��������ŭ ü�� ����
        hp -= damage;

        // ü�¹ٿ� ü�� ǥ��
        hpBar_World.value = hp;

        // �� ĳ������ ���� ����
        if (pv.IsMine)
        {
            // Canvas �˻��ؼ� ��������
            canvas = GameObject.Find("Canvas").transform;

            // ȭ�� ü�¹ٿ� ü�� ǥ��
            hpBar_Screen.value = hp;

            if (hp > 0) // ü���� �����ִٸ�
            {
                // �ǰ� �ִϸ��̼� ����
                anim.SetTrigger("damaged");
            }
            else
            {
                // ���� �ִϸ��̼� ����
                anim.SetTrigger("dead");
                // ī�޶��� ��� �ߴ�
                GetComponentInChildren<CameraRotate>().enabled = false;

                // �й� �� ���� ��� ����
                StartCoroutine(Ending("�й�"));
            }
        }
        // �� ĳ���Ͱ� �ƴϾ ü���� �������� �ʴٸ�
        if (hp <= 0)
        {
            // ���� �Ŀ��� �ѿ� ���� �ʵ��� �±� ����
            tag = "Untagged";

            // �÷��̾��� ��� �ߴ�
            GetComponent<Player>().enabled = false;
            GetComponent<PlayerFire>().enabled = false;

            // �¸��� �÷��̾� ã�Ƽ� PlayerHp ������Ʈ ��������
            playerHp winner
            = PhotonNetwork.GetPhotonView(hitter).GetComponent<playerHp>();

            // �¸��� �÷��̾�� �¸��� ���� ��� ����
            StartCoroutine(winner.Ending("�¸�"));
        }
        //// ȭ�� ü�¹ٿ� ǥ���ϴ� �� �� ĳ������ ����
        //if (pv.IsMine)
        //    hpBar_Screen.value = hp;

        //if (hp > 0) // ü���� �����ִٸ�
        //{
        //    // �ǰ� �ִϸ��̼� ����
        //    anim.SetTrigger("damaged");
        //}

        //else // ü���� �������� �ʴٸ�
        //{
        //    // ���� �ִϸ��̼� ����
        //    anim.SetTrigger("dead");

        //    // �÷��̾��� ��� �ߴ�
        //    GetComponent<Player>().enabled = false;
        //    GetComponent<PlayerFire>().enabled = false;
        //    GetComponentInChildren<CameraRotate>().enabled = false;
        //}
    }

    // �������� ����� ��ɵ�
    public IEnumerator Ending(string result)
    {

        // �� ĳ���Ͱ� �ƴ϶�� �Լ� Ż���Ͽ� �Ʒ� �ڵ� ���� �Ұ�
        if (!pv.IsMine) yield break;

        // 1�ʵ��� �Ʒ� �ڵ尡 ������� �ʵ��� ����
        yield return new WaitForSeconds(1f);

        // Canvas�� 2��° �ڽ��� Ending ������Ʈ ��������
        Transform ending = canvas.GetChild(2);

        // ��� UI ���
        ending.GetChild(0).GetComponent<Text>().text = "- " + result + " -";

        // ��� ȭ�� Ȱ��ȭ
        ending.gameObject.SetActive(true);

        // �÷��̾��� ��� �ߴ�
        GetComponent<Player>().enabled = false;
        GetComponent<PlayerFire>().enabled = false;
        GetComponentInChildren<CameraRotate>().enabled = false;

        // ���� ������ ��� ����
        StartCoroutine(FindObjectOfType<PlaySceneManager>().AfterEnding());

        // �¸��ߴٸ� �¸� Ƚ�� ����
        if (result == "�¸�") DataManager.instance.WinCount++;
    }

}
