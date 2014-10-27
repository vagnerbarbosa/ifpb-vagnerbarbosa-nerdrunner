using UnityEngine;
using System.Collections;

public class TextureController : MonoBehaviour
{
    public float scrollSpeed;
    private float _offSet;
    private bool _isPaused;

    // Use this for initialization
    void Start()
    {
        _isPaused = false;
        _offSet = 0;
        renderer.material.mainTextureOffset = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPaused) return;

        _offSet += scrollSpeed;

        if (_offSet > 1f)
            _offSet -= 1f;

        renderer.material.mainTextureOffset = Vector2.right * _offSet;
    }

    void Pause()
    {
        _isPaused = true;
    }
}
