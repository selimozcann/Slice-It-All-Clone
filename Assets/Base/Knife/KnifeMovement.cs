using DG.Tweening;
using UnityEngine;

public class KnifeMovement : Singleton<KnifeMovement>
{
    [Range(0, 10)] 
    [SerializeField] private float currentSpeed = 0;
    [SerializeField] private float currentTweenTime;
    [SerializeField] private float rotateTime;
    [SerializeField] private Vector3 targetRotation = new Vector3(0,0,145);
    
    
    [SerializeField] private Tween moveTween;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 1;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnCalculateCurrentSpeed();
        }
    }
    private void FixedUpdate()
    {
        if (currentSpeed > 0)
        {
            Debug.Log("Force");
            rb.AddForce(new Vector3(currentSpeed * 6.2f,0,0) * Time.fixedDeltaTime,ForceMode.Impulse);
        }
    }
    public void OnGroundTrigger()
    {
        CheckToRb(true);
    }
    private void OnCalculateCurrentSpeed()
    {
        currentSpeed = speed;

        moveTween?.Kill();
        
        moveTween = DOTween.To(()  => currentSpeed, set=> currentSpeed = set, 0, currentTweenTime);

        transform.DOKill();
        transform.DOLocalRotate(new Vector3(0,0,-45) + new Vector3(0,0,-75), rotateTime,RotateMode.FastBeyond360);
        

        rb.velocity = Vector3.up * 7.2f;
        CheckToRb(false);
    }
    private void CheckToRb(bool canKinematic) => rb.isKinematic = canKinematic;
    private void OnChangeRotation()
    {
        transform.DORotate(new Vector3(0,0,135f),currentSpeed);
    }
}
