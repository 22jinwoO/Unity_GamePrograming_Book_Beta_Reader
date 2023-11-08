using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //// �Ѿ� �������� ��Ƶ� ����
    //public GameObject bulletPref;

    ////�Ѿ� �߻��ϴ���
    //public float firePower;

    // �� ȿ�� �������� ��Ƶ� ����
    public GameObject shootEffectPref;

    Animator anim;
    PhotonView pv;

    void Start()
    {
        anim=GetComponent<Animator>();
        pv = GetComponent<PhotonView>();

        // ���콺 Ŀ�� �Ⱥ��̰�
        Cursor.visible = false;

        // ���콺 Ŀ���� ���� ȭ���� ����� ���ϵ��� ���
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        // ���콺 ��Ŭ���� ������ ����, �� ĳ������ ����
        if (Input.GetMouseButtonDown(0) && pv.IsMine)
        {
            AudioManager.instance.Audio_Click(1); // ���� ȿ���� ���
            //// ���� �ȿ� �Ѿ� �������� ���纻 ���� (�÷��̾��� ��ġ���� 1 �տ�)
            //// ���� �� bullet ������ �Ҵ�
            //GameObject bullet =Instantiate(bulletPref,
            //    transform.position+transform.forward, Quaternion.identity);

            //// �Ѿ� ���纻�� ������ ���ư��� �������� �� �߻�
            //bullet.GetComponent<Rigidbody>()
            //    .AddForce(transform.forward * firePower, ForceMode.Impulse);

            // �� ��� �ִϸ��̼� ����
            anim.SetTrigger("shoot");

            // ȭ�� ������� �����ϴ� Ray ����
            Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));

            // Ray�� ���� ��ü�� ��Ƶ� ����
            RaycastHit hit;

            // Ray�� �߻��ϰ�, Ray�� ���� ��ü�� hit�� ����
            if (Physics.Raycast(ray, out hit))
            {
                //// ���� ��ü�� �̸��� ���
                //print(hit.transform.name);

                // ���� ��ġ��, ���� ǥ���� ������ �Ǵ� ������ �� ȿ�� �������� ���纻 ����
                Instantiate
                    (shootEffectPref, hit.point + hit.normal * 0.01f, 
                    Quaternion.LookRotation(hit.normal), hit.transform);

                // Ray�� ���� ��ü�� ���̶��
                if(hit.transform.tag == "Enemy")
                {
                    // ������ 10��ŭ ���� ������� ����
                    hit.transform.SendMessage("Damaged", 10);
                }

                // Ray�� ���� ��ü�� �÷��̾��̶��
                if (hit.transform.tag == "Player")
                {
                    // �÷��̾�� 10��ŭ ���� ������� ����, ���� ViewID ����
                    hit.transform.GetComponent<playerHp>().Damaged(10, pv.ViewID);
                }


            }



        }

        // ���콺 ��Ŭ���� ������ ����
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // ���� �ȿ� ���ҽ� �������� �ҷ������� �Ѿ� �������� ���纻 ����
        //    //Instantiate(Resources.Load("Bullet"));
        //}
    }
}
