using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study5_Component : MonoBehaviour
{
    // 인스펙터 창에서 관리할 수 있는 Transform 자료형의 변수
    public Transform tr;

    public Transform myTr; // 자신의 Transform 컴포넌트를 담을 변수
    public GameObject myG; // 자신의 GameObject 컴포넌트를 담을 변수

    public Light DLlight;    // Directional Light 의 Light 컴포넌트를 담을 변수
    public Light DLlight2;    // Directional Light 의 Light 컴포넌트를 담을 변수

    public GameObject findCamera1; // Main Camera를 검색해서 담을 변수;
    public GameObject findCamera2; // Main Camera를 검색해서 담을 변수;
    public GameObject findCamera3; // Main Camera를 검색해서 담을 변수;


    // Start is called before the first frame update
    void Start()
    {
        // 자신의 Transform 컴포넌트를 가져와 변수에 할당
        myTr = GetComponent<Transform>();
        myTr = transform;

        // 자신의 GameObject 컴포넌트를 가져와 변수에 할당
        myG = gameObject;

        // Directional Light의 Light 컴포넌트를 가져와 변수에 할당
        DLlight = tr.GetComponent<Light>();

        // Main camera를 이름으로 검색해 변수에 할당
        findCamera1 = GameObject.Find("Main Camera");

        // 자식 오브젝트 중 Main Camera를 검색한 후
        // GameObject 컴포넌트를 가져와 변수에 할당
        findCamera2 = transform.Find("Main Camera").gameObject;

        //Main Camera를 태그로 검색해 변수에 할당
        findCamera3 = GameObject.FindGameObjectWithTag("MainCamera");

        //Directional Light 의 Light 컴포넌트를 가져와 변수에 할당
        DLlight2 = FindObjectOfType<Light>();
    }

    // Update is called once per frame

}
