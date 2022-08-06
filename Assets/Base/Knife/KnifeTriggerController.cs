using System;
using UnityEngine;

public class KnifeTriggerController : MonoBehaviour
{
    private const string groundStr = "Ground";
    private const string cutStr = "Cut";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(groundStr))
        {
            KnifeMovement.I.OnGroundTrigger();
            UIManager.I.OnFailGame();
        }
        else if (other.CompareTag(cutStr))
        {
            KnifeSliceController.I.OnCutObject(other);
            // KnifeColliderController.I.IsSlice = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // KnifeColliderController.I.IsSlice = true;
    }
}
