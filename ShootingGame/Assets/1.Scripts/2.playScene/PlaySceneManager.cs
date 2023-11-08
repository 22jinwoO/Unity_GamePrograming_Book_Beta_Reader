using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // ���� ���� Ŭ������ ����ϱ� ����
public class PlaySceneManager : MonoBehaviourPunCallbacks
{
    public Transform[] playerSpawnPoints; // �÷��̾� ���� ��ġ
    public GameObject warningTxt; // ESC ��� ����

    bool isEnding; // ������ ��������


    void Start()
    {
        // ���� �濡 ������ �÷��̾� �ο�
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        // �÷��̾� �ο��� ���� �ٸ� ���� ��ġ�� �÷��̾� ���� (1���̸� 0��, 2���̸� 1��)
        PhotonNetwork.Instantiate("Player",
        playerSpawnPoints[playerCount - 1].position, Quaternion.identity);
    }
    private void Update()
    {
        // ESCŰ�� �Է��ߴٸ�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(AfterEsc());
        }
    }

    // ESCŰ �Է� ���ķ� ����� ��ɵ�
    public IEnumerator AfterEsc()
    {
        // ��� ���� Ȱ��ȭ
        warningTxt.SetActive(true);
        float time = 0;
        // �濡�� �����ų� 3�ʰ� ������ ������ �ݺ�
        while (PhotonNetwork.InRoom && time < 3)
        {
            // ESCŰ�� �� �� �� �Է��ߴٸ�
            if (time != 0 && Input.GetKeyDown(KeyCode.Escape))
            {
                // �濡�� ���� �õ�
                PhotonNetwork.LeaveRoom();
                // �ݺ����� ������ �Լ� Ż��
                break;
            }
            // �ð� ���
            time += Time.deltaTime;
            // ������Ʈ �Լ��� ȣ��� ������ ����
            yield return null;
        }
        // ��� ���� ��Ȱ��ȭ
        warningTxt.SetActive(false);
    }

    // ���� ���ķ� ����� ��ɵ�
    public IEnumerator AfterEnding()
    {

        isEnding = true;


        // �濡�� ������ ������ �ݺ�
        while (PhotonNetwork.InRoom)
        {
            // �ƹ� Ű�� �ԷµǾ��ٸ�
            if (Input.anyKeyDown)
            {
                // �濡�� ���� �õ�
                PhotonNetwork.LeaveRoom();
                // �ݺ����� ������ �Լ� Ż��
                break;
            }
            // ������Ʈ �Լ��� ȣ��� ������ ����
            yield return null;
        }
    }
    // �� ���忡 �����ϸ� ȣ��
    public override void OnLeftRoom()
    {
        // 1. StartScene ��� �̸��� �� �ҷ����� (�� ��ȯ)
        PhotonNetwork.LoadLevel("1. StartScene");

        // ���콺 Ŀ�� ���̰�
        Cursor.visible = true;

        // ���콺 Ŀ���� ������ �� �ֵ��� ��� ����
        Cursor.lockState = CursorLockMode.None;
    }

    // �濡 ���ο� �÷��̾ �����ϸ� ȣ��
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        // �� �ο� ���� �ִ� �ο� ���� ��������
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            // ����������� ��ȯ�ϰ�, ��Ͽ��� �����
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
        }
    }
    // �濡�� �÷��̾ �����ϸ� ȣ��
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        // ���а� �� ���¿����� ���� ����
        if (isEnding) return;

        // ��� PhotonView ������Ʈ�� �����ͼ� �ݺ�
        foreach (var player in FindObjectsOfType<PhotonView>())
        {
            // ������ �÷��̾��� ActorNumber�� �ٸ� ActorNumber�� ���� �÷��̾� ã��
            if (player.Owner.ActorNumber != otherPlayer.ActorNumber)
            {
                // ��Ƴ��� �÷��̾�� �¸��� ���� ��� ����
                StartCoroutine(player.GetComponent<playerHp>().Ending("�¸�"));
            }
        }
    }
}
