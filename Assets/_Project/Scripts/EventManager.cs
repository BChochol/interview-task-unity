using UnityEngine;
using System;

namespace AE
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public event Action OnTorchInteracted;
        public void TorchInteracted()
        {
            OnTorchInteracted?.Invoke();
        }
        
        public event Action<ItemData> OnItemCollected;
        public void ItemCollected(ItemData item)
        {
            OnItemCollected?.Invoke(item);
        }

        public event Action<ItemData> OnItemRemoved;
        public void ItemRemoved(ItemData item)
        {
            OnItemRemoved?.Invoke(item);
        }

        public event Action<bool> OnLitCandleHeld;
        public void LitCandleHeld(bool isLit)
        {
            OnLitCandleHeld?.Invoke(isLit);
        }
        
        public event Action<int> OnPuzzleElementInteracted;
        public void SkullInteracted(int number)
        {
            OnPuzzleElementInteracted?.Invoke(number);
        }

        public event Action OnPuzzleCompleted;
        public void PuzzleCompleted()
        {
            OnPuzzleCompleted?.Invoke();
        }

        public event Action<string> OnUITutorialUpdate;
        public void UITutorialUpdate(string tutorialText)
        {
            OnUITutorialUpdate?.Invoke(tutorialText);
        }

        public event Action<string, float> OnUIMonologueUpdate;
        public void UIMonologueUpdate(string monologueText, float duration)
        {
            OnUIMonologueUpdate?.Invoke(monologueText, duration);
        }

        public event Action<bool> OnUITargetSwitched;
        public void UITargetSwitched(bool isSpecial)
        {
            OnUITargetSwitched?.Invoke(isSpecial);
        }

        public event Func<ItemType> OnHeldItemCheck;

        public ItemType HeldItemCheck()
        {
            return OnHeldItemCheck.Invoke();
        }
    }
}
