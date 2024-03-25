using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncoverThat.Engine
{
    public class MethodGraph
    {
        public Node Parent { get; set; }

        public void BuildGraph(Node currentNode, Dictionary<string, List<string>> methodCalls)
        {
            if (methodCalls.ContainsKey(currentNode.Name))
            {
                foreach (var callee in methodCalls[currentNode.Name])
                {
                    var newNode = new Node { Name = callee };
                    currentNode.Nodes.Add(newNode);
                    BuildGraph(newNode, methodCalls);
                }
            }
        }

        public string ToMermaidSequantialDiagram()
        {
            var diagram = new List<string> { "sequenceDiagram" };

            foreach (var n in this.Parent.Nodes)
            {
                ToMermaidSequantialDiagram(n, diagram, this.Parent);
            }

            return string.Join("\r\n", diagram);
        }

        private static void ToMermaidSequantialDiagram(Node currentNode, List<string> diagram, Node previousNode)
        {
            if (previousNode != null)
            {
                diagram.Add($"    {previousNode.Name}->>+{currentNode.Name}: call()");
            }

            foreach (var n in currentNode.Nodes)
            {
                ToMermaidSequantialDiagram(n, diagram, currentNode);
            }

            if (previousNode != null)
            {
                diagram.Add($"    {currentNode.Name}-->>-{previousNode.Name}: return");
            }
        }
    }

    public class Node
    {
        public string Name { set; get; }

        public List<Node> Nodes { get; set; } = new List<Node>();
    }
}
