using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        var tr = transform;
        var position = target.position;
        var pos = tr.position;

        tr.position = new Vector3(position.x, pos.y, pos.z);
    }
}
