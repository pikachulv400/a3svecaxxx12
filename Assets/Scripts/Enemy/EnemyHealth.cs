using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue;
    public AudioClip deathClip;
	public GameObject chocoBar;
	public int probablityToSpawnChoc;
	CottonGainManager cottonGainManager;
	
	
    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
		GameObject hud = GameObject.FindGameObjectsWithTag ("HUD Canvas")[0];
		cottonGainManager = hud.GetComponents<CottonGainManager>()[0];

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
		ProbablityToSpawn (probablityToSpawnChoc, chocoBar);
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
		cottonGainManager.ShowCottonGain (transform.position,scoreValue);
		ScoreManager.score += scoreValue;
        Destroy (gameObject, 1f);
    }
	public void ProbablityToSpawn(int p, GameObject g)
	{
		if (Random.Range (0, 100) <= p) {
			Vector3 chocPosition = this.gameObject.transform.position;
			chocPosition += new Vector3(0,0.8f,0);
			Instantiate (g,chocPosition, this.gameObject.transform.rotation);
		}
	}
}
