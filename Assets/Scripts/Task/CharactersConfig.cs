using System.Linq;
using UnityEngine;

namespace Task
{
    [CreateAssetMenu]
    public class CharactersConfig : ScriptableObject
    {
        [SerializeField] private string[] characters;

        public string[] Characters => characters;
    
    
        public Character GetCharacter(string characterName)
        {
            var objName = characters.FirstOrDefault(ch => ch == characterName);
            return string.IsNullOrEmpty(objName) ? null : LoadObject(objName);
        }
    
        private static Character LoadObject(string chName)
        {
            return Resources.Load<Character>("Characters/" + chName);
        }

#if UNITY_EDITOR
        private void Reset()
        {
            var objects = Resources.LoadAll<GameObject>("Characters");
        
            characters=new string[objects.Length];

            for (var i = 0; i < characters.Length; i++)
            {
                characters[i] = objects[i].name;
            }
        }
#endif
    }
}
