using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� Ŭ������ ����ϱ� ����
using Photon.Pun;   // ���� ���� Ŭ������ ����ϱ� ����
using Photon.Realtime; // OnDisconnected �Լ� �����ϸ� �ڵ����� �����

public class Server : MonoBehaviourPunCallbacks //  ���� ���� �ݹ� �Լ��� ��ӹޱ� ����
{
    public Button startBtn; // ���� ��ư
    public Button ExitBtn; // ���� ��ư
    public GameObject lobby; // �κ� ȭ��
    public Text connectInfoTxt; // ���� ��Ȳ �ؽ�Ʈ
    public Text winCountTxt; // �¸� Ƚ�� �ؽ�Ʈ

    void Start()
    {
        // ���� ��ư�� OnClick() �Լ��� OnClickStart() �Լ� ����
        startBtn.onClick.AddListener(OnClickStart);

        // ���� ��ư�� OnClick() �Լ��� OnClickExit() �Լ� ����
        ExitBtn.onClick.AddListener(OnClickExit);

        // ���� ��ư ��Ȱ��ȭ ���·� ����
        startBtn.interactable = false;

        // ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();
        connectInfoTxt.text = "���� ���� ��...";

        // �¸� Ƚ�� ���
        winCountTxt.text = "�¸� Ƚ�� : " + DataManager.instance.WinCount.ToString();
    }

    // ���� ��ư ������ ȣ��
    void OnClickStart()
    {
        AudioManager.instance.Audio_Click(0); // Ŭ�� ȿ���� ���
        PhotonNetwork.JoinLobby(); // �κ� ���� �õ�
        connectInfoTxt.text = "�κ� ���� ��...";
    }

    // ���� ��ư ������ ȣ��
    void OnClickExit()
    {
        AudioManager.instance.Audio_Click(0); // Ŭ�� ���� ���

    // ���� ����
#if UNITY_EDITOR // ����Ƽ �������� ��
        UnityEditor.EditorApplication.isPlaying = false;
#else // ����Ƽ �����Ͱ� �ƴ� ��
 Application.Quit();
#endif
    }

    // ���� ���ӿ� �����ϸ� ȣ��
    public override void OnConnectedToMaster()
    {
        // ���� ��ư Ȱ��ȭ
        startBtn.interactable = true;
        connectInfoTxt.text = "���� ���� ����!";
    }

    // �κ� ���ӿ� �����ϸ� ȣ��
    public override void OnJoinedLobby()
    {
        // �κ� ȭ������ ��ȯ
        gameObject.SetActive(false);
        lobby.SetActive(true);
        connectInfoTxt.text = "�κ� ���� ����!";
    }

    // ���ӿ� �����ϸ� ȣ��
    public override void OnDisconnected(DisconnectCause cause)
    {
        // ���� ������ �õ�
        PhotonNetwork.ConnectUsingSettings();
        connectInfoTxt.text = "���� ����, ���� ������ ��...";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
