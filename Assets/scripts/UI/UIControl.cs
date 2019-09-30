using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour {

    private Quaternion RelativeRotation;
	// Use this for initialization
	void Start () {
        RelativeRotation = transform.parent.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = RelativeRotation;
	}
}
