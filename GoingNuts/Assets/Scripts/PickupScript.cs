using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().totalPickups++;
            Destroy(this.gameObject);
        }
    }
}
