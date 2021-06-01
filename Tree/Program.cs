using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //прямой обход
            static void Pre_Order(TreeNode tree)
            {
                if (tree != null)
                {
                    Console.WriteLine(tree.value);
                    Pre_Order(tree.left);
                    Pre_Order(tree.right);
                }
            }
            //обратный обход
            static void In_Order(TreeNode tree)
            {
                if (tree != null)
                {
                    In_Order(tree.left);
                    Console.WriteLine(tree.value);
                    In_Order(tree.right);
                }
            }
            //концевой обзод
            static void Post_Order(TreeNode tree)
            {
                if (tree != null)
                {
                    Post_Order(tree.left);
                    Post_Order(tree.right);
                    Console.WriteLine(tree.value);
                }
            }

            TreeNode tree = new TreeNode(1);
            tree.left = new TreeNode(2);
            tree.right = new TreeNode(3);
            tree.left.left = new TreeNode(4);
            tree.left.right = new TreeNode(5);
            tree.right.right = new TreeNode(6);
            Console.WriteLine("Порядок прямого обхода:");
            Pre_Order(tree);
            Console.WriteLine("Порядок обратного обхода:");
            In_Order(tree);
            Console.WriteLine("Порядок концевого обхода:");
            Post_Order(tree);
            Console.WriteLine();


            ExpressionNode expressionTree = new ExpressionNode("/");
            expressionTree.left = new ExpressionNode("*");
            expressionTree.right = new ExpressionNode("3");
            expressionTree.left.left = new ExpressionNode("+");
            expressionTree.left.right = new ExpressionNode("-");
            expressionTree.left.left.left = new ExpressionNode("2");
            expressionTree.left.left.right = new ExpressionNode("3");
            expressionTree.left.right.left = new ExpressionNode("7");
            expressionTree.left.right.right = new ExpressionNode("4");
            Console.WriteLine(expressionTree.CalcTree(expressionTree));
        }
    }
}
