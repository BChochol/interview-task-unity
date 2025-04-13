using UnityEngine;
using DG.Tweening;

namespace AE
{
    public class CandleInHandAnimation : MonoBehaviour
    {
        [Header("Candle Animation Settings")]
        private Vector3 initialLocalPosition;
        [SerializeField] private float moveDistance = 0.5f;
        [SerializeField] private float moveDuration = 0.5f;
        [SerializeField] private float rotationAngle = -50f;
        [SerializeField] private GameObject flamePrefab;

        private void Start()
        {
            initialLocalPosition = transform.localPosition;
            EventManager.Instance.OnTorchInteracted += AnimateCandle;
        }

        private void OnDestroy()
        {
            if (EventManager.Instance != null)
                EventManager.Instance.OnTorchInteracted -= AnimateCandle;
        }

        public void AnimateCandle()
        {
            EventManager.Instance.OnTorchInteracted -= AnimateCandle;
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 1;
            forward.Normalize();

            Vector3 targetWorldPos = transform.position + forward * moveDistance;
            Quaternion initialRotation = transform.rotation;
            Quaternion tiltRotation = Quaternion.Euler(rotationAngle, transform.eulerAngles.y, 0f);

            Sequence candleSequence = DOTween.Sequence();

            candleSequence.Append(transform.DOMove(targetWorldPos, moveDuration));
            candleSequence.Join(transform.DORotate(tiltRotation.eulerAngles, moveDuration));

            candleSequence.AppendInterval(0.5f);
            flamePrefab.SetActive(true);
            candleSequence.AppendInterval(0.5f);
            
            candleSequence.Append(transform.DOLocalMove(initialLocalPosition, moveDuration));
            candleSequence.Join(transform.DORotate(initialRotation.eulerAngles, moveDuration));
        }
    }
}