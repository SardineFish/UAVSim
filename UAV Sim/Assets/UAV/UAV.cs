using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UAV : MonoBehaviour {
    public List<GameObject> PivotsObject = new List<GameObject>();

    public List<Pivot> Pivots = new List<Pivot>();

    new Rigidbody rigidbody;
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
}
