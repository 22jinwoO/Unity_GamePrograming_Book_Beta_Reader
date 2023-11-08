using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study5_Component : MonoBehaviour
{
    // �ν����� â���� ������ �� �ִ� Transform �ڷ����� ����
    public Transform tr;

    public Transform myTr; // �ڽ��� Transform ������Ʈ�� ���� ����
    public GameObject myG; // �ڽ��� GameObject ������Ʈ�� ���� ����

    public Light DLlight;    // Directional Light �� Light ������Ʈ�� ���� ����
    public Light DLlight2;    // Directional Light �� Light ������Ʈ�� ���� ����

    public GameObject findCamera1; // Main Camera�� �˻��ؼ� ���� ����;
    public GameObject findCamera2; // Main Camera�� �˻��ؼ� ���� ����;
    public GameObject findCamera3; // Main Camera�� �˻��ؼ� ���� ����;


    // Start is called before the first frame update
    void Start()
    {
        // �ڽ��� Transform ������Ʈ�� ������ ������ �Ҵ�
        myTr = GetComponent<Transform>();
        myTr = transform;

        // �ڽ��� GameObject ������Ʈ�� ������ ������ �Ҵ�
        myG = gameObject;

        // Directional Light�� Light ������Ʈ�� ������ ������ �Ҵ�
        DLlight = tr.GetComponent<Light>();

        // Main camera�� �̸����� �˻��� ������ �Ҵ�
        findCamera1 = GameObject.Find("Main Camera");

        // �ڽ� ������Ʈ �� Main Camera�� �˻��� ��
        // GameObject ������Ʈ�� ������ ������ �Ҵ�
        findCamera2 = transform.Find("Main Camera").gameObject;

        //Main Camera�� �±׷� �˻��� ������ �Ҵ�
        findCamera3 = GameObject.FindGameObjectWithTag("MainCamera");

        //Directional Light �� Light ������Ʈ�� ������ ������ �Ҵ�
        DLlight2 = FindObjectOfType<Light>();
    }

    // Update is called once per frame

}
