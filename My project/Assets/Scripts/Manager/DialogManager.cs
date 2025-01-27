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
    [SerializeField] ScrollRect scrollRect;
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

            // inputField에 있는 텍스트를 가져옴
            string talk = photonView.Owner.NickName + " : " + inputField.text;

            // RPC Target.All : 현재 룸에 있는 모든 클라이언트에게 Talk 함수를 실행하라는 명령을 합니다.
            photonView.RPC("Talk", RpcTarget.All, talk);

            scrollRect.verticalNormalizedPosition = 0.0f;
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        // Prefab을 하나 생선한 다음 Text 값을 설정합니다.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));
        talk.GetComponent<Text>().text = message;

        // 스크롤 뷰 = content 자식으로 등록
        talk.transform.SetParent(parentTransform);

        // 채팅을 입력한 후에도 이어서 입력할 수 있도록 설정
        inputField.ActivateInputField();

        scrollRect.verticalNormalizedPosition = 0.0f;

        // inputField의 텍스트를 초기화
        inputField.text = "";
    }
}
