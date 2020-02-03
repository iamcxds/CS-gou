using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollwer : MonoBehaviour {
    public Transform target;
    public float smoothing=5;
    Vector3 offset;
    internal static object main;

    // Use this for initialization
    void Start () {
        offset = transform.position - target.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
        Vector3 camTarget = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, camTarget, smoothing * Time.deltaTime);
		
	}
}
