using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 2f;
    public float sens = 3f;

    public float minX = -360;
    public float maxX = 360;
    public float minY = -60;
    public float maxY = 60;

    private Quaternion originalRot;
    private float rotX = 0;
    private float rotY = 0;

    public GameObject Camera;

	void Start () {

        Rigidbody body = GetComponent<Rigidbody>();

        if(body)
        {
            body.freezeRotation = true;
        }

        originalRot = transform.localRotation;
	}
	
	
	void Update () {

        CameraControl();
        controlWASD();
    }

    void controlWASD()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
    }

    void CameraControl()
    {
        
        rotX += Input.GetAxis("Mouse X") * sens;
        rotY += Input.GetAxis("Mouse Y") * sens;

        rotX = rotX % 360;
        rotY = rotY % 360;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

        Camera.transform.localRotation = originalRot * xQuaternion * yQuaternion;
    }
}
