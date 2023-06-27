using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;

    private Transform _transform;
    
    private float verticalMovement;
    private float horizontalMovement;
    Vector3 currentMovement;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) verticalMovement = 1.0f * speed;
        if (Input.GetKey(KeyCode.A)) verticalMovement = -1.0f * speed;
        if (Input.GetKey(KeyCode.W)) horizontalMovement = 1.0f * speed;
        if (Input.GetKey(KeyCode.S)) horizontalMovement = -1.0f * speed;

        if (verticalMovement != 0.0f || horizontalMovement != 0.0f)
        {
            currentMovement = new Vector3(verticalMovement, horizontalMovement) * Time.deltaTime;
            _transform.position += currentMovement;
            verticalMovement = 0.0f;
            horizontalMovement = 0.0f;
        }
        // currentMovement = 
        //     new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * (speed * Time.deltaTime);
    }
}
