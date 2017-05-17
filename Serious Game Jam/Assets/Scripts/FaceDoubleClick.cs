using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class FaceDoubleClick : MonoBehaviour { 

	// reference to the camera 
	private Camera camera; 

	// Local management of the double click 
	private bool recentlyclicked; 
	private float clickTimer; 

	// Perform the action to face the camera  
	private bool rotateToFaceCamera; 

	// Public settings for tweaking the performance of the double click 
	public float doubleClickDelayTimer; 

	// the position of the click in real world space  
	private Vector3 realWorldNormal; 

	// private variables 
	Vector3 cameralLookDirection; 
	Vector3 localNormal; 
	Quaternion requiredRotation; 
	Quaternion currentRotation; 

	public float rotationSpeed;

	float implementTimer; 

	// Use this for initialization 
	void Start () { 

		if (camera == null)  
		{ 
			camera = FindObjectOfType<Camera> (); 
		} 

		recentlyclicked = false; 
		rotateToFaceCamera = false; 
		requiredRotation = new Quaternion(); 
		implementTimer = 1.5f; 
		clickTimer = 0.0f; 

	} 



	// Update is called once per frame 
	void Update ()  
	{ 

		// detecting the double click 
		if (Input.GetMouseButtonDown (0) && recentlyclicked == false)  
		{ 
			// start a timer for detecting the second click 
			recentlyclicked = true; 
		} 
		else if ( recentlyclicked == true && clickTimer < doubleClickDelayTimer) 
		{ 

			clickTimer += Time.deltaTime; 

			if (Input.GetMouseButtonDown (0))  
			{ 

				// A double click has been detected  

				Ray ray = camera.ScreenPointToRay (Input.mousePosition); 
				RaycastHit hit; 

				if (Physics.Raycast (ray, out hit))  
				{ 
					realWorldNormal = hit.normal; 
					rotateToFaceCamera = true; 
					recentlyclicked = false; 
				} 
			} 
		} 
		else 
		{ 
			clickTimer = 0.0f; 
		} 



		// Time to rotate the camera 
		if (rotateToFaceCamera == true) 
		{ 
			// Convert the normal from world coordinates to local coordinates 
			localNormal = transform.InverseTransformDirection(realWorldNormal); 
			cameralLookDirection =  camera.transform.position - transform.position; 
			requiredRotation =  Quaternion.FromToRotation(localNormal, cameralLookDirection); 
			currentRotation = transform.localRotation; 
			implementTimer = 0.0f; 
			rotateToFaceCamera = false; 
		} 

		if(implementTimer < 2.0f) 
		{ 
			implementTimer += Time.deltaTime; 
			transform.rotation = Quaternion.Slerp (currentRotation, new Quaternion(requiredRotation.x, requiredRotation.y, 0.0f,requiredRotation.w), implementTimer*rotationSpeed); 
		} 

	} 

} 
