using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AE
{
    public class CrystalInteractable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            EventManager.Instance.UIMonologueUpdate("That's it! I have found the crystal!", 5f);
        }

    }
}
