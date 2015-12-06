namespace RoslynReplaceNumericLiteral {
    using Roslyn.Compilers.CSharp;

    class MyLiteralRewriter : SyntaxRewriter {
        public override SyntaxNode VisitVariableDeclarator(VariableDeclaratorSyntax node) {
            return node.Update(node.Identifier, node.ArgumentList, (EqualsValueClauseSyntax) this.VisitEqualsValueClause(node.Initializer));
        }

        public override SyntaxNode VisitEqualsValueClause(EqualsValueClauseSyntax node) {
            SyntaxToken token = node.GetLastToken();
            if(token.Kind == SyntaxKind.NumericLiteralToken) {
                if(token.Value is int &&
                    (int) token.Value == 11) {
                    return node.ReplaceToken(token, Syntax.Literal(token.LeadingTrivia, "43", 43, token.TrailingTrivia));
                }
            }
            return node;
        }
    }
}
