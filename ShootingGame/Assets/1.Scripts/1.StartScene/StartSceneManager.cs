using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // StartSceneManager Ŭ������ ����ϱ� ����

public class StartSceneManager : MonoBehaviour
{
    //Start ��ư�� Ŭ���ϸ� ȣ��
    public void OnClickStart()
    {
        // 2. PlayScene �̶�� �̸��� �� �ҷ����� (�� ��ȯ)
        SceneManager.LoadScene("2. PlayScene");
    }
}
