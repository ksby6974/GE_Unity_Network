using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] string nickName;
    [SerializeField] InputField inputField;
    [SerializeField] Button button;

    public void SetName()
    {
        // 1. nickName�� inputField�� �Է��� ���� �����մϴ�.
        nickName = inputField.text;

        // 2. PhotonNetwork.NickName�� nickName ���� ����
        PhotonNetwork.NickName = nickName;

        // 3. NickName�� ����
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        // 4. ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField.text.Length <= 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
