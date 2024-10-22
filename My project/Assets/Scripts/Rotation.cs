using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float speed;

    public void InputRotateY()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void Awake()
    {
        speed = 250.0f;
    }

    public void RotateX()
    {
        // mouseX�� ���콺�� �Է��� ���� ����
        // mouseY�� -65 ~ 65 ���� ����
        // Mathf.Clamp(�����ϴ� ��, �ּҰ�, �ִ밪)
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -65, 65);
        transform.localEulerAngles = new Vector3(-mouseX, 0, 0);
    }

    public void RotateY(Rigidbody rigidbody)
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
        rigidbody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
}
