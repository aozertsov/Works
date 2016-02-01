using System;
using System.Linq;

namespace RoslynReplaceNumericLiteral {
    using Roslyn.Compilers;
    using Roslyn.Compilers.CSharp;  

    class SynraxChanger {
        static void Main(string[] args) {
            //TODO load from file
            string text = @"using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 11
            Console.WriteLine(a);
        }
    }
}";
            Console.WriteLine("Was");
            Console.WriteLine(text);
            SyntaxTree tree = SyntaxTree.ParseText(text);
            CompilationUnitSyntax root = tree.GetRoot();
            MyLiteralRewriter mlr = new MyLiteralRewriter();
            //TODO more elegant search;
            VariableDeclaratorSyntax childrens = GetDeclaratorSyntax(root);
            //var a = mlr.VisitVariableDeclarator(childrens, 23);
            root = root.ReplaceNode(childrens, mlr.VisitVariableDeclarator(childrens, 32));
            tree = SyntaxTree.Create(root);
            root = tree.GetRoot();
            text = root.GetText().ToString();
            //TODO update file
            Console.WriteLine("After using Roslyn");
            Console.WriteLine(text);
        }

        public static VariableDeclaratorSyntax GetDeclaratorSyntax(CompilationUnitSyntax root) {
            foreach (var v in root.Members) {
                if (v is NamespaceDeclarationSyntax) {
                    foreach (var w in v.ChildNodes()) {
                        if (w is ClassDeclarationSyntax) {
                            foreach (var e in w.ChildNodes()) {
                                if (e is MethodDeclarationSyntax) {
                                    foreach (var r in e.ChildNodes()) {
                                        if (r is BlockSyntax) {
                                            foreach (var t in r.ChildNodes()) {
                                                if (t is LocalDeclarationStatementSyntax) {
                                                    foreach (var y in t.ChildNodes()) {
                                                        if (y is VariableDeclarationSyntax)
                                                            foreach (var u in y.ChildNodes()) {
                                                                if (u is VariableDeclaratorSyntax)
                                                                    return ( u as VariableDeclaratorSyntax );
                                                            }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            throw new Exception();
        }
    }
}