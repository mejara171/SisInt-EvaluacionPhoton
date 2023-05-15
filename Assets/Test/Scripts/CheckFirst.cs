using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFirst : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        if (PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion != "jp")
        {
            MessageManager.SetMessage(true,"Debes conectarte a la region\nde Japon. \nIntentalo nuevamente");
            return;
        }
        if(string.IsNullOrEmpty(PhotonNetwork.NickName))
        {
            MessageManager.SetMessage(true, "Debes especificar un NickName para poder continuar");
            return;
        }

        MessageManager.SetMessage(true, "Estas conectado a Photon.... Ahora podemos continuar");

        Invoke("CargarSiguienteEscena", 3);
    }

    public void CargarSiguienteEscena()
    {
        SceneManager.LoadScene("Test");
    }
}
