using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	float restartDelay = 5f;
	public BGMManager bgm;


    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
			GameOver();
        }
    }
	void GameOver()
	{
		PlayerPrefs.SetInt ("money", ScoreManager.score);
		anim.SetTrigger("GameOver");
		bgm.StopBGM();
		restartTimer += Time.deltaTime;
		
		if(restartTimer >= restartDelay)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		
	}
}
