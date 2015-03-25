using UnityEngine;
using System.Collections;

public class OculusForwardDirScript : MonoBehaviour {

    public GameObject OcCamRot;
    public GameObject OcCam;
    bool OcCamOn;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update()
    {
        if(OcCamOn != this.gameObject.GetComponent<PlayerStats>().OcCamOn)
        {
            OcCamOn = this.gameObject.GetComponent<PlayerStats>().OcCamOn;
        }

        if (OcCamOn)
        {
            Vector3 forward = OcCamRot.transform.forward;
            this.gameObject.transform.forward = new Vector3(forward.x, 0, forward.z);
            OcCam.transform.position = this.gameObject.transform.position;
        }

	}
}
