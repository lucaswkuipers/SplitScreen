using UnityEngine;

public class CameraSpawner : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    public GameObject myPrefab;
    void Start()
    {
        Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void Update()
    {
        myPrefab.transform.position = transform.position + offset;
    }
}
