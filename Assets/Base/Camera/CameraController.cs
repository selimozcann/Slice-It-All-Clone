using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private Vector3 dif;
    
    private void Start()
    {
        dif = transform.position - target.position;
    }
    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x + dif.x ,target.position.y + offset.y ,transform.position.z);
        }
    }
}
