using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPunInstantiateMagicCallback
{
    private PhotonView _PhotonView;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        _PhotonView = GetComponent<PhotonView>();
        _PhotonView.RPC("MisionRPC", RpcTarget.MasterClient);
        print("RPC sent");
    }
}

