using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EnemySpawnManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform spawnPosition;
    WaitForSeconds waitForSeconds = new WaitForSeconds(5);

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.LeaveRoom();
            StartCoroutine(CreateEnemy());
        }
    }

    public IEnumerator CreateEnemy()
    {
        while (true)
        {
            PhotonNetwork.InstantiateRoomObject("Enemy", spawnPosition.position, Quaternion.identity);
            Debug.Log("CreateEnemy");
            yield return waitForSeconds;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
