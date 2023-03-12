using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OpenDartXBRL
{
    public abstract class ODXBRL
    {
        
        /// <summary>
        /// 읽어온 xml을 TreeView로 변환, 재귀함수 구조
        /// </summary>
        /// <param name="childNode">Xml의 하위노드</param>
        /// <param name="tn">추가할 TreeNode</param>
        /// <param name="i">Loop 순서</param>
        public void GetXbrlTreeNode(XmlNode childNode, TreeNode tn, int i)
        {
            #pragma warning disable 8604, 8600
            if (childNode.Value != null)
                tn.Nodes.Add(childNode.Value);
            else
                tn.Nodes.Add(GetNodeNameTag(childNode.Name));


            if (childNode.HasChildNodes == true)
            {
                for (int j = 0; j < childNode.ChildNodes.Count; j++)
                {
                    XmlNode childNode2 = childNode.ChildNodes[j];
                    TreeNode tn2 = tn.Nodes[i];
                    GetXbrlTreeNode(childNode2, tn2, j);
                }

            }

        }


        /// <summary>
        /// Node명 Tag형식으로 변경
        /// ex. Tag >> <Tag>
        /// </summary>
        /// <param name="name">Tag명</param>
        /// <returns>Tag 반환값</returns>
        public string GetNodeNameTag(string name)
        {
            return "<" + name + ">";
        }


        public abstract DataSet MakeDataSet();

    }
}
