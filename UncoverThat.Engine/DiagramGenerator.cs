using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncoverThat.Engine
{
    public class DiagramGenerator
    {
        public static string GenerateSequenceDiagram(string path)
        {
            var code = File.ReadAllText(path);

            var tree = CSharpSyntaxTree.ParseText(code);
            var walker = new MethodDeclarationWalker();
            walker.Visit(tree.GetRoot());

            var graph = new MethodGraph { Parent = new Node { Name = "Main" } };
            graph.BuildGraph(graph.Parent, walker.MethodCalls);

            return graph.ToMermaidSequantialDiagram();
        }
    }
}
