using UnityEngine;
using System.Collections;

public class ChocolateBarScript : MonoBehaviour {

	// Use this for initialization
	float ttl = 10;
	int blinkspeed = 3;
	PlayerHealth playerHealth;
	Renderer renderer;
	void Start () {
		renderer = GetComponentInChildren<Renderer> ();
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		ttl -= Time.deltaTime;
		if (ttl < 8) {
			renderer.material.color = new Color (1, 1, 1, (Mathf.Sin(ttl * blinkspeed)/3)+0.7f);
		}
		Debug.Log (renderer.material.color);
		if(ttl <= 0 ){
			//TODO sound clip
			Destroy(this.gameObject);
		}
		transform.Rotate (0f, 1f, 0f);

	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.name == "Player") {
			Destroy(this.gameObject);
			playerHealth.addHealth (30);
		}
	}
}
