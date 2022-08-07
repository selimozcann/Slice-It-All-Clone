using System.Linq;
using UnityEngine;

public class KnifeColliderController : Singleton<KnifeColliderController>
{
    [SerializeField] private Transform knifeBottom;
    private float rayDistance = 0.1f;

    private const string brickSliceStr = "UnCutSlice";
    private const string defaultStr = "Default";

    private bool isSlice = false;
    public bool IsSlice  { get => isSlice; set => isSlice = value; }
    
    private void FixedUpdate()
    {
       RayToMouse();
    }
    private void RayToMouse()
    {
        if (IsSlice)
            return;
        
        Collider[] overlapBox = Physics.OverlapSphere(knifeBottom.position,0.12f);
        foreach(var overLapCollider in overlapBox.Where(x => x.gameObject.layer == LayerMask.NameToLayer(brickSliceStr)))
        {
            overLapCollider.isTrigger = false;
            // KnifeMovement.I.InactiveToRb(true,false,CollisionDetectionMode.ContinuousSpeculative); 
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(knifeBottom.position, 0.12f);
    }
}
