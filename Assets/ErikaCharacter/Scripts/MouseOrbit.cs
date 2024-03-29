using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour 
{

    public Transform _XForm_Camera;
    public Transform _XForm_Parent;
    protected Vector3 _LocalRotation;
    protected float _CameraDistance = 5f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public bool CameraDisabled = false;

    void LateUpdate() {
        
		//Rotation of the Camera based on Mouse Coordinates
		if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
		{
			_LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
			_LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;
			//Clamp the y Rotation to horizon and not flipping over at the top
			if (_LocalRotation.y < 0f)
				_LocalRotation.y = 0f;
			else if (_LocalRotation.y > 90f)
				_LocalRotation.y = 90f;
		}
		//Zooming Input from our Mouse Scroll Wheel
		if (Input.GetAxis("Mouse ScrollWheel") != 0f)
		{
			float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;

			ScrollAmount *= (this._CameraDistance * 0.3f);

			this._CameraDistance += ScrollAmount * -1f;

			this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 5f);
		}

		//Actual Camera Rig Transformations
		Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);

        if(Input.GetKey(KeyCode.LeftAlt))
		this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

		if ( this._XForm_Camera.localPosition.z != this._CameraDistance * -1f )
		{
			this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
		}
    }
}