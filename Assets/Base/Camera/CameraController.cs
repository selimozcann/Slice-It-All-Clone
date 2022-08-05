using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private Vector3 dif;
    private Vector3 refVecCamera = Vector3.up;
    private float startVecY;

    private float targetYVec;

    private delegate int yValue();

    private void Start()
    {
        startVecY = transform.position.y;
        dif = transform.position - target.position;
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetVec = Vector3.SmoothDamp(transform.position, 
                new Vector3(target.position.x + dif.x, target.position.y + offset.y, transform.position.z), ref refVecCamera,0.9f);
            transform.position = targetVec;
        }
    }
}
