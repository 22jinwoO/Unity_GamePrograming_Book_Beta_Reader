using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study6_Error : MonoBehaviour
{

    //Directional Light�� Light ������Ʈ�� ���� ����
    public GameObject DLlight;

    // public ������ �Ҵ����� ���� ����
    public GameObject target2;

    //public ���°� �ƴ� �Ҵ����� ���� ����
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        // DLight ������Ʈ ����
        Destroy(DLlight);

        //print("�ȳ��ϼ���");

        ////public ������ �Ҵ����� ���� ������ �� ��� : UnassigndReferenceException ����
        //print(target2.name);

        ////public ���°� �ƴ� �Ҵ����� ���� ������ �� ���: NullReferenceException ����
        //print(target.name);


        /* (�ٸ� ������ �߻����� �ʵ��� �ּ� ��ü �ּ�ó��
        //�迭�� ������ ��� �ε����� ��� : IndexOutOfRangeException ����
        int[] array = { 1, 2, 3 };
        print(array[10]);

        */

    }

    // Update is called once per frame
    void Update()
    {
        //DLlight ������Ʈ�� �̸� ���
        //print(DLlight.name);
    }
}
