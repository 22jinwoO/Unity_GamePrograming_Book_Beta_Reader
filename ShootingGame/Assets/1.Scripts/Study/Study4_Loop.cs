using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study4_Loop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //print("���� ��ȯ");
        //print("���� ��ȯ");
        //print("���� ��ȯ");
        //print("���� ��ȯ");
        //print("���� ��ȯ");
        //print("���� ��ȯ");
        //print("���� ��ȯ");
        //print("���� ��ȯ");
        //print("���� ��ȯ");
        //print("���� ��ȯ");
        //print("���� ��ȯ");

        //int count = 0;

        //// count�� ���� 10���� ������ ����
        //while (count < 10)
        //{
        //    print("���� ��ȯ");
        //    count++; // count�� ���� 1�� ����
        //}

        int count = 0;

        //count�� ���� 10���� ������ ����
        while (count < 10)
        {
            print("���� ��ȯ");
            count++; // count�� �� 1�� ����
        }

        // 10�� �ݺ�
        for(int i = 0; i < 10; i++)
        {
            print("���� ��ȯ2");
        }

        // i�� ���� ���ҽ�Ű�� 10�� �ݺ�
        for(int i = 10; i > 0; i--)
        {
            print("���� ��ȯ3");
        }
        string[] stringArray = { "�ȳ�", "�ϼ���" };

        //stringArray �迭�� ��� ������ŭ �ݺ�
        for (int i = 0; i < stringArray.Length; i++)
        {
            stringArray[i] = "�ݰ�����"; // ��� ��ҿ� �� �Ҵ�
        }
        // stringArray �迭�ǿ�� ������ŭ �ݺ�
        foreach(var item in stringArray)
        {
            print(item); // ��� ����� �� ���
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
