using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterSelectionSceneController : MonoBehaviour
{
    public Text loggedInIDText;

    void Start()
    {
        string loggedInID = PlayerPrefs.GetString("ID");
        loggedInIDText.text = "ID : " + loggedInID;
    }
}
