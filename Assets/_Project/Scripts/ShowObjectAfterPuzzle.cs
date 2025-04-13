using UnityEngine;

namespace AE
{
    public class ShowObjectAfterPuzzle : MonoBehaviour
    {
        [SerializeField] private GameObject objectToShow;
        [SerializeField] private AudioClip appearSound;
        
        private void Start()
        {
            objectToShow.SetActive(false);
            EventManager.Instance.OnPuzzleCompleted += ShowObject;
        }

        private void ShowObject()
        {
            objectToShow.SetActive(true);
            AudioManager.Instance.PlaySFX(appearSound);
        }
    }
}
