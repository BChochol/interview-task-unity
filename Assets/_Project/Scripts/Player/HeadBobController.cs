using AE;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class HeadBobController : MonoBehaviour
{
    [Header("HeadBob Settings")]
    [SerializeField] private Transform headTransform;
    [SerializeField] private float bobAmountY = 0.03f;
    [SerializeField] private float bobAmountX = 0.015f;
    [SerializeField] private float bobSpeed = 1.5f;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _returnDuration = 5f;

    private Vector3 startLocalPos;
    private Vector3 lastPosition;
    private bool isMoving = false;
    private Tween moveTween;

    private void Start()
    {
        startLocalPos = headTransform.localPosition;
    }

    private void Update()
    {
        if (_playerController.CheckIfMoving() && _playerController.CheckIfGrounded()) 
        {
            if (!isMoving)
            {
                isMoving = true;
                UpdateHeadBob().Forget(); 
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                ReturnHeadToStart().Forget(); 
            }
        }
    }

    private async UniTaskVoid UpdateHeadBob()
    {
        while (isMoving)  
        {
            float sinX = Mathf.Sin(Time.time * bobSpeed);
            float sinY = Mathf.Sin(Time.time * bobSpeed + Mathf.PI / 2);

            Vector3 targetPos = startLocalPos + new Vector3(
                sinX * bobAmountX,
                Mathf.Abs(sinY) * bobAmountY,
                0);

            if (moveTween != null && moveTween.IsActive()) 
                moveTween.Kill(); 

            moveTween = headTransform.DOLocalMove(targetPos, 0.1f).SetEase(Ease.InOutSine).Play();

            await UniTask.Delay(50);
        }
    }

    private async UniTaskVoid ReturnHeadToStart()
    {
        if (moveTween != null && moveTween.IsActive()) 
            moveTween.Kill(); 

        moveTween = headTransform.DOLocalMove(startLocalPos, _returnDuration).SetEase(Ease.InOutSine).Play();
        await moveTween.AsyncWaitForKill();  
    }
}
