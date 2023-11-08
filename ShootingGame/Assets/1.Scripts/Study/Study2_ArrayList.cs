using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study2_ArrayList : MonoBehaviour
{

    // 배열 선언과 동시에 값 할당
    public int[] intArray = { 10, 5, -6, 48 };

    // 배열크기만 설정
    public int[] intArray2= new int[3];

    // 리스트 선언
    public List<int> intList = new List<int>();

    // 리스트 선언과 동시에 값 할당
    public List<int> intList2 = new List<int>() {48, 3, -2};

    // Start is called before the first frame update
    void Start()
    {
        // intArray 배열의 2번 요소 값 출력
        print(intArray[2]);

        // intArray 배열의 0번 요소 값 할당
        intArray[0] = 1;

        // intList 리스트에 순서대로 값 추가
        intList.Add(-10);
        intList.Add(48);

        // intList2 리스트의 1번 요소 값 할당
        intList2[1] = 5;

        // intList 리스트 1번 요소에 5 할당
        intList.Insert(1, 5);

        //intList 리스트에서 -10이라는 값 삭제
        intList.Remove(-10);

        //intList 리스트의 1번 요소 삭제
        intList.RemoveAt(1);

        // intList 리스트에 5라는 값이 있으면
        if(intList.Contains(5))
        {
            // intList 리스트에 있는 5라는 값의 인덱스가 몇 번인지  출력
            print(intList.IndexOf(5));
        }
    }

}
