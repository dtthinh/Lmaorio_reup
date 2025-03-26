using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour {

	public float speed = 50f, maxspeed = 3, jumpPow = 220f;
	public bool grounded = true, faceright = true, doublejump = false;

	public int ourHealth;
	public int maxhealth = 5;
	public gamemaster gm;
	public Rigidbody2D r2;
	public Animator anim;
	public SoundManager sound;

	// Use this for initialization
	void Start () {
		r2 = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
		sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
		ourHealth = maxhealth;
	}

	// Update is called once per frame
	void Update () {
		anim.SetBool("Grounder", grounded);
		anim.SetFloat("Speed", Mathf.Abs(r2.linearVelocity.x));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded)
			{
				sound.Playsound("jup");
				grounded = false;
				doublejump = true;
				r2.AddForce(Vector2.up * jumpPow);

			}

			else
			{
				if (doublejump)
				{
					doublejump = false;
					r2.linearVelocity = new Vector2(r2.linearVelocity.x, 0);
					r2.AddForce(Vector2.up * jumpPow * 1.5f);

				}
			}




		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		r2.AddForce((Vector2.right) * speed * h);

		if (r2.linearVelocity.x > maxspeed)
			r2.linearVelocity = new Vector2(maxspeed, r2.linearVelocity.y);
		if (r2.linearVelocity.x < -maxspeed)
			r2.linearVelocity = new Vector2(-maxspeed, r2.linearVelocity.y);

		if (h>0 && !faceright)
		{
			Flip();
		}

		if (h < 0 && faceright)
		{
			Flip();
		}

		if (grounded)
		{
			r2.linearVelocity = new Vector2(r2.linearVelocity.x * 0.7f, r2.linearVelocity.y);
		}

		if (ourHealth <= 0)
		{
			Death();
		}
	}

	public void Flip()
	{
		faceright = !faceright;
		Vector3 Scale;
		Scale = transform.localScale;
		Scale.x *= -1;
		transform.localScale = Scale;
	}

	public void Death()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		if (PlayerPrefs.HasKey ("Highscoress")) {
			if (PlayerPrefs.GetInt ("Highscoress") < gm.points) {
				PlayerPrefs.SetInt ("Highscoress", gm.points);
			}
		} else {
			PlayerPrefs.SetInt ("Highscoress", gm.points);
		}
	}
	public void Damage(int damage)
	{
		ourHealth -= damage;
		gameObject.GetComponent<Animation>().Play("redflash");
	}public void Knockback (float Knockpow, Vector2 Knockdir)
	{
		r2.linearVelocity = new Vector2(0, 0);
		r2.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y * Knockpow));
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("heart"))
		{
			sound.Playsound("kick");
			Destroy(col.gameObject);
			ourHealth = 5;
		}
		if (col.CompareTag("shoe"))
		{
			sound.Playsound("bump");
			Destroy(col.gameObject);
			maxspeed = 6f;
			speed = 100f;
			jumpPow = 620f;
			StartCoroutine(timecount(5));
		}
	}
	IEnumerator timecount (float time)
	{
		yield return new WaitForSeconds(time);
		maxspeed = 3f;
		speed = 50f;
		jumpPow = 320f;
		yield return 0;
	}
}