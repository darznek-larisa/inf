using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tree
{
    class ExpressionNode
    {
        public string value { get; set; }
        public ExpressionNode  left { get; set; }
        public ExpressionNode right { get; set; }
        public string exp { get; set; }
        public ExpressionNode(string c)
        {
            if ((c.Length == 1 && isOperator(c[0])) || double.TryParse(c, out double number))
            {
                exp = null;
                this.value = c;
                left = null;
                right = null;
            }
            else
            {
                Console.WriteLine("В дерево поступило не числовое значение и не оператор!");
                System.Environment.Exit(0);
            }

            }
        bool isOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
            {
                return true;
            }
            return false;
        }
        public double CalcTree (ExpressionNode tree)
        {
            double num1, num2;
            if (tree.left == null)
            {
                return Convert.ToDouble(new DataTable().Compute(tree.value, ""));
            }
            num1 = CalcTree(tree.left);
            num2 = CalcTree(tree.right);
            switch (tree.value)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
            }
            return 34567;
        }
    }
}
