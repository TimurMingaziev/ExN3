using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExN3
{
   public static class ClassSerialiaze
    {
        public static void SaveTree(TreeView tree, string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Create);
            
                BinaryFormatter  bf = new BinaryFormatter();
                bf.Serialize(file, tree.Nodes.Cast<TreeNode>().ToList());
            
        }

        public static void LoadTree(TreeView tree, string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(file);

            TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
            tree.Nodes.AddRange(nodeList);
        }
    }
}
