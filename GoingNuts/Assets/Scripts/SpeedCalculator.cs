using UnityEngine;
using System.Collections;

public class SpeedCalculator : MonoBehaviour {

    public Transform node1;
    public Transform node2;
    public Transform node3;
    public Transform node4;
    public Transform node5;
    public Transform node6;
    public Transform node7;
    public Transform node8;

    float length1;
    float length2;
    float length3;
    float length4;
    float percentage1;
    float percentage2;
    float percentage3;
    float percentage4;

	// Use this for initialization
	void Start () {
        length1 = Mathf.Sqrt(Mathf.Pow(node1.position.x - node2.position.x, 2) + Mathf.Pow(node1.position.z - node2.position.z, 2));
        length2 = Mathf.Sqrt(Mathf.Pow(node3.position.x - node4.position.x, 2) + Mathf.Pow(node3.position.z - node4.position.z, 2));
        length3 = Mathf.Sqrt(Mathf.Pow(node5.position.x - node8.position.x, 2) + Mathf.Pow(node5.position.z - node8.position.z, 2));
        length4 = Mathf.Sqrt(Mathf.Pow(node6.position.x - node7.position.x, 2) + Mathf.Pow(node6.position.z - node7.position.z, 2));
        percentage1 = length1 / length1;
        percentage2 = length2 / length1;
        percentage3 = length3 / length1;
        percentage4 = length4 / length1;
        print("Length 1: " + length1 + " / Percentage 1: " + percentage1 + " / Speed: " + percentage1 * 5);
        print("Length 2: " + length2 + " / Percentage 2: " + percentage2 + " / Speed: " + percentage2 * 5);
        print("Length 3: " + length3 + " / Percentage 3: " + percentage3 + " / Speed: " + percentage3 * 5);
        print("Length 4: " + length4 + " / Percentage 4: " + percentage4 + " / Speed: " + percentage4 * 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
