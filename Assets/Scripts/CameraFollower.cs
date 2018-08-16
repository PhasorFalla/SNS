using UnityEngine;

// Smooth match position to target object

[ExecuteInEditMode]
public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    public float bottom = -4.0f;
    public float lead = 2.5f;
    public float above = 1.5f;
    public float minView = 7.5f;
    private Vector3 velocity = Vector3.zero;


    public Vector3 offset = new Vector3(0, 0, -10f);

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0)) + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            Debug.Log("<color=yellow>" + this + "</color>" + " target not assigned", gameObject);
            return;
        }
    }

    private void LateUpdate()
    {
        if(target != null)
        {
            float height = target.position.y + above - bottom;
            height = Mathf.Max(height, minView);
            height /= 2.0f;
            Camera.main.orthographicSize = height;
            transform.position = new Vector3(target.position.x + lead, bottom + height, -10);
        }
    }
}