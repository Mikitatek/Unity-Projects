using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class userInsert : MonoBehaviour
{
    string URL = "http://localhost/lunaria/userInsert.php";
    public string InputUsername, InputEmail, InputPassword;

    [SerializeField] public TMP_InputField usernameInput;
    [SerializeField] public TMP_InputField emailInput;
    [SerializeField] public TMP_InputField passwordInput;

    [SerializeField] private Button loginButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddUser(usernameInput.text, emailInput.text, passwordInput.text);
        }
    }

    public void AddUser(string username, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("addUsername", username);
        form.AddField("addEmail", email);
        form.AddField("addPassword", password);

        WWW www = new WWW(URL, form);
    }

}
