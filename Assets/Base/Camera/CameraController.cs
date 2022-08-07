using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private Vector3 dif;
    private Vector3 refVecCamera = Vector3.up;
    private float startVecY;
    private float targetYVec = -0.05f;
    private float offsetY;
    private float smoothTime = 0.8f;

    private void Start()
    {
        startVecY = target.position.y;
        dif = transform.position - target.position;
    }
    private void LateUpdate()
    {
        if (target != null)
        {
            float yMove = target.position.y >= startVecY ? target.position.y + dif.y : transform.position.y  + targetYVec;
            Vector3 targetVec = new Vector3(target.position.x + dif.x, yMove, transform.position.z);
            Vector3 currentVec = Vector3.SmoothDamp(transform.position, targetVec , ref refVecCamera,smoothTime);
            transform.position = currentVec;
        }
    }
}
