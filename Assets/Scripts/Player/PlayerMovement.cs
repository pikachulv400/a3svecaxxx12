using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		float hr = CrossPlatformInputManager.GetAxis("HorizontalRotate");
		float vr = CrossPlatformInputManager.GetAxis("VerticalRotate");

		Move (h, v);
		Turning (hr,vr);
		Animating (h, v);
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning(float hr, float vr)
	{
		if (!(hr != 0 || vr != 0)) {
			return;
		}

		hr = hr * Screen.width/2 + Screen.width/2;
		vr = vr * Screen.height/2 + Screen.height/2;
		Ray camRay = Camera.main.ScreenPointToRay (new Vector3(hr,vr,0));
		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h,float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}
