using UnityEngine;
using DG.Tweening;

namespace AE
{
    public class CandleInHandAnimation : MonoBehaviour
    {
        private Vector3 initialLocalPosition;
        public float moveDistance = 0.5f;
        public float moveDuration = 0.5f;

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
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 targetWorldPos = transform.position + forward * moveDistance;

            transform.DOMove(targetWorldPos, moveDuration)
                .OnComplete(() =>
                {
                    Debug.Log("Świeczka animowana po interakcji z pochodnią.");
                    transform.DOLocalMove(initialLocalPosition, moveDuration);
                });
        }
    }
}