using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    public class CharacterButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Text text;
        
        public void Setup(string id, Action<string> callback)
        {
            text.text = "load " + id;
      
            button.onClick.AddListener(delegate
            {
                callback?.Invoke(id);
            });
        }
    }
}