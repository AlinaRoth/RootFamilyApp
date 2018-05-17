using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Models
{
    public class TreeNode
    {
        public Guid Id { get; set; }

        public TreeNode(String rawLine)
        {
            RawLine = rawLine;
            Children = new List<TreeNode>();
        }

        public String RawLine { get; set; }
        public List<TreeNode> Children { get; set; }

        internal string Tag
        {
            get
            {
                var end = RawLine.IndexOf(" ", 2);
                if (end < 0)
                    return RawLine.Substring(2); // No value after
                return RawLine.Substring(2, end - 2);
            }
        }

        internal bool HasValue
        {
            get
            {
                return RawLine.Length > (Tag.Length + 2);
            }
        }

        internal string GetTextValue()
        {
            return RawLine.Substring(3 + Tag.Length).Trim();
        }

        internal int? GetInt32Value()
        {
            if (int.TryParse(GetTextValue(), out var value))
                return value;
            else
                return null;
        }
    }
}