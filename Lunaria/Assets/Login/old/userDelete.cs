using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userDelete : MonoBehaviour
{
    string URL = "http://localhost/lunaria/userDelete.php";
    public string WhereField, WhereCondition;

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            DelUser(WhereField, WhereCondition);
        }*/
    }

    public void DelUser(string wF, string wC)
    {
        WWWForm form = new WWWForm();
        form.AddField("whereField", wF);
        form.AddField("whereCondition", wC);

        WWW www = new WWW(URL, form);
    }
}
