using DG.Tweening;
using UnityEngine;

public class KnifeMovement : Singleton<KnifeMovement>
{
    [Range(0, 10)] 
    [SerializeField] private float currentSpeed = 0;
    [SerializeField] private float currentTweenTime;
    [SerializeField] private float rotateTime;
    [SerializeField] private Vector3 targetRotation = new Vector3(0,0,145);

    
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
            rb.AddForce(new Vector3(currentSpeed * 8.5f,0,0) * Time.fixedDeltaTime,ForceMode.Impulse);
        }
    }
    public void OnGroundTrigger()
    {
        CheckToRb(true,false);
    }
    private void OnCalculateCurrentSpeed()
    {
        currentSpeed = speed;

        moveTween?.Kill();
        
        moveTween = DOTween.To(()  => currentSpeed, set=> currentSpeed = set, 0, currentTweenTime);

        rbTween.Kill();
        rbTween  = rb.DORotate(new Vector3(0,0,-15) + new Vector3(0,0,-15),rotateTime,RotateMode.FastBeyond360).
            OnComplete((() => rbTween.Kill()));
        // rbTween.Kill();
        // rbTween = rb.DORotate(new Vector3(0,0,-45) + new Vector3(0,0,-75), rotateTime,RotateMode.FastBeyond360);
        
        rb.velocity = Vector3.up * 8;
        CheckToRb(false,true);
    }

    private void CheckToRb(bool canKinematic, bool canGravity)
    {
        rb.isKinematic = canKinematic;
        rb.useGravity = canGravity;
    } 
}
