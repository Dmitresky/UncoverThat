using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace UncoverThat.Engine
{
    public class MethodDeclarationWalker : CSharpSyntaxWalker
    {
        public Dictionary<string, List<string>> MethodCalls = new Dictionary<string, List<string>>();
        private string currentMethod = "";

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            currentMethod = node.Identifier.ValueText;
            base.VisitMethodDeclaration(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var callee = node.Expression.ToString().Split('.').Last();
            if (!string.IsNullOrWhiteSpace(currentMethod))
            {
                if (!MethodCalls.ContainsKey(currentMethod))
                {
                    MethodCalls[currentMethod] = new List<string>();
                }
                MethodCalls[currentMethod].Add(callee);
            }
            base.VisitInvocationExpression(node);
        }
    }
}
