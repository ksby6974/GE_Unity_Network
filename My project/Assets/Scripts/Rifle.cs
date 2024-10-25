using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rifle : MonoBehaviourPunCallbacks
{
    [SerializeField] Ray ray;
    [SerializeField] RaycastHit raycastHit;
    [SerializeField] Camera remoteCamera;
    [SerializeField] LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ray = remoteCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
            {
                PhotonView photonView = raycastHit.collider.gameObject.GetComponent<PhotonView>();

                if (photonView.IsMine)
                {
                    photonView.GetComponent<Rake>().Move_Die();
                }
            }
        }
    }
}
