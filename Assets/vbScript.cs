using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbScript : MonoBehaviour, IVirtualButtonEventHandler
{

    //private GameObject vbButtonObject;
    // Private fields to store the models
    private GameObject model_1;
    private GameObject model_2;
    private GameObject model_3;
    private GameObject model_4;
    private GameObject no_1;
    private GameObject no_2;
    private GameObject no_3;
    private GameObject no_4;
	private string passwd = "";
    /// Called when the scene is loaded

    void Start()
    {
        //vbButtonObject = GameObject.Find("actionButton");
        //vbButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            // Register with the virtual buttons TrackableBehaviour
            vbs[i].RegisterEventHandler(this);
        }
        // Find the models based on the names in the Hierarchy
        model_1 = transform.FindChild("model1").gameObject;
        model_2 = transform.FindChild("model2").gameObject;
        model_3 = transform.FindChild("model3").gameObject;
        model_4 = transform.FindChild("model4").gameObject;

        no_1 = transform.FindChild("no1").gameObject;
        no_2 = transform.FindChild("no2").gameObject;
        no_3 = transform.FindChild("no3").gameObject;
        no_4 = transform.FindChild("no4").gameObject;
        // Show all numbers on startup
        model_1.SetActive(true);
        model_2.SetActive(true);
        model_3.SetActive(true);
        model_4.SetActive(true);
        no_1.SetActive(true);
        no_2.SetActive(true);
        no_3.SetActive(true);
        no_4.SetActive(true);
    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log(passwd);

		if (passwd.Length > 3) {
			
            if (passwd == "1234")
            {
                string plaintext = GameObject.Find("ARCamera").GetComponent<httpReq>().displayedmessage;
                GameObject.Find("Message").GetComponent<TextMesh>().text = plaintext;
            }
            else if (passwd.Length == 4)
            {
                GameObject.Find("Message").GetComponent<TextMesh>().text = "wrong password";
                passwd = ""; // reset password string
            }
            else
            {
                GameObject.Find("Message").GetComponent<TextMesh>().text = "";
            }
            

            passwd = ""; // reset password string
        }

			

        switch (vb.VirtualButtonName)
        {
		case "no1":
			no_1.SetActive (false);
			no_2.SetActive (true);
			no_3.SetActive (true);
			no_4.SetActive (true);
			model_1.SetActive (false);
			model_2.SetActive (true);
			model_3.SetActive (true);
			model_4.SetActive (true);

			passwd = passwd + "1";
			GameObject.Find("pin").GetComponent<TextMesh>().text = passwd; // display text

				
                break;
            case "no2":
                no_1.SetActive(true);
                no_2.SetActive(false);
                no_3.SetActive(true);
                no_4.SetActive(true);
                model_1.SetActive(true);
                model_2.SetActive(false);
                model_3.SetActive(true);
                model_4.SetActive(true);

				passwd = passwd + "2";
				GameObject.Find("pin").GetComponent<TextMesh>().text = passwd; // display text	
                break;
            case "no3":
                no_1.SetActive(true);
                no_2.SetActive(true);
                no_3.SetActive(false);
                no_4.SetActive(true);
                model_1.SetActive(true);
                model_2.SetActive(true);
                model_3.SetActive(false);
                model_4.SetActive(true);

				passwd = passwd + "3";
				GameObject.Find("pin").GetComponent<TextMesh>().text = passwd; // display text
	
                break;
            case "no4":
                no_1.SetActive(true);
                no_2.SetActive(true);
                no_3.SetActive(true);
                no_4.SetActive(false);
                model_1.SetActive(true);
                model_2.SetActive(true);
                model_3.SetActive(true);
                model_4.SetActive(false);

				passwd = passwd + "4";
				GameObject.Find("pin").GetComponent<TextMesh>().text = passwd; // display text
				
                break;
                //   default:
                //       throw new UnityException("Button not supported: " + vb.VirtualButtonName);
                //           break;
				

        }
    }
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log("button released");
    }

}

