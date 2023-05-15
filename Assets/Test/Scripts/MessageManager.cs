using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{
    private static GameObject CanvasMessage;

    private void Awake()
    {
        CanvasMessage = GameObject.Find("CanvasMessage");
    }

    public static void SetMessage(bool show,string message)
    {
        CanvasMessage.SetActive(show);
        CanvasMessage.GetComponentInChildren<TMP_Text>().text  = message;
    }

}
