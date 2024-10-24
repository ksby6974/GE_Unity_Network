using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    //[SerializeField] Button roomCreateButton;
    [SerializeField] InputField roomTitleInputField;
    [SerializeField] InputField roomCapacityInputField;
    [SerializeField] Transform contentTransform;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string,GameObject>();
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        PhotonNetwork.CreateRoom(roomTitleInputField.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject temporaryRoom;

        foreach(RoomInfo room in roomList)
        {
            // ���� ������ ���
            if (room.RemovedFromList == true)
            {
                dictionary.TryGetValue(room.Name, out temporaryRoom);
                Destroy(temporaryRoom);
                dictionary.Remove(room.Name);
            }
            else
            {
                // ���� ������ ����Ǵ� ���
                if (dictionary.ContainsKey(room.Name) == false)
                {
                    GameObject roomObject = Instantiate(Resources.Load<GameObject>("Room"), contentTransform);
                    roomObject.GetComponent<RoomInformation>().SetData(room.Name, room.PlayerCount, room.MaxPlayers);
                    dictionary.Add(room.Name, roomObject);
                }
                else
                {
                    dictionary.TryGetValue(room.Name, out temporaryRoom);
                    temporaryRoom.GetComponent<RoomInformation>().SetData(room.Name, room.PlayerCount, room.MaxPlayers);
                }
            }
        }

        //�� ����

        //�� ������Ʈ

        //�� ����
        //InstantiateRoom();
    }





    /*
    public void InstantiateRoom()
    {
        foreach(RoomInfo roomInfo in dictionary.Values)
        {
            // 1. Room ������Ʈ ����
            GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

            // 2. Room ������Ʈ�� ��ġ�� ����
            room.transform.SetParent(contentTransform);

            // 3. Room ������Ʈ �ȿ� �ִ� Text �Ӽ��� ����
            room.GetComponent<RoomInformation>().SetData
            (
                roomInfo.Name,
                roomInfo.PlayerCount,
                roomInfo.MaxPlayers
            );
        }
    }
    */

    public void UpdateRoom()
    {

    }

    public void RemoveRoom()
    {

    }
}
