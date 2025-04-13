using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AE
{
    public class InitialTextShow : MonoBehaviour
    {
        private void Start()
        {
            ShowText();
        }
        async Task ShowText()
        {
            await UniTask.Delay(100);
            EventManager.Instance.UIMonologueUpdate("I have to find the crystal.", 5f);
        }
    }
}
