using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Study3_Conditional : MonoBehaviour
{
    int hp = 100; // ü��

    // Start is called before the first frame update
    void Start()
    {
        //// ü���� 0�� �Ǹ�
        //if (hp == 0)
        //{
        //    // Dead() �Լ� ȣ��
        //    Dead();

        //}

        //int a = 3;

        //// a�� ���� 2�� ���� �������� 0 �̸�
        //if(a%2 == 0)
        //{
        //    print("a�� ¦��");
        //}
        //// �� ���ǿ� �������� ���ϸ� (= �������� 0 �� �ƴϸ�)
        //else
        //{
        //    print("a�� Ȧ��");
        //}

        int score = 86;
        string grade = "";

        ////90 �� �̻�
        //if(score>=90)
        //{
        //    grade = "A";
        //}
        //else
        //{
        //    // 80�� �̻� 90�� �̸�
        //    if(score>=90)
        //    {
        //        grade = "B";
        //    }
        //    else
        //    {
        //        // 70�� �̻� 80�� �̸�
        //        if(score>=70)
        //        {
        //            grade = "C";
        //        }
        //        // �� �� �ٸ� ����
        //        else
        //        {
        //            //
        //        }
        //    }
        //}

        //// 90�� �̻�
        //if (score > 90)
        //{
        //    grade = "A";
        //}

        //// 80�� �̻� 90�� �̸�
        //else if(score >= 80)
        //{
        //    grade = "B";
        //}
        ////70�� �̻� 80�� �̸�
        //else if(score >=70)
        //{
        //    grade = "C";
        //}
        //// �� �� �ٸ� ����
        //else
        //{
        //    //
        //}

        string itemName = "�Ѿ�";

        switch(itemName)
        {
            case "��������":
                //ü�� �����ϴ� ���
                break;

            case "�Ѿ�":
                // �Ѿ��� ������ �����ϴ� ���
                break;
            default: // �� �ܿ� �ٸ� ������
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Dead()
    {
        //���� ���¿� ������ ��� ����
    }
}
