using UnityEditor.AssetImporters;
using UnityEngine;

namespace Tools
{
    public class TSVContainer : ScriptableObject
    {
        public virtual void Import(string rawText, AssetImportContext ctx) { }
    }
}