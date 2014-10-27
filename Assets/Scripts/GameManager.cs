using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject btRestart;
    public TextMesh hiScore;
    public TextMesh score;
	private GameObject _manager;

    private int _hiScore;
    private int _score;
	private AudioSource[] _sfx;
	private const int _point = 0, _die = 1, _bgMusic = 2;

    private bool _isGameOver;

	public TextMesh stamina;		
	private float _currentRateStamina;
	public float rateStamina;

    // Use this for initialization
    void Start()

    {
		StartCoroutine("DamageRateCoroutine");
		_manager = GameObject.FindGameObjectWithTag ("Player");

        _hiScore = PlayerPrefs.GetInt("hiscore", 0);

		_sfx = GetComponents<AudioSource>();

        hiScore.text = "" + _hiScore;

		_sfx [_bgMusic].Play ();

        btRestart.SetActive(false);
        _isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("Title");

        if (!_isGameOver) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D[] objs = Physics2D.OverlapPointAll(pos);

            if (objs.Length > 0)
                foreach (Collider2D c in objs)
                    if (c.CompareTag("BtRestart"))
                        Application.LoadLevel(Application.loadedLevel);
        }
    }

    void GameOver()
    {
        BroadcastMessage("Pause");
		_sfx [_bgMusic].Stop ();
		_sfx [_die].Play ();
        btRestart.SetActive(true);
        _isGameOver = true;
		_manager.SendMessage ("DieDude");
    }

    void PlayerScored()
    {
        if (++_score > _hiScore)
        {
            _hiScore = _score;
            hiScore.text = "" +_hiScore;
            PlayerPrefs.SetInt("hiscore", _hiScore);
        } 
		_sfx [_point].Play ();
        score.text = "" + _score;
    }

	void PlayerHealer(){
		stamina.text = "" + 99 + "%";
		rateStamina = 99;
		}

	void PlayerDamage()
	{
		_currentRateStamina -= Time.frameCount;
		if (rateStamina == 0) {
			GameOver();

		} else if	(_currentRateStamina < rateStamina) {
						stamina.text = "" + --rateStamina + "%";
				} 
	}
	
	IEnumerator DamageRateCoroutine() {
		while (_isGameOver == false) // prendemos a coroutine para ela não termine "nunca"
		{
			PlayerDamage(); // ... Executamos o método computacionalmente pesado ...
			yield return new WaitForSeconds(0.1f); // ... aguardamos 100 milisegundos ...
		}
	}

}
