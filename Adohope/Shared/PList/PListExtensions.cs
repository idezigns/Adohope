using PListNet.Nodes;

namespace Adohope.Shared.PList
{
    public static class PListFileExtensions
    {
        public static StringNode GetStringNode(this DynamicPList pListFile, string key)
        {
            return pListFile.RootNode[key] as StringNode;
        }

        public static NullNode GetNullNode(this DynamicPList pListFile, string key)
        {
            return pListFile.RootNode[key] as NullNode;
        }

        public static ArrayNode GetArrayNode(this DynamicPList pListFile, string key)
        {
            return pListFile.RootNode[key] as ArrayNode;
        }

        public static BooleanNode GetBooleanNode(this DynamicPList pListFile, string key)
        {
            return pListFile.RootNode[key] as BooleanNode;
        }

        public static DataNode GetDataNode(this DynamicPList pListFile, string key)
        {
            return pListFile.RootNode[key] as DataNode;
        }

        public static DateNode GetDateNode(this DynamicPList pListFile, string key)
        {
            return pListFile.RootNode[key] as DateNode;
        }

        public static DictionaryNode GetDictionaryNode(this DynamicPList pListFile, string key)
        {
            return pListFile.RootNode[key] as DictionaryNode;
        }

        public static IntegerNode GetIntegerNode(this DynamicPList pListFile, string key)
        {
            return pListFile.RootNode[key] as IntegerNode;
        }
    }
}
