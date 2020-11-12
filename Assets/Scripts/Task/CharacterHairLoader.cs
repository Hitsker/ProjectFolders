using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Task
{
    public class CharacterHairLoader : MonoBehaviour
    {
        [SerializeField] private CharacterLoader _characterLoader;
        private List<Texture2D> _textures;
        
        
        public Texture2D[] LoadHair(string charId)
        {
            _textures=new List<Texture2D>();
            
            var path = Path.Combine(Application.streamingAssetsPath, "Character");
            path = Path.Combine(path, charId);
            path = Path.Combine(path, "hair");

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                return null;
            }
            
            var directoryInfo = new DirectoryInfo(path);

            var allFiles = directoryInfo.GetFiles("*.*");
            
            foreach (var file in allFiles)
            {
                Debug.Log("File name" + file.Name);

                if (file.Name.Contains("meta"))
                {
                    continue;
                }

                //var imageData = Instantiate(baseIcon, baseIcon.transform.parent);
                var bytes = File.ReadAllBytes(file.FullName);
                var texture2D = new Texture2D(1, 1);

                texture2D.LoadImage(bytes);
                _textures.Add(texture2D);
                

                //var rect = new Rect(0, 0, texture2D.width, texture2D.height);
                //var pivot = Vector2.one * 0.5f;

                //var sprite = Sprite.Create(texture2D, rect, pivot);
                //imageData.Image.sprite = sprite;
                //imageData.Text.text = file.Name;
            }

            return _textures.ToArray();
        }
    }
}