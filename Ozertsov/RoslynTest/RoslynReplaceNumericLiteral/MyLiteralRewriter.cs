namespace RoslynReplaceNumericLiteral {
    using Roslyn.Compilers.CSharp;

    class MyLiteralRewriter : SyntaxRewriter {
        public SyntaxNode VisitVariableDeclarator(VariableDeclaratorSyntax node, int newint) {
            return node.Update(node.Identifier, node.ArgumentList, (EqualsValueClauseSyntax) this.VisitEqualsValueClause(node.Initializer, newint));
        }

        public SyntaxNode VisitEqualsValueClause(EqualsValueClauseSyntax node, int newint) {
            SyntaxToken token = node.GetLastToken();
            if(token.Kind == SyntaxKind.NumericLiteralToken) {
                if(token.Value is int &&
                    (int) token.Value == 11) {
                    return node.ReplaceToken(token, Syntax.Literal(token.LeadingTrivia, newint.ToString(), newint, token.TrailingTrivia));
                }
            }
            return node;
        }
    }
}
