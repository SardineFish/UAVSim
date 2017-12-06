using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour {
    public float Force = 0;
    public float MaxPower;
    public float Power = 0;
    public UAV uav;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //uav.rigidbody.AddForceAtPosition(this.transform.position, Force * this.transform.up, ForceMode.Impulse);
	}

    private void FixedUpdate()
    {
        //uav.rigidbody.AddForceAtPosition(this.transform.position, Force * this.transform.up, ForceMode.Impulse);
    }

    public void Simulate()
    {
        uav.rigidbody.AddForce(Force * this.transform.up, ForceMode.Force);
    }
}
