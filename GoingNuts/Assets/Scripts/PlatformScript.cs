using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    bool onPad;
    Vector3 playerPos;
    Vector3 lastPos;
    GameObject player;

	// Use this for initialization
    void Start()
    {
        lastPos = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (onPad)
        {
            if (lastPos != this.gameObject.transform.position)
            {
                player.transform.position += (this.gameObject.transform.position - lastPos);

            }
            //player.transform.parent = this.gameObject.transform;
			print (player.transform.position);
        }
		print (this.gameObject.transform.position - lastPos);
        lastPos = this.gameObject.transform.position;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            onPad = true;
            player = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            onPad = false;
            player = null;
        }
    }
}
