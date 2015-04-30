using UnityEngine;
using System.Collections;

public class PersistenceManager : MonoBehaviour {

	int money = 0 ;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("money")) {
			money = PlayerPrefs.GetInt("money");
			ScoreManager.score = money;
		}
	}
}
