using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UAV : MonoBehaviour {
    public List<GameObject> PivotsObject = new List<GameObject>();

    public List<Pivot> Pivots = new List<Pivot>();

    public Vector3 Acceleration;

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
    }
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        Acceleration = (rigidbody.velocity - lastV) / Time.fixedDeltaTime;
        lastV = rigidbody.velocity;

        
    }
}
