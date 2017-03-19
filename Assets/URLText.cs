using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLText : MonoBehaviour {


	void Update () {
        GetComponent<TextMesh>().text = GameObject.Find("URL").GetComponent<URLFetcher>().qradress;
        string url = GameObject.Find("URL").GetComponent<URLFetcher>().qradress;
     //   GameObject.Find("ARCamera").GetComponent<httpReq>().GetMessage(url);
	}
}
