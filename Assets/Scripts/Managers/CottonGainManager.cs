using UnityEngine;
using System.Collections;

public class CottonGainManager : MonoBehaviour {

	public Camera mainCamera;
	public CottonGain cottonGain;

	public void ShowCottonGain(Vector3 worldPosition,int cottons){
		cottonGain.setGain(cottons);
		CottonGain instantiated = Instantiate(cottonGain); 
		instantiated.transform.SetParent(this.transform);
		//instantiated.transform.localPosition = new Vector3 (0, 0, 0);
		instantiated.transform.localPosition = mainCamera.WorldToScreenPoint(worldPosition);//reset the local position, moving it to the center of the parent
		Vector3 delta = new Vector3 (Screen.width / 2, Screen.height / 2, 0) - instantiated.transform.localPosition;
		//instantiated.transform.localPosition -= delta;
		//instantiated.transform.localPosition = mainCamera.WorldToScreenPoint(worldPosition);//reset the local position, moving it to the center of the parent

	}
}
