using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    public class CharacterHairButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        
        public void Setup(Texture2D tex, Action<Texture2D> callback)
        {
            var rect = new Rect(0, 0, tex.height, tex.width);
            var pivot = Vector2.one * 0.5f;

            var sprite = Sprite.Create(tex, rect, pivot);
            image.sprite = sprite;
      
            button.onClick.AddListener(delegate
            {
                callback?.Invoke(tex);
            });
        }
    }
}