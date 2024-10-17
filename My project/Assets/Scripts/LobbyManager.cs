using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Canvas roomCanvas;
    [SerializeField] Canvas lobbyCanvas;

    // Start is called before the first frame update
    private void Awake()
    {
        if (PhotonNetwork.IsConnected)
        {
            lobbyCanvas.gameObject.SetActive(false);
        }
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        lobbyCanvas.gameObject.SetActive(false);
    }

    // JoinLobby : 특정 로비를 생성하여 진입하는 함수
    public override void OnJoinedLobby()
    {
        if (lobbyCanvas.gameObject.activeSelf)
        {
            lobbyCanvas.gameObject.SetActive(true);
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("마스터 서버 연결");
        PhotonNetwork.JoinLobby();
    }
}
