using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLFetcher : MonoBehaviour {

    public string qradress;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void SaveURL(string url)
    {
        qradress = url;
        Debug.Log(qradress);
    }
}
