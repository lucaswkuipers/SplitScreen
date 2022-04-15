using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
