using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Pause : MonoBehaviourPunCallbacks
{
    public void Awake()
    {
        //gameObject.SetActive(false);
    }

    public void Resume()
    {
        MouseManager.Instance.SetMouse(false);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby Scene");
    }

}
