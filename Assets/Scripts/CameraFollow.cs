using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private float offsetDistance = 1f;

    private Transform _cameraTransform;
    private Vector3 _worldMouseLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (followTarget.position != _cameraTransform.position)
        // {
        //     
        // }
        // todo optimize this, cause this is running per frame
        _worldMouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _worldMouseLocation = Vector3.Normalize(_worldMouseLocation) * offsetDistance;
        float newXLocation = followTarget.position.x + _worldMouseLocation.x;
        float newYLocation = followTarget.position.y + _worldMouseLocation.y;
        Vector3 smoothFollow = Vector3.Lerp(_cameraTransform.position, new Vector3(newXLocation, newYLocation, -1),
            smoothSpeed * Time.deltaTime);
        _cameraTransform.position = smoothFollow;
    }
}
