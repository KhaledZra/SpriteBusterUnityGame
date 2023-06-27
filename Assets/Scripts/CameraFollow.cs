using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float smoothSpeed = 0.1f;
    // [SerializeField] private Vector3 offset;
    // [SerializeField] private bool isCustomOffset;
    
    private Transform _cameraTransform;
    private Vector3 newLocation;

    private Vector3 worldMouseLocation;
    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = GetComponent<Transform>();
        // You can also specify your own offset from inspector
        // by making isCustomOffset bool to true
        // if (!isCustomOffset)
        // {
        //     offset = _transform.position - followTarget.position;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // if (followTarget.position != _cameraTransform.position)
        // {
        //     
        // }
        // todo optimize this, cause this is running per frame
        worldMouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMouseLocation = Vector3.Normalize(worldMouseLocation) / 2;
        float newXLocation = followTarget.position.x + worldMouseLocation.x;
        float newYLocation = followTarget.position.y + worldMouseLocation.y;
        Vector3 smoothFollow = Vector3.Lerp(_cameraTransform.position, new Vector3(newXLocation, newYLocation, -1),
            smoothSpeed * Time.deltaTime);
        _cameraTransform.position = smoothFollow;


        // if (followTarget.position != _cameraTransform.position)
        // {
        //     //var position = followTarget.position + offset;
        //     // var position = followTarget.position;
        //     // newLocation = new Vector3(position.x, position.y, -1);
        //     // Vector3 smoothFollow = Vector3.Lerp(_transform.position, newLocation, smoothSpeed * Time.deltaTime);
        //     // _transform.position = smoothFollow;
        //     
        //     //_transform.LookAt(position); // no idea what this does
        // }
    }
}
