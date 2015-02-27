using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {

    public GameObject WarningText;
	public int speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(new Vector3(0,0,-5), Vector3.up, speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WarningText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WarningText.SetActive(false);
        }
    }
}
