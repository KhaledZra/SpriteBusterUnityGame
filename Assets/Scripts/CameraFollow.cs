using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
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
    void FixedUpdate()
    {
        
        
        // if (followTarget.position != _cameraTransform.position)
        // {
        //     
        // }
        // todo optimize this, cause this is running per frame
        
        // _worldMouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // _worldMouseLocation = Vector3.Normalize(_worldMouseLocation) * offsetDistance;
        // Vector3 newLocation = _followTarget.position + _worldMouseLocation; // todo invert logic, get direction and add distance/offset
        // Vector3 smoothFollow = Vector3.Lerp(_cameraTransform.position, new Vector3(newLocation.x, newLocation.y, -1),
        //     smoothSpeed * Time.deltaTime);
        // _cameraTransform.position = smoothFollow;
        
        _worldMouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 targetPos = (_worldMouseLocation - _followTarget.position) * 0.2f;
        targetPos = Vector3.ClampMagnitude(targetPos, 2);
        
        _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,  
            _followTarget.position + new Vector3(targetPos.x, targetPos.y, -1f)
            , smoothSpeed * Time.deltaTime);
    }
}
