using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOverride : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector2.zero;
        //GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }
}
