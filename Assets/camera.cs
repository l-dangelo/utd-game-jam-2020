using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] Transform _objectToFollow = null;

    Vector3 _objectOffset;

    private void Awake()
    {
        //create an offset between this camera and ObjectToFollow
        _objectOffset = this.transform.position - _objectToFollow.position;
    }

    //cameras should always move last
    private void LateUpdate()
    {
        //apply offset every frame
        this.transform.position = _objectToFollow.position + _objectOffset;
    }
}