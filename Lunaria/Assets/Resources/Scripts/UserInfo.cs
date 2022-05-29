using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{

    public string UserOwnerID { get; private set; }
    string UserName;
    string UserPassword;
    string Level;
    string Coins;

    public void SetCredentials(string username, string userpassword)
    {
        UserName = username;
        UserPassword = userpassword;
    }

    public void setID(string id)
    {
        UserOwnerID = id;
    }
}
