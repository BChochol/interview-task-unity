using UnityEngine;

namespace AE
{
    public class PuzzleChest : MonoBehaviour
    {
        [SerializeField] private GameObject chestObject;
        
        private void Start()
        {
            chestObject.SetActive(false);
            EventManager.Instance.OnPuzzleCompleted += ShowChest;
        }

        private void ShowChest()
        {
            chestObject.SetActive(true);
        }
    }
}
