using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rotation))]

public class CharacterHead : MonoBehaviourPunCallbacks
{
    private Rotation rotation;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        rotation.RotateX();
    }
}
