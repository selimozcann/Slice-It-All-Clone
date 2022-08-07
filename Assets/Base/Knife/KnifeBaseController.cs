using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KnifeBaseController : Singleton<KnifeBaseController>
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

    private string levelEndLog;
    private void Update()
    {
        var isTouch = Input.GetMouseButtonDown(0);
        if (isTouch)
        {
            OnCalculateCurrentSpeed();
        }
    }
    public void OnFinishTrigger(Collider other)
    {
        InactiveToRb(true,false,CollisionDetectionMode.Discrete);
        
        var otherText = other.GetComponentInChildren<TextMeshPro>().text;
        levelEndLog  = otherText != null ? "Your score is " + otherText : "Your score is zero";
        Debug.Log(levelEndLog);
        EnabledToKnifeMovement();
    }
    private void FixedUpdate()
    {
        if (currentSpeed > 0)
        {
            rb.AddForce(new Vector3(currentSpeed * 6f,0.35f,0) * Time.fixedDeltaTime,ForceMode.Impulse);
        }
    }
    public void OnGroundTrigger()
    {
        InactiveToRb(true,false,CollisionDetectionMode.Discrete);
        EnabledToKnifeMovement();
    }
    public void EnabledToKnifeMovement() => enabled = false;
    private void OnCalculateCurrentSpeed()
    {
        InactiveToRb(false,true,CollisionDetectionMode.Continuous);
        rb.velocity =  new Vector3(0.5f,6.5f,0f);

        currentSpeed = speed;
        moveTween?.Kill();
        moveTween = DOTween.To(()  => currentSpeed, set=> currentSpeed = set, 0, currentTweenTime);
        
        rbTween.Kill();
        rbTween  = rb.DORotate(new Vector3(0,0,-15f) + targetRotation,rotateTime,RotateMode.FastBeyond360).
            OnComplete((() => rbTween.Kill()));
        
    }
    private void InactiveToRb(bool canKinematic, bool canGravity,CollisionDetectionMode collisionDetectionMode)
    {
        // rb.velocity = Vector3.zero;
        rb.isKinematic = canKinematic;
        rb.useGravity = canGravity;
        rb.collisionDetectionMode = collisionDetectionMode;
        
    } 
}
