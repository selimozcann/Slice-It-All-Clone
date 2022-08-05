using UnityEngine;
public class GroundController : MonoBehaviour
{
    public const string cutStr = "Cut";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(cutStr))
        {
            
        }
    }
}
