using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    class PostfixExpressions
    {
        private string op = "+-*/";
        private string data;
        private ConnectedListStack stack;
        private int f = 1;
        private double res;
        public PostfixExpressions(string text)
        {
            this.data = text;
            this.stack = new ConnectedListStack();
        }
        public string GetStartExp()
        {
            return data;
        }
        private bool IsOperator(char inch)
        {
            return inch == '*' || inch == '/' ||
                inch == '+' || inch == '-';
        }
        private int Priority(char inch)
        {
            if (inch == '*' || inch == '/') return 2;
            if (inch == '+' || inch == '-') return 1;
            return 0;
        }
        public string ReversePostfix()
        {
            string postfix = null;
            ConnectedListStack mstack = new ConnectedListStack();
            foreach (char cur in data)
            {
                if (Char.IsDigit(cur))
                    postfix += cur;
                if (IsOperator(cur))
                {
                    if (mstack.count == 0 || mstack.getTop() == "(")
                    { mstack.push(Convert.ToString(cur)); }
                    else if (Priority(Char.Parse(mstack.getTop())) < Priority(cur))
                    { mstack.push(Convert.ToString(cur)); }
                    else if (Priority(Char.Parse(mstack.getTop())) >= Priority(cur))
                    {
                        while (mstack.count != 0 && mstack.getTop() != "("
                            && !(Priority(Char.Parse(mstack.getTop())) < Priority(cur)))
                        {
                            postfix += mstack.getTop();
                            mstack.pop();
                        }
                        mstack.push(Convert.ToString(cur));
                    }
                }
                if (Convert.ToString(cur) == "(")
                    mstack.push(Convert.ToString(cur));
                if (Convert.ToString(cur) == ")")
                {
                    while (mstack.count != 0 && mstack.getTop() != "(")
                    {
                        postfix += mstack.getTop();
                        mstack.pop();
                    }
                    if (mstack.getTop() == "(")
                        mstack.pop();
                }
            }
            while (mstack.count != 0)
            {
                postfix += mstack.getTop();
                mstack.pop();
            }
            data = postfix;
            return postfix;
        }
        public void Calc()
        {
            foreach (char x in data)
            {
                if (op.Contains(x))
                {
                    if (stack.count < 2)
                    {
                        Console.WriteLine("Ошибка");
                        f = 0;
                        break;
                    }
                    int op2 = Int32.Parse(stack.getTop());
                    stack.pop();
                    int op1 = Int32.Parse(stack.getTop());
                    stack.pop();
                    if (x == Char.Parse("+"))
                        res = op1 + op2;
                    else if (x == Char.Parse("-"))
                        res = op1 - op2;
                    else if (x == Char.Parse("*"))
                        res = op1 * op2;
                    else
                        res = op1 / op2;
                    stack.push(Convert.ToString(res));
                }
                else
                    stack.push(Convert.ToString(x));
            }
            if (stack.count == 1)
                Console.WriteLine("Ответ: " + stack.getTop());
            else if (f == 1)
                Console.WriteLine("Ошибка");
        }
    }
}