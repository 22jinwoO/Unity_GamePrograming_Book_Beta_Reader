using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study2_ArrayList : MonoBehaviour
{

    // �迭 ����� ���ÿ� �� �Ҵ�
    public int[] intArray = { 10, 5, -6, 48 };

    // �迭ũ�⸸ ����
    public int[] intArray2= new int[3];

    // ����Ʈ ����
    public List<int> intList = new List<int>();

    // ����Ʈ ����� ���ÿ� �� �Ҵ�
    public List<int> intList2 = new List<int>() {48, 3, -2};

    // Start is called before the first frame update
    void Start()
    {
        // intArray �迭�� 2�� ��� �� ���
        print(intArray[2]);

        // intArray �迭�� 0�� ��� �� �Ҵ�
        intArray[0] = 1;

        // intList ����Ʈ�� ������� �� �߰�
        intList.Add(-10);
        intList.Add(48);

        // intList2 ����Ʈ�� 1�� ��� �� �Ҵ�
        intList2[1] = 5;

        // intList ����Ʈ 1�� ��ҿ� 5 �Ҵ�
        intList.Insert(1, 5);

        //intList ����Ʈ���� -10�̶�� �� ����
        intList.Remove(-10);

        //intList ����Ʈ�� 1�� ��� ����
        intList.RemoveAt(1);

        // intList ����Ʈ�� 5��� ���� ������
        if(intList.Contains(5))
        {
            // intList ����Ʈ�� �ִ� 5��� ���� �ε����� �� ������  ���
            print(intList.IndexOf(5));
        }
    }

}
