using UnityEngine;
using System.Collections;

public class ObstacleBehavior : MonoBehaviour {

	public float speed;
	public GameObject obstacle;
	private GameObject _manager;


	private bool _isPaused;

	// Use this for initialization
	void Start () {
		_isPaused = false;
		_manager = GameObject.FindGameObjectWithTag ("GameManager");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (_isPaused) return;

		transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;


		if (transform.position.x < -8f) {
			obstacle.SetActive(false);
				}
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.CompareTag("Player"))
		{   
			_manager.SendMessage ("PlayerScored");         
			_manager.SendMessage ("PlayerHealer");
			obstacle.SetActive(false);
			
			
		}
	}
	
	void Pause()
	{
		_isPaused = true;
	}


}
