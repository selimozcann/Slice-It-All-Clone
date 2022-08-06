using UnityEngine;

public class BrickTriggerController : MonoBehaviour
{
   [SerializeField] private Collider collider;
   private const string strKnife = "Knife";
   private const string bottomCollider = "BottomCollider";

   private delegate void onEnableTrigger(bool isActive);
   private event onEnableTrigger OnEnableTrigger;

   private void OnEnable()
   {
      OnEnableTrigger += ColliderActive;
   }
   private void OnDisable()
   {
      OnEnableTrigger -= ColliderActive;
   }
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer(strKnife)) 
      {
         OnEnableTrigger?.Invoke(true);
      }
      else if (other.gameObject.layer == LayerMask.NameToLayer(bottomCollider))
      {
         OnEnableTrigger?.Invoke(false);
      }
   }
   private void ColliderActive(bool isActive)
   {
      Debug.Log("ColliderActive");
      collider.isTrigger = true;
   }
}
