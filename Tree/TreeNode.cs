using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    class TreeNode
    {
        public int value { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }
}
