using UnityEngine;
using DG.Tweening;

namespace AE
{
    public class ChestInteractable : MonoBehaviour, IInteractable
    {
        [Header("Interactable Settings")]
        [SerializeField] private ItemData interactingItem;
        [SerializeField] private string showedText;
        [SerializeField] private float duration = 3.0f;
        [SerializeField] private AudioClip swordSound;
        [SerializeField] private AudioClip lockedChestSound;
        
        
        [Header("Animation Settings")]
        [SerializeField] private GameObject swordPrefab;
        [SerializeField] private GameObject lidPrefab;
        [SerializeField] private float swordDepthOffset;

        public void Interact()
        {
            ItemData heldItem = EventManager.Instance.HeldItemCheck();
            if (heldItem == interactingItem)
            {
                EventManager.Instance?.ItemRemoved(interactingItem);
                AudioManager.Instance.PlaySFX(swordSound);
                Animate();
            }
            else
            {
                AudioManager.Instance.PlaySFX(lockedChestSound);
                EventManager.Instance.UIMonologueUpdate(showedText, 3f);
            }
        }

        private void Animate()
        {
            swordPrefab.SetActive(true);

            Vector3 targetPosition = new Vector3(
                swordPrefab.transform.position.x,
                swordPrefab.transform.position.y,
                lidPrefab.transform.position.z + swordDepthOffset
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
            gameObject.layer = LayerMask.NameToLayer("Ground");
        }
    }
}