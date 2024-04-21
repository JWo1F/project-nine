using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        var transform1 = transform;
        var position = target.position;
        transform1.position = new Vector3(position.x, position.y, transform1.position.z);
    }
}
