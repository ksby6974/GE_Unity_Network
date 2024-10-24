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

    public void Movemnt(Rigidbody rigidbody)
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction.Normalize();
        transform.position += rigidbody.transform.TransformDirection(direction * Speed * Time.deltaTime);
    }
}
