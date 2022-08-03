using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 dif;
    
    private void Start()
    {
        dif = transform.position - target.position;
    }
    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(transform.position.x,target.position.y,target.position.z) + dif;
        }
    }
}
