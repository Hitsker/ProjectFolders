using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    public class CharacterCustomizeUI : MonoBehaviour
    {
        [SerializeField] private Slider _headSlider;
        [SerializeField] private Slider _handsSlider;
        [SerializeField] private Slider _legsSlider;

        private Character _character;

        public void SetCharacter(Character character)
        {
            _character = character;
            Setup();
        }
        
        private void Setup()
        {
            _headSlider.onValueChanged.RemoveAllListeners();
            _handsSlider.onValueChanged.RemoveAllListeners();
            _legsSlider.onValueChanged.RemoveAllListeners();
            
            _headSlider.onValueChanged.AddListener(_character.ScaleHead);
            _handsSlider.onValueChanged.AddListener(_character.ScaleHands);
            _legsSlider.onValueChanged.AddListener(_character.ScaleLegs);
        }
    }
}