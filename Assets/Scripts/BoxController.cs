using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour
{
    public float speed;
    private bool _isPaused;

    void Start()
    {
        _isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPaused) return;

        transform.position += Vector3.left * speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    void Pause()
    {
        _isPaused = true;
    }
}
