using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [Header("Membership")]
    public GameObject MembershipUI;
    public InputField MembershipID;
    public InputField MembershipPW;
    public InputField MembershipFind;

    [Header("Login")]
    public GameObject LoginUI;
    public InputField LoginID;
    public InputField LoginPW;

    [Header("Find")]
    public GameObject FindUI;
    public InputField FindFind;

    [Header("ErrorMessage")]
    public GameObject ErrorUI;
    public Text ErrorMessage;

    public void MemberShipBtn()
    {
        PlayerPrefs.SetString("ID", MembershipID.text);
        PlayerPrefs.SetString("PW", MembershipPW.text);
        PlayerPrefs.SetString("FIND", MembershipFind.text);

        MembershipUI.SetActive(false);
        Debug.Log("Your Account is set up");
    }

    public void LoginBtn()
    {
        if (PlayerPrefs.GetString("ID") != LoginID.text)
        {
            LoginUI.SetActive(false);
            ErrorUI.SetActive(true);
            ErrorMessage.text = "ID does not match";
            Invoke("ErrorMessageExit", 3f);
            return;
        }

        if (PlayerPrefs.GetString("ID") != LoginID.text)
        {
            LoginUI.SetActive(false);
            ErrorUI.SetActive(true);
            ErrorMessage.text = "Password does not match";
            Invoke("ErrorMessageExit", 3f);
            return;
        }


        SceneManager.LoadScene("SelectScene");
    }

    public void FindBtn()
    {
        FindUI.SetActive(false);
        ErrorUI.SetActive(true);
        if (PlayerPrefs.GetString("FIND") == FindFind.text)
        {
            ErrorMessage.text = $"ID : {PlayerPrefs.GetString("ID")}\nPW : {PlayerPrefs.GetString("PW")}";
                
        }
        else
        {
            ErrorMessage.text = " This is a wrong hint. ";
        }
        Invoke("ErrorMessageExit", 3f);
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetString("ID"));
        Debug.Log(PlayerPrefs.GetString("PW"));
        Debug.Log(PlayerPrefs.GetString("FIND"));
    }
}
