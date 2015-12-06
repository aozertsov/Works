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
            VariableDeclaratorSyntax childrens = (VariableDeclaratorSyntax) root.Members[0].ChildNodes().ElementAt(1).ChildNodes().ElementAt(0).ChildNodes().ElementAt(2).ChildNodes().ElementAt(0).ChildNodes().ElementAt(0).ChildNodes().ElementAt(1);
            var a = mlr.VisitVariableDeclarator(childrens);
            root = root.ReplaceNode(childrens, mlr.VisitVariableDeclarator(childrens));
            tree = SyntaxTree.Create(root);
            root = tree.GetRoot();
            text = root.GetText().ToString();
            //TODO update file
            Console.WriteLine("After using Roslyn");
            Console.WriteLine(text);
        }
    }
}