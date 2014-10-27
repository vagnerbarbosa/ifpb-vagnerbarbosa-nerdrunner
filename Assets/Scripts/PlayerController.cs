using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		public float jumpVelocity;
		private bool _isJumping;
		private Animator _animator;
		private AudioSource _sfxJump;
		public GameObject obstacle;
		private bool _isPaused;

		// Use this for initialization
		void Start ()
		{		_isPaused = false;		
				_animator = GetComponent<Animator> ();
				_sfxJump = GetComponent<AudioSource> ();
				_isJumping = true;
		}

		// Update is called once per frame
		void Update ()
		{
				if (_isJumping)
						return;
		if (_isPaused) return;

				if (Input.GetMouseButtonDown (0)) {
						rigidbody2D.velocity = Vector2.up * jumpVelocity;
						_animator.SetTrigger ("Jump");
						_isJumping = true;
						_sfxJump.Play ();
				}

		}

		void OnCollisionEnter2D (Collision2D c)
		{

				if (c.collider.CompareTag ("Ground")) {
			if(_isPaused == true) {
				DieDude();
			} else {
						_animator.SetTrigger ("Run");
				_isJumping = false;}
				}


		}

	void DieDude(){
		_animator.SetTrigger("Die");
		_isPaused = true;
		Invoke ("DestroyPlayer", 1f);
		}

	void DestroyPlayer ()
	{
		Destroy (gameObject);
	}
	

}
