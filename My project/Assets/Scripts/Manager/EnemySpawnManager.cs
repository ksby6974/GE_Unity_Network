using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EnemySpawnManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform spawnPosition;
    [SerializeField] int iLimit;
    WaitForSeconds waitForSeconds = new WaitForSeconds(5);

    // Start is called before the first frame update
    void Start()
    {
        iLimit = 1;
        if (PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.LeaveRoom();
            StartCoroutine(CreateEnemy());
        }
    }

    public IEnumerator CreateEnemy()
    {
        int n = 0;

        while (iLimit > n)
        {
            PhotonNetwork.InstantiateRoomObject("Enemy", spawnPosition.position, Quaternion.identity);
            Debug.Log("CreateEnemy");
            yield return waitForSeconds;

            n++;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }
}
