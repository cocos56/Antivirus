using UnityEngine;

public class FollowTarget : MonoBehaviour {
    public Transform playerTransform;
    public float smoothing=5;

    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        Vector3 newCameraPos = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newCameraPos, smoothing * Time.deltaTime);
    }
}
