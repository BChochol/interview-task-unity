using AE;
using UnityEngine;

namespace AE
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance { get; private set; }

        public PlayerInventory Inventory { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void RegisterInventory(PlayerInventory inventory)
        {
            Inventory = inventory;
        }
    }
}