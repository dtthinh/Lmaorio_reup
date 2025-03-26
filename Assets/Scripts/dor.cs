using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dor : MonoBehaviour {

	public static dor instance;
	public int Levelload = 1;
	public gamemaster gm;
	private Animator anim;
	private BoxCollider2D box;
	public int points = 0;
	[HideInInspector]
	public int collectablesCount;

	void Awake(){
		MakeInstance ();
		anim = GetComponent<Animator>();
		box = GetComponent<BoxCollider2D> ();
	}

	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void DecrementCollectables(){
		collectablesCount--;

		if (collectablesCount == 0) {
			StartCoroutine(OpenDoor());
		}
	}

	IEnumerator OpenDoor(){
		anim.Play ("idel");
		yield return new WaitForSeconds (.7f);
		box.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.CompareTag("Player"))
		{
			savescore();
			gm.Inputtext.text = ("Press E to enter");
		}
	}
	void OnTriggerStay2D(Collider2D target){
		if (target.CompareTag("Player"))
		{
			if (Input.GetKey(KeyCode.E))
			{
				savescore();
				SceneManager.LoadScene(Levelload);
			}
		}

	}
	void OnTriggerExit2D(Collider2D target){
		if (target.CompareTag("Player"))
		{
			gm.Inputtext.text = ("");
		}
	}
	void savescore()
	{
		if (Application.loadedLevel == 0) {
			PlayerPrefs.DeleteKey ("pointss");
			points = 0;
		} else {
			points = PlayerPrefs.GetInt ("pointss");
		}
	}
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();

	}

	// Update is called once per frame
	void Update () {

	}
}
