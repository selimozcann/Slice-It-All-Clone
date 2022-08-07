using UnityEngine;
public class BrickSliceParent : MonoBehaviour
{
    [SerializeField] private Collider mainSlice;
    [SerializeField] private BoxCollider leftCollider, rightCollider;
    [SerializeField] private GameObject lefRightParentBrick;
    public Rigidbody rightBrickRb;
    public Rigidbody leftBrickRb;

    [SerializeField] private float forceAmount;
    [SerializeField] private bool isBrickForce;
    public virtual bool IsBrickForce { get => isBrickForce; set => isBrickForce = value; }
    
    
    private float forceValue;

    public void MainSliceCheckToBox() => mainSlice.isTrigger = false;
    public void CheckToParentBrick() => lefRightParentBrick.SetActive(true);

    private const string untagged = "Untagged";
    private const string brickSlice = "BrickSlice";
    
    public void CheckToBoxAndTag(bool isActive)
    {
        mainSlice.gameObject.SetActive(false);
        
        // leftCollider.tag = untagged;
        // rightCollider.tag = untagged;
        
        leftCollider.isTrigger = isActive;
        rightCollider.isTrigger = isActive;
    }
    public void SetLayer()
    {
        mainSlice.gameObject.layer = LayerMask.NameToLayer(brickSlice);
        leftCollider.gameObject.layer = LayerMask.NameToLayer(brickSlice);
        rightCollider.gameObject.layer = LayerMask.NameToLayer(brickSlice);
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
        // <summary>
        // Same value force because rotation y is 0 and 180.
        // </summary>
        rightBrickRb.AddRelativeForce(Vector3.forward * forceAmount,ForceMode.Impulse);
        leftBrickRb.AddRelativeForce(Vector3.forward *forceAmount, ForceMode.Impulse);
    }
}
