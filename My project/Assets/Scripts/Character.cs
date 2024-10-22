using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Rotation))]

public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] Movement movement;
    [SerializeField] Rotation rotation;
    [SerializeField] Rigidbody rigidbody;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        rotation = GetComponent<Rotation>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        rotation.InputRotateY();
    }

    private void FixedUpdate()
    {
        movement.Movemnt(rigidbody);
        rotation.RotateY(rigidbody);
    }

    public void DisableCamera()
    {
        // ���� �÷��̾ �� �ڽ��̶��
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}
