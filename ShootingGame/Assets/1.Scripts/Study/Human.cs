using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    // 1. �Ӽ� (����)

    public string name; // �̸�
    private int age; // ����
    float height; // Ű

    // 2. ���(�Լ�)
    private void Eat()
    {
        print("�Ա�");
    }    
    
    public void Sleep()
    {
        print("���ڱ�");
    }
}
