using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Chat;
using UnityEngine.UI;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0)
            {
                return;
            }

            // inputField�� �ִ� �ؽ�Ʈ�� ������
            string talk = photonView.Owner.NickName + " : " + inputField.text;

            // RPC Target.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk �Լ��� �����϶�� ����� �մϴ�.
            photonView.RPC("Talk", RpcTarget.All, talk);
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        // Prefab�� �ϳ� ������ ���� Text ���� �����մϴ�.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));
        talk.GetComponent<Text>().text = message;

        // ��ũ�� �� = content �ڽ����� ���
        talk.transform.SetParent(parentTransform);

        // ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� ����
        inputField.ActivateInputField();

        // inputField�� �ؽ�Ʈ�� �ʱ�ȭ
        inputField.text = "";


    }
}
