using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Game : MonoBehaviour
{
    public Text instructs;
    public Button startBut;

    public void StartGame()
    {
        instructs.gameObject.SetActive(false);
        startBut.gameObject.SetActive(false);
    }
}
