using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RgbRotatingSprite : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;   
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _spriteRenderer.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));
    }
}
