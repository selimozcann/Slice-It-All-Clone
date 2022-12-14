using UnityEngine;
public class KnifeSliceController : Singleton<KnifeSliceController>
{
    public void OnCutObject(Collider other)
    {
        BrickSliceParent brickSliceParent = other.GetComponent<BrickSliceParent>();
        
        if (brickSliceParent != null)
        {
            brickSliceParent.SetLayer();
            brickSliceParent.CheckToBoxAndTag(false);
            brickSliceParent.ActiveRb();
            brickSliceParent.ForceRb();
            brickSliceParent.CheckToParentBrick();
        }
    }
}
