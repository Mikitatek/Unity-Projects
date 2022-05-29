using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField ConfirmPassInput;
    public InputField NewPassword;
    public Button ResetButton;

    // Start is called before the first frame update
    void Start()
    {
        ResetButton.onClick.AddListener(() =>
        {
            if (ConfirmPassInput.text == NewPassword.text)
                StartCoroutine(Main.Instance.Web.ResetPassword(UsernameInput.text, PasswordInput.text, NewPassword.text));
            else
            {
                Debug.Log("Passwords do not match!");
            }
        });
    }
}
