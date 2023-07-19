namespace MyTube.Models;

public struct Node
{
    public string Name { get; set; }
    public string Path { get; set; }
    public NodeType Type { get; set; }
}

public enum NodeType
{
    Directory,
    File
}