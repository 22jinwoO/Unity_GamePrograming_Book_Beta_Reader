using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Study3_Conditional : MonoBehaviour
{
    int hp = 100; // 체력

    // Start is called before the first frame update
    void Start()
    {
        //// 체력이 0이 되면
        //if (hp == 0)
        //{
        //    // Dead() 함수 호출
        //    Dead();

        //}

        //int a = 3;

        //// a의 값을 2로 나눈 나머지가 0 이면
        //if(a%2 == 0)
        //{
        //    print("a는 짝수");
        //}
        //// 위 조건에 만족하지 못하면 (= 나머지가 0 이 아니면)
        //else
        //{
        //    print("a는 홀수");
        //}

        int score = 86;
        string grade = "";

        ////90 점 이상
        //if(score>=90)
        //{
        //    grade = "A";
        //}
        //else
        //{
        //    // 80점 이상 90점 미만
        //    if(score>=90)
        //    {
        //        grade = "B";
        //    }
        //    else
        //    {
        //        // 70점 이상 80점 미만
        //        if(score>=70)
        //        {
        //            grade = "C";
        //        }
        //        // 그 외 다른 점수
        //        else
        //        {
        //            //
        //        }
        //    }
        //}

        //// 90점 이상
        //if (score > 90)
        //{
        //    grade = "A";
        //}

        //// 80점 이상 90점 미만
        //else if(score >= 80)
        //{
        //    grade = "B";
        //}
        ////70점 이상 80점 미만
        //else if(score >=70)
        //{
        //    grade = "C";
        //}
        //// 그 외 다른 점수
        //else
        //{
        //    //
        //}

        string itemName = "총알";

        switch(itemName)
        {
            case "빨간포션":
                //체력 증가하는 기능
                break;

            case "총알":
                // 총알의 개수가 증가하는 기능
                break;
            default: // 그 외에 다른 아이템
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Dead()
    {
        //죽음 상태에 실행할 기능 구현
    }
}
