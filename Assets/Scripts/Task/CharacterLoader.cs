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
  
        private void Start()
        {
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
            if (textures==null)
            {
                return;
            }
            
            foreach (var tex in textures)
            {
                var btn = Instantiate(_characterHairButton, _characterHairButton.transform.parent);
                btn.Setup(tex, OnHairButton);
            }
      
            baseButton.gameObject.SetActive(false);
        }

        private void OnHairButton(Texture2D tex)
        {
            _currentCharacter.SetHairTexture(tex);
        }
    }
}