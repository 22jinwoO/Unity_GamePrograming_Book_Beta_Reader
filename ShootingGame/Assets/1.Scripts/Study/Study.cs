using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //print("�ȳ��ϼ���~!");
        //print(10 + 5); // ����
        //print(10 - 5); // ����
        //print(10 * 5); // ����
        //print(10 / 5); // ������
        //print(10 % 5); // ������ ����

        //print(3 + 5 * 2 + (5 - 2)); // ��ȣ -> ���� �� ������ -> ���� �� ����

        //print(5 / 10);

        //print(0.1f + 1.9f); // ������ ������ ���� = ����
        //print(0.2f + 3.0f);

        //print(5 + 10f); // ������ �Ǽ��� ���� = �Ǽ�

        //print('��');

        //print("�ȳ�" + "�ϼ���~!"); // ���ڿ� ���� ������ȣ

        //print(3 < 5); // ����� ���� �񱳽�, ��°� true
        //print(3 > 5); // ����� ������ �񱳽�, ��°� false

        //print(3 < 5 && 5 < 10); // �� �񱳽��� ����� ��� ture�� ���� true ��ȯ, ��°� true
        //print(3 < 5 || 5 < 10);// �� �񱳽��� ��� �� �ϳ��� true���� true ��ȯ, ��°� ture
        //print(3 == 5); // �ΰ��� ������ ��  //��°� false
        //print(3 != 5); // �ΰ��� ���� ������ ��   //��°� true
        //print(!true);   //�� ����   //��°� false

        //int speed; // int �ڷ��� �����͸� ��� speed ��� �̸��� ���� ����

        //speed = 100; // speed ������ ���� 100 �Ҵ�
        //print(speed); // speed ������ �� ���, ��°� 100

        //int speed = 100; // int �ڷ��� �����͸� ��� speed ���� ������ 100 �Ҵ�
        //print(speed); //speed ������ �� ���, ��°� 100


        int add = Addition(5); // add���� ���� �� Addition() �Լ��� ��ȯ�� �Ҵ�
        print(add); // add������ �� ���, ��°� 6

        print(Addition(1, 2));  //�μ� 2���� Addition() �Լ� ȣ�� �� �Լ��� ��ȯ�� ���, ��°� 3

        print(Addition());  //�μ� ���� Addition() �Լ� ȣ�� �� �Լ��� ��ȯ �� ���, ��°� 5

        Addition(1f); // �Լ� ȣ�⸸ ����, ��°� 2

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int Addition(int x)
    {
        return x + 1;
    }

    int Addition(int x, int y)
    {
        return x + y; // �Ű�������������
    }

    int Addition()
    {

        //�Լ� �ȿ��� ���� ���� �� �Ҵ�
        int x = 2;
        int y = 3;
        return x + y;
    }

    void Addition(float x)
    {
        // ��ȯ �Ұ��Լ�
        print(x + 1); // ����� ����ϴ� �ڵ���� �ۼ�
    }    
}
