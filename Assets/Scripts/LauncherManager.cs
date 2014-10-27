using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LauncherManager : MonoBehaviour
{
    private bool _isPaused;
	public int maxObstacle;
	public GameObject prefab;
	public List<GameObject> obstacle;
	private float _currentRateSpawn;
	public float maxHeight;
	public float minHeight;
	public float rateSpawn;

    // Use this for initialization
    void Start()
    {
        _isPaused = false;
        Invoke("Launch", 1f);
    }

    void Launch()
    {
        if (_isPaused) return;


        Invoke("Launch", 1.5f);
    }

    void Pause()
    {
        _isPaused = true;
    }

}
