using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study6_Error : MonoBehaviour
{

    //Directional Light의 Light 컴포넌트를 담을 변수
    public GameObject DLlight;

    // public 상태의 할당하지 않은 변수
    public GameObject target2;

    //public 상태가 아닌 할당하지 않은 변수
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        // DLight 오브젝트 삭제
        Destroy(DLlight);

        //print("안녕하세요");

        ////public 상태의 할당하지 않은 변수의 값 출력 : UnassigndReferenceException 에러
        //print(target2.name);

        ////public 상태가 아닌 할당하지 않은 변수의 값 출력: NullReferenceException 에러
        //print(target.name);


        /* (다른 에러가 발생하지 않도록 주석 전체 주석처리
        //배열의 범위를 벗어난 인덱스를 사용 : IndexOutOfRangeException 에러
        int[] array = { 1, 2, 3 };
        print(array[10]);

        */

    }

    // Update is called once per frame
    void Update()
    {
        //DLlight 오브젝트의 이름 출력
        //print(DLlight.name);
    }
}
