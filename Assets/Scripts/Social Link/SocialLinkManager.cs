using System.Collections.Generic;
using UnityEngine;

namespace SocialLink
{
    public class SocialLinkManager : MonoBehaviour
    {
        public CharacterFileContainer characterFileContainer;
        public Dictionary<string, CharacterFile> files = new Dictionary<string, CharacterFile>();

        private void Start()
        {
            foreach (CharacterFile file in characterFileContainer.CharacterFiles)
            {
                files.Add(file.Name, new CharacterFile(file));
            }
        }

        private void Update()
        {

        }

        public void AddXP(string name, int amount)
        {
            Debug.Assert(files.ContainsKey(name), "Character doesn't exist!");
            files[name].ModifyXP(amount);
        }

        public void RemoveXP(string name, int amount)
        {
            Debug.Assert(files.ContainsKey(name), "Character doesn't exist!");
            files[name].ModifyXP(-amount);
        }
    }
}