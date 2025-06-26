using System;
using System.Collections.Generic;
using UnityEngine;

namespace SocialLink
{
    [Serializable]
    public class CharacterFileContainer : ScriptableObject
    {
        public List<CharacterFile> CharacterFiles;

        public CharacterFileContainer()
        {
            CharacterFiles = new List<CharacterFile>();
        }
    }
}
