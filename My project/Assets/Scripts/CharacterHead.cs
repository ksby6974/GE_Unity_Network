using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]

public class CharacterHead : MonoBehaviour
{
    private Rotation rotation;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        rotation.RotateX();
    }
}
