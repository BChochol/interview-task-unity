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
    }
}
