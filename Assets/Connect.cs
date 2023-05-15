using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Connect : MonoBehaviourPunCallbacks, IOnEventCallback
{
    private List<RoomInfo> roomList;

    void Start()
    {
        SetNickname("Maria Jose");
        ChangeRegion("jp");
    }

    public void ChangeRegion(string regionCode)
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = regionCode;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void SetNickname(string nickname)
    {
        PhotonNetwork.NickName = nickname;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRoom("Cuarto de la Evaluacion");
    }

    public override void OnJoinedRoom()
    {
        Room currentRoom = PhotonNetwork.CurrentRoom;
        var customProperties = currentRoom.CustomProperties;

        foreach (var prop in customProperties)
            Debug.Log(prop.Key + ": " + prop.Value);

        byte eventCode = 2;
        byte[] eventData = new byte[0];
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.MasterClient };
        PhotonNetwork.RaiseEvent(eventCode, eventData, raiseEventOptions, SendOptions.SendReliable);

        object[] instantiationData = { PhotonNetwork.LocalPlayer.UserId };
        PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity, 0, instantiationData);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == 7)
        {
            object[] data = (object[])photonEvent.CustomData;
            print((string)data[0]);

            object[] lastEventData = new object[1];
            lastEventData[0] = data[1];
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.MasterClient };
            PhotonNetwork.RaiseEvent(8, lastEventData, raiseEventOptions, SendOptions.SendReliable);
        }
    }

}