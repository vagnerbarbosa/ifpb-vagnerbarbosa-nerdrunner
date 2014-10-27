using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleController : MonoBehaviour {

	public float maxHeight;
	public float minHeight;
	public float rateSpawn;
	public GameObject prefabObstacle;
	public List<GameObject> obstacle;
	public int maxObstacle;
	private GameObject _manager;
	GameObject tempObstacle = null;

	private float _currentRateSpawn;
	private bool _isPaused;

		
	void Start()
	{
		_isPaused = false;
		
		for(int i = 0; i < maxObstacle; i++ ) {
			GameObject tempObstacle = GameObject.Instantiate(prefabObstacle) as GameObject;
			obstacle.Add(tempObstacle);
			tempObstacle.SetActive(false);
			
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		if (_isPaused) return;
		
		_currentRateSpawn += Time.deltaTime;
		
		if (_currentRateSpawn > rateSpawn) {
			_currentRateSpawn = 0;
			SpawnObstacles();
		}
	}
	
	void Pause()
	{
		_isPaused = true;
	}

	private void SpawnObstacles(){
		float randPosition = Random.Range (minHeight, maxHeight);

		
		for(int i = 0; i < maxObstacle; i++ ) {
			if (obstacle[i].activeSelf == false) {
				tempObstacle = obstacle[i];
				break;
			}
			
		}
		if (tempObstacle != null) {
			tempObstacle.transform.position = new Vector3(transform.position.x, randPosition, transform.position.z);
			tempObstacle.SetActive(true);

		}
	}

	void ObstacleTempDestroy(){
		tempObstacle.SetActive (false);
	}

}
