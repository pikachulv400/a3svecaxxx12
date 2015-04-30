using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CottonGain : MonoBehaviour {

	public Image gainImage;
	public Text gainText;
	float speed = 60f;
	float ttl = 2f;

	void Update () {
		float y = Time.deltaTime * speed;
		gainImage.color -= new Color(0,0,0, 0.02f);
		gainText.color -= new Color(0,0,0, 0.02f);
		transform.Translate(0,y,0);
		ttl -= Time.deltaTime;
		if (ttl < 0 ) {
			Destroy (gameObject);
		}
	}
	public void setGain(int cottons) {
		this.gainText.text = "+" + cottons;
	}
}
