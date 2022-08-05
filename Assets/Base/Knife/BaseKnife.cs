using UnityEngine;
public class BaseKnife : Singleton<BaseKnife>
{
    private float forceValue;
    public void OnCutObject(Collider other)
    {
        BrickSliceParent brickSliceParent = other.GetComponent<BrickSliceParent>();
        
        if (brickSliceParent != null)
        {
            
            brickSliceParent.CheckToBoxCol(false);
            brickSliceParent.ActiveRb();
            brickSliceParent.ForceRb();
            brickSliceParent.CheckToParentBrick();
            // brickSliceParent.MainSliceCheckToBox();
            
            brickSliceParent.IsBrickForce = true;

        }
    }
}
