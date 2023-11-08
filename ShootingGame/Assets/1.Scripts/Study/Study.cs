using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //print("안녕하세요~!");
        //print(10 + 5); // 덧셈
        //print(10 - 5); // 뺄셈
        //print(10 * 5); // 곱셈
        //print(10 / 5); // 나눗셈
        //print(10 % 5); // 나머지 연산

        //print(3 + 5 * 2 + (5 - 2)); // 괄호 -> 곱셈 및 나눗셈 -> 덧셈 및 뺄셈

        //print(5 / 10);

        //print(0.1f + 1.9f); // 정수와 정수의 연산 = 정수
        //print(0.2f + 3.0f);

        //print(5 + 10f); // 정수와 실수의 연산 = 실수

        //print('가');

        //print("안녕" + "하세요~!"); // 문자열 사이 덧셈부호

        //print(3 < 5); // 결과가 참인 비교식, 출력값 true
        //print(3 > 5); // 결과가 거짓인 비교식, 출력값 false

        //print(3 < 5 && 5 < 10); // 두 비교식의 결과가 모두 ture일 때만 true 반환, 출력값 true
        //print(3 < 5 || 5 < 10);// 두 비교식의 결과 중 하나만 true여도 true 반환, 출력값 ture
        //print(3 == 5); // 두값이 같은지 비교  //출력값 false
        //print(3 != 5); // 두값이 같지 않은지 비교   //출력값 true
        //print(!true);   //논리 부정   //출력값 false

        //int speed; // int 자료형 데이터를 담는 speed 라는 이름의 변수 선언

        //speed = 100; // speed 변수에 정수 100 할당
        //print(speed); // speed 변수의 값 출력, 출력값 100

        //int speed = 100; // int 자료형 데이터를 담는 speed 변수 선언후 100 할당
        //print(speed); //speed 변수의 값 출력, 출력값 100


        int add = Addition(5); // add변수 선언 후 Addition() 함수의 반환값 할당
        print(add); // add변수의 값 출력, 출력값 6

        print(Addition(1, 2));  //인수 2개로 Addition() 함수 호출 후 함수의 반환값 출력, 출력값 3

        print(Addition());  //인수 없이 Addition() 함수 호출 후 함수의 반환 값 출력, 출력값 5

        Addition(1f); // 함수 호출만 가능, 출력값 2

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
        return x + y; // 매개변수끼리덧셈
    }

    int Addition()
    {

        //함수 안에서 변수 선언 후 할당
        int x = 2;
        int y = 3;
        return x + y;
    }

    void Addition(float x)
    {
        // 반환 불가함수
        print(x + 1); // 결과를 출력하는 코드까지 작성
    }    
}
