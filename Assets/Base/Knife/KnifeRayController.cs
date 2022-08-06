using System.Linq;
using UnityEngine;

public class KnifeRayController : MonoBehaviour
{
    [SerializeField] private Transform knifeBottom;
    [SerializeField] private KnifeMovement knifeSliceController;
    private float rayDistance = 0.1f;

    private const string brickSliceStr = "UnCutSlice";
    private const string defaultStr = "Default";
    
    private void FixedUpdate()
    {
       RayToMouse();
    }
    private void RayToMouse()
    {
        Collider[] overlapBox = Physics.OverlapSphere(knifeBottom.position,0.17f);
        foreach(var overLapCollider in overlapBox.Where(x => x.gameObject.layer == LayerMask.NameToLayer(brickSliceStr)))
        {
            Debug.Log("LogFirst");
            overLapCollider.isTrigger = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(knifeBottom.position, 0.17f);
    }
}
