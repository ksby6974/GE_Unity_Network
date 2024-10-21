using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Vector3 direction;

    public void Awake()
    {
        Speed = 5.0f;
    }

    public void Movemnt()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
        transform.position += transform.TransformDirection(direction * Speed * Time.deltaTime);
    }
}
