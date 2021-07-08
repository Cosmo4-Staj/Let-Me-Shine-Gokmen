using UnityEngine;

public class CamFollow : MonoBehaviour

{
    public Transform target;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }
    
    void Update()
    {
        transform.position = target.position + offset;
    }
}
