using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(-Physics.gravity * GetComponent<Rigidbody>().mass, ForceMode.Force);
        /*if (Input.GetMouseButton(0))
        return;
        if (Input.GetMouseButton(0))
            GetComponent<Rigidbody>().AddForce(-Physics.gravity * GetComponent<Rigidbody>().mass, ForceMode.Impulse);*/
    }
}
