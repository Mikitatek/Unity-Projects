using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Web : MonoBehaviour
{
    bool inInventory = false;
    bool loggedIn = false;
    public Text Information;
    public Text LoggedInAs;


    void Start()
    {
        Main.Instance.UserProfile.SetActive(false);
        //StartCoroutine(GetDate());
        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("testuser", "12345678"));
        //StartCoroutine(RegisterUser("mikitatek", "parola123"));
    }

    //public void ShowUserItems()
    //{
    //    StartCoroutine(GetUserItems(Main.Instance.UserInfo.UserOwnerID());
    //}

    public IEnumerator GetDate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/lunaria/GetDate.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Information.text = www.error;
            }
            else
            {
                //rezultat text
                Information.text = www.downloadHandler.text;

                //rezultatele in un array binar
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/lunaria/GetUsers.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Information.text = www.error;
            }
            else
            {
                //rezultat text
                Information.text = www.downloadHandler.text;

                //rezultatele in un array binar
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lunaria/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Information.text = www.error;
            }
            else
            {
                Information.text = www.downloadHandler.text;
                LoggedInAs.text = username;
                Main.Instance.UserInfo.SetCredentials(username, password);
                Main.Instance.UserInfo.setID(www.downloadHandler.text);

                if (www.downloadHandler.text.Contains("Wrong Credentials") || www.downloadHandler.text.Contains("Username does not exist"))
                {
                    Information.text = "Try Again";
                }
                else
                {
                    loggedIn = true;
                }
            }
        }
    }

    void Update()
    {
        if (loggedIn && Input.GetKeyDown(KeyCode.Minus) && inInventory == false)
        {
            Main.Instance.UserProfile.SetActive(true);
            inInventory = true;
        }
        else if(Input.GetKeyDown(KeyCode.Minus) && Main.Instance.UserProfile.active == true && inInventory == true)
        {
            Main.Instance.UserProfile.SetActive(false);
            inInventory = false;
        }
    }


    public IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lunaria/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Information.text = www.error;
            }
            else
            {
                Information.text = www.downloadHandler.text;
            }
        }
    }

    public IEnumerator ResetPassword(string username, string password, string newPassword)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        form.AddField("newPass", newPassword);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lunaria/ResetPassword.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Information.text = www.error;
            }
            else
            {
                Information.text = www.downloadHandler.text;
            }
        }
    }

    public IEnumerator GetUserItems(string userOwnerID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userOwnerID", userOwnerID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lunaria/GetItemsIDs.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //rezultat text
                Debug.Log(www.downloadHandler.text);
                string jsonArrayString = www.downloadHandler.text;

                //call callback function to pass results
                callback(jsonArrayString);
            }
        }
    }

    public IEnumerator GetItem(string itemID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lunaria/GetItem.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //rezultat text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                //call callback function to pass results
                callback(jsonArray);
            }
        }
    }

}
