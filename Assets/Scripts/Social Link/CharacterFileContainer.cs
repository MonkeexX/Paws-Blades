using SocialLink;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterFileContainer : ScriptableObject
{
    public List<CharacterFile> CharacterFiles;

    public CharacterFileContainer()
    {
        CharacterFiles = new List<CharacterFile>();
    }
}
