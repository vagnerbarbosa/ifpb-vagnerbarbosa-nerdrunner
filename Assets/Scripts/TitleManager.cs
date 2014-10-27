using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();		

		
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			Collider2D[] objs = Physics2D.OverlapPointAll(pos);
			
			if (objs.Length > 0)
				foreach (Collider2D c in objs)
					if (c.CompareTag("BtStart"))
						Application.LoadLevel("Main");
			else if 	(c.CompareTag("BtAbout")) Application.LoadLevel("About");

		}
	}
}
