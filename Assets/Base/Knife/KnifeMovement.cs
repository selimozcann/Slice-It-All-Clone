using DG.Tweening;
using UnityEngine;

public class KnifeMovement : Singleton<KnifeMovement>
{
    [Range(0, 2)] 
    
    
    [SerializeField] private float currentSpeed = 0;
    
    [SerializeField] private float currentTweenTime;
    [SerializeField] private float rotateTime;
    [SerializeField] private Vector3 targetRotation = new Vector3(0,0,-50);
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 1;
    
    private Tween rbTween;
    private Tween moveTween;

    private void Update()
    {
        var isTouch = Input.GetMouseButtonDown(0);
        if (isTouch)
        {
            OnCalculateCurrentSpeed();
        }
    }
    private void FixedUpdate()
    {
        if (currentSpeed > 0)
        {
            rb.AddForce(new Vector3(currentSpeed * 6f,currentSpeed,0) * Time.fixedDeltaTime,ForceMode.Impulse);
        }
    }
    public void OnGroundTrigger()
    {
        InactiveToRb(true,false,CollisionDetectionMode.Discrete);
    }
    private void OnCalculateCurrentSpeed()
    {
        InactiveToRb(false,true,CollisionDetectionMode.Continuous);
        rb.velocity =  new Vector3(0.5f,8f,0f);

        currentSpeed = speed;
        moveTween?.Kill();
        moveTween = DOTween.To(()  => currentSpeed, set=> currentSpeed = set, 0, currentTweenTime);
        
        rbTween.Kill();
        rbTween  = rb.DORotate(new Vector3(0,0,-15f) + targetRotation,rotateTime,RotateMode.FastBeyond360).
            OnComplete((() => rbTween.Kill()));
        
    }
    public void InactiveToRb(bool canKinematic, bool canGravity,CollisionDetectionMode collisionDetectionMode)
    {
        // rb.velocity = Vector3.zero;
        rb.collisionDetectionMode = collisionDetectionMode;
        rb.isKinematic = canKinematic;
        rb.useGravity = canGravity;
    } 
}
