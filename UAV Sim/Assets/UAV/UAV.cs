using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UAV : MonoBehaviour {
    public List<GameObject> PivotsObject = new List<GameObject>();

    public List<Pivot> Pivots = new List<Pivot>();

    public Vector3 Acceleration;

    public Vector3 Velocity;

    public new Rigidbody rigidbody{ get; set; }

    private Vector3 lastV;
    // Use this for initialization
    [ExecuteInEditMode]
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        Pivots.Clear();
		foreach (var obj in PivotsObject)
		{
            var pivot = obj.GetComponent<Pivot>();
			if(!pivot)
			{
                pivot = obj.AddComponent<Pivot>();
            }
            Pivots.Add(pivot);
        }
        Velocity = rigidbody.velocity;
        HeightSet = HeightPreSet;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        //Velocity.y = PIDVelocity(5);
        //transform.Translate(Velocity * Time.fixedDeltaTime);
        Acceleration = (rigidbody.velocity - lastV) / Time.fixedDeltaTime;
        lastV = rigidbody.velocity;
        var acte = PIDAccelerate(HeightSet);
        if(acte>AccelerationLimit)
            acte = AccelerationLimit;
        else if (acte<-AccelerationLimit)
            acte = -AccelerationLimit;
        rigidbody.AddForce(new Vector3(0,acte,0), ForceMode.Acceleration);
    }
    public float PIDVelocity(float setPoint)
    {
        var error = setPoint - transform.position.y;
        return Kp * error;
    }

    public float HeightPreSet = 0;
    public float HeightSet { get; set; }

    public float AccelerationLimit = 0;

    public float Kp = 1f;
    public float Ki = 0;
    public float Kd = 0;
    public float Integral = 0;
    public float Derivative = 0;
    float lastError = 0;
    public float PIDAccelerate(float setPoint)
    {
        var error = setPoint - transform.position.y;
        Derivative = (error - lastError) / Time.fixedDeltaTime;
        lastError = error;
        Integral += error * Time.fixedDeltaTime;
        return Kp * error + Ki * Integral + Kd * Derivative;
    }
}
