using UnityEngine;
using DG.Tweening;

namespace AE
{
    public class ChestInteractable : MonoBehaviour, IInteractable
    {
        [Header("Interactable Settings")]
        [SerializeField] private ItemData interactingItem;
        
        
        [Header("Animation Settings")]
        [SerializeField] private GameObject swordPrefab;
        [SerializeField] private GameObject lidPrefab;

        public void Interact()
        {
            EventManager.Instance?.ItemRemoved(interactingItem);
            Animate();
        }

        private void Animate()
        {
            swordPrefab.SetActive(true);

            Vector3 targetPosition = new Vector3(
                swordPrefab.transform.position.x,
                swordPrefab.transform.position.y,
                lidPrefab.transform.position.z
            );
            
            Sequence chestSequence = DOTween.Sequence();

            chestSequence.Append(
                swordPrefab.transform.DOMove(targetPosition, 1f)
                    .SetEase(Ease.InOutQuad)
            );

            chestSequence.Append(
                lidPrefab.transform.DORotate(new Vector3(-80f, 0f, 0f), 1f, RotateMode.WorldAxisAdd)
                    .SetEase(Ease.OutBack)
            );
        }
    }
}