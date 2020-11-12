using System.Collections.Generic;
using UnityEngine;

namespace Task
{
    public class CharacterLoader : MonoBehaviour
    {
        [SerializeField] private CharacterButton baseButton;
        [SerializeField] private CharacterCustomizeUI characterCustomizeUI;
        
        [SerializeField] private CharacterHairLoader _characterHairLoader;
        [SerializeField] private CharacterHairButton _characterHairButton;
        private CharactersConfig config;

        private Character _currentCharacter;
        private List<CharacterHairButton> _hairButtons;
  
        private void Start()
        {
            _hairButtons=new List<CharacterHairButton>();
            config = Resources.Load<CharactersConfig>("CharactersConfig");
            var names = config.Characters;
            
            foreach (var objName in names)
            {
                var btn = Instantiate(baseButton, baseButton.transform.parent);
                btn.Setup(objName, OnCharacterButton);
            }
      
            baseButton.gameObject.SetActive(false);
        }
        private void OnCharacterButton(string id)
        {
            var asset = config.GetCharacter(id);
            var obj = Instantiate(asset, Vector3.zero, Quaternion.identity);
            if (_currentCharacter!=null)
            {
                Destroy(_currentCharacter.gameObject);
            }

            _currentCharacter = obj;
            characterCustomizeUI.SetCharacter(_currentCharacter);
            SetupHairButtons(_characterHairLoader.LoadHair(id));
        }


        public void SetupHairButtons(Texture2D[] textures)
        {

            foreach (var button in _hairButtons)
            {
                Destroy(button.gameObject);
            }
            _hairButtons.Clear();
            
            if (textures==null)
            {
                return;
            }
            
            foreach (var tex in textures)
            {
                var btn = Instantiate(_characterHairButton, _characterHairButton.transform.parent);
                btn.Setup(tex, OnHairButton);
                _hairButtons.Add(btn);
            }
      
            baseButton.gameObject.SetActive(false);
        }

        private void OnHairButton(Texture2D tex)
        {
            _currentCharacter.SetHairTexture(tex);
        }
    }
}