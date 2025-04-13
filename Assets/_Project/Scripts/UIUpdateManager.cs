using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;


namespace AE
{
    public class UIUpdateManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text  tutorialText;
        [SerializeField] private TMP_Text monologueText;
        [SerializeField] private GameObject baseTarget;
        [SerializeField] private GameObject interactionTarget;

        private void Start()
        {
            EventManager.Instance.OnUITutorialUpdate += UpdateTutorialText;
            EventManager.Instance.OnUIMonologueUpdate += UpdateMonologueText;
            EventManager.Instance.OnUITargetSwitched += SwitchTargetIcon;
        }
        
        private void UpdateTutorialText(string tutorial)
        {
            tutorialText.text = tutorial;
        }
        
        private void UpdateMonologueText(string monologue, float duration)
        {
            ShowMonologueForDuration(monologue, duration).Forget();
        }
        
        private async UniTaskVoid ShowMonologueForDuration(string monologue, float duration)
        {
            monologueText.text = monologue;
            monologueText.gameObject.SetActive(true);

            await UniTask.Delay(System.TimeSpan.FromSeconds(duration), cancellationToken: this.GetCancellationTokenOnDestroy());

            monologueText.gameObject.SetActive(false);
        }
        
        private void SwitchTargetIcon(bool isSpecial)
        {
                baseTarget.SetActive(isSpecial);
                interactionTarget.SetActive(!isSpecial);
        }
        
        private void OnDestroy()
        {
            EventManager.Instance.OnUITutorialUpdate -= UpdateTutorialText;
            EventManager.Instance.OnUIMonologueUpdate -= UpdateMonologueText;
        }
    }
}
