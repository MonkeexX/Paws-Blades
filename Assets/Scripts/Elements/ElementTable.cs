using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Element
{
    public int id;
    public string name;
    public List<int> strengths;
    public List<int> weaknesses;

    public Element(int id, string name)
    {
        this.id = id;
        this.name = name;
        this.strengths = new List<int>();
        this.weaknesses = new List<int>();
    }
}

[CreateAssetMenu(fileName = "ElementTable", menuName = "Scriptable Objects/ElementTable")]
public class ElementTable : ScriptableObject
{
    public TextAsset elementGraph;
    public List<Element> elements;

    public void OnValidate()
    {
        string[] graphParts = elementGraph.text.Split(' ');
        elements = new List<Element>();

        string nodes = graphParts[4];
        string edges = graphParts[5];

        Debug.Assert(nodes.StartsWith("nodes"), "Bad element graph format!");
        Debug.Assert(edges.StartsWith("edges"), "Bad element graph format!");

        string[] nodeParts = nodes.Split(':');

        string regex = @"([A-Z])+";

        foreach (System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(nodes, regex))
        {
            elements.Add(new Element(0, m.Groups[0].Value));
        }

        regex = @"(\d)+";

        var matches = System.Text.RegularExpressions.Regex.Matches(edges, regex);

        for (int i = 0; i + 1 < matches.Count; i += 2)
        {
            int part1 = int.Parse(matches[i].Groups[0].Value);
            int part2 = int.Parse(matches[i+1].Groups[0].Value);

            elements[part1].strengths.Add(part2);
        }
    }

}
