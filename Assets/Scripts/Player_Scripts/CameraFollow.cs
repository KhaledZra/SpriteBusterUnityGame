using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float smoothSpeed = 3f;
    [SerializeField] private float offsetDistance = 0.2f;

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
        _worldMouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 targetPos = (_worldMouseLocation - followTarget.position) * offsetDistance;
        targetPos = Vector3.ClampMagnitude(targetPos, 2);
        
        _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,  
            followTarget.position + new Vector3(targetPos.x, targetPos.y, -1f)
            , smoothSpeed * Time.deltaTime);
    }
}
