using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PathPoint : Info {

    public bool DrawPath = true; 
    public GameObject NextPathPoint; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
// Perform only if in Unity Editor
#if UNITY_EDITOR
        if (NextPathPoint && DrawPath)
        {
            Debug.DrawLine(gameObject.transform.position, NextPathPoint.transform.position, Color.red); 
        }
#endif   
    }
}
