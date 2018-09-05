using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    public Canvas Canv;
    public Camera cam;
    // Use this for initialization
    void Awake () {
        Canv = GetComponent<Canvas>();
        cam = Canv.GetComponent<Camera>();
        cam = GameObject.FindGameObjectWithTag("Main Camera").GetComponent<Camera>();   
	}

    void Update()
    {
        if(cam == null)
        {
            cam = GameObject.FindObjectOfType<Camera>();

            Canv.worldCamera = cam;
        }
    }
	
	
}
