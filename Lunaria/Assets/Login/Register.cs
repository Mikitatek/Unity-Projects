using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField ConfirmPassInput;
    public Button RegisterButton;
    public Text Info;

    // Start is called before the first frame update
    void Start()
    {
        RegisterButton.onClick.AddListener(() =>
        {
            if(ConfirmPassInput.text == PasswordInput.text)
            StartCoroutine(Main.Instance.Web.RegisterUser(UsernameInput.text, PasswordInput.text));
            else
            {
                Info.text = "Passwords do not match!";
            }
        });
    }
}
