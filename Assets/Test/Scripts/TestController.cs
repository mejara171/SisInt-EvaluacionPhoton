using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public static void StartTest()
    {
        MessageManager.SetMessage(true, "Ok Listo!!.Para empezar debes encontrar el cuarto donde se esta realizando la prueba\nrevisa la lista de cuartos disponibles, no sera dificil de intentificar");
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        MessageManager.SetMessage(true, "Te has unido a un cuarto... sera el inidcado?? \nSolo el tiempo lo dira");
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == 1)
        {
            //Evento al ingrear al cuarto correcto
            object[] data = (object[])photonEvent.CustomData;
            MessageManager.SetMessage(true, (string)data[0]);
        }
        if (eventCode == 3)
        {
            //Evento al solicitar mision 1
            object[] data = (object[])photonEvent.CustomData;
            MessageManager.SetMessage(true, (string)data[0]);
        }
        if (eventCode == 4)
        {
            //Evento mision instanciacion fallo
            object[] data = (object[])photonEvent.CustomData;
            MessageManager.SetMessage(true, (string)data[0]);
        }
        if (eventCode == 5)
        {
            //Evento mision instanciacion cummplida
            object[] data = (object[])photonEvent.CustomData;
            MessageManager.SetMessage(true, (string)data[0]);
        }

        if (eventCode == 6)
        {
            //Evento mision RPC cumplida
            object[] data = (object[])photonEvent.CustomData;
            MessageManager.SetMessage(true, (string)data[0]);
        }
        if (eventCode == 9)
        {
            //Evento mision Event fallida
            object[] data = (object[])photonEvent.CustomData;
            MessageManager.SetMessage(true, (string)data[0]);
        }
        if (eventCode == 10)
        {
            //Evento mision Event cumplida
            object[] data = (object[])photonEvent.CustomData;
            MessageManager.SetMessage(true, (string)data[0]);
        }
    }
}
