using UnityEngine;

namespace AE
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    namespace AE
    {
        public class PuzzleManager : MonoBehaviour
        {
            [Header("Puzzle Settings")]
            [SerializeField] private string correctSequence = "13221";

            private string currentInput = "";

            private void Start()
            {
                EventManager.Instance.OnPuzzleElementInteracted += HandleSkullInput;
            }

            private void HandleSkullInput(int number)
            {
                Debug.Log("Typed " + number);
                currentInput += number.ToString();

                if (!correctSequence.StartsWith(currentInput))
                {
                    currentInput = ""; 
                    return;
                }

                if (currentInput == correctSequence)
                {
                    Debug.Log("Good");
                    EventManager.Instance?.PuzzleCompleted();
                    currentInput = ""; 
                }
            }
        }
    }

}
