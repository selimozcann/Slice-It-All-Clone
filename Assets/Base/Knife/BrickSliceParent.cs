using UnityEngine;
public class BrickSliceParent : MonoBehaviour
{
    [SerializeField] private Collider mainSlice;
    [SerializeField] private BoxCollider leftCollider, rightCollider;
    [SerializeField] private GameObject lefRightParentBrick;
    public Rigidbody rightBrickRb;
    public Rigidbody leftBrickRb;

    [SerializeField] private bool isBrickForce;
    public virtual bool IsBrickForce { get => isBrickForce; set => isBrickForce = value; }
    
    
    private float forceValue;

    public void MainSliceCheckToBox() => mainSlice.isTrigger = false;
    public void CheckToParentBrick() => lefRightParentBrick.SetActive(true);
    
    public void CheckToBoxCol(bool isActive)
    {
        leftCollider.isTrigger = isActive;
        rightCollider.isTrigger = isActive;
    }
    public void ActiveRb()
    {
        
        leftBrickRb.isKinematic = false;
        rightBrickRb.isKinematic = false;
        
        leftBrickRb.useGravity = true;
        rightBrickRb.useGravity = true;
    }
    public void ForceRb()
    {

        rightBrickRb.AddRelativeForce(Vector3.back * 1.8f,ForceMode.Impulse);
        leftBrickRb.AddRelativeForce(Vector3.forward *1.8f, ForceMode.Impulse);
    }
}
