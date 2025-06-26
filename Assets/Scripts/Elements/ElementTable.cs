using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct Element
{
    public string Name;
    public List<string> strengths;
    public List<string> weaknesses;

    public Element(string name)
    {
        this.Name = name;
        this.strengths = new List<string>();
        this.weaknesses = new List<string>();
    }
}

[CreateAssetMenu(fileName = "ElementTable", menuName = "Scriptable Objects/ElementTable")]
public class ElementTable : ScriptableObject
{
    public TextArea Graph;
    private Dictionary<string, int> ids = new Dictionary<string, int>();
    public List<Element> elements = new List<Element>();

    public void OnValidate()
    {
        ids = new Dictionary<string, int>();
        elements = new List<Element>();

        if (Graph.longString.Length == 0) return;

        foreach(string line in Graph.longString.Split('\n'))
        {
            string[] words = line.Split(' ');
            if (words.Length == 1)
            {
                ids.Add(words[0], ids.Count);
                elements.Add(new Element(words[0]));
            }
            else if (words.Length == 2)
            { 
                elements[ids[words[0]]].strengths.Add(words[1]);
                elements[ids[words[1]]].weaknesses.Add(words[0]);
            }
        }
    }

}
