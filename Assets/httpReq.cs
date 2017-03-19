using System.Collections;
using SimpleJSON;
using System.Collections.Generic;

using UnityEngine;



public class httpReq : MonoBehaviour
{
    public string displayedmessage;


    // Use this for initialization

    void Start()
    {





        string url = GameObject.Find("URL").GetComponent<URLFetcher>().qradress;
           



        WWWForm form = new WWWForm();

        form.AddField("password", "1234");

        WWW www = new WWW(url, form);



        StartCoroutine(WaitForRequest(www));

    }



    IEnumerator WaitForRequest(WWW www)

    {

        yield return www;



        // check for errors

        if (www.error == null)

        {

            Debug.Log("WWW Ok!: " + www.text);
            displayedmessage = JSON.Parse(www.data)["message"];
            //GameObject.Find("Message").GetComponent<TextMesh>().text = message;
        }

        else

        {

            Debug.Log("WWW Error: " + www.error);

        }



    }



    // Update is called once per frame

    void Update()
    {



    }

}