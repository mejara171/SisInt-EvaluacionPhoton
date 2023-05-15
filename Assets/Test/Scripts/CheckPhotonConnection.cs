using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPhotonConnection : MonoBehaviourPunCallbacks
{


    void Awake()
    {    

        if (!PhotonNetwork.IsConnected)
        {
            MessageManager.SetMessage(true, "Debes conectarte a Photon para iniciar la prueba");
        }
       

    }
    public override void OnConnectedToMaster()
    {
        if (PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion != "jp")
        {
            MessageManager.SetMessage(true, "Debes conectarte a la region\nde Japon. \nIntentalo nuevamente");
            return;
        }
        if (string.IsNullOrEmpty(PhotonNetwork.NickName))
        {
            MessageManager.SetMessage(true, "Debes especificar un NickName para poder continuar");
            return;
        }

        MessageManager.SetMessage(true, "Estas conectado a Photon.... Ahora podemos continuar");

         TestController.StartTest();
    }

}
