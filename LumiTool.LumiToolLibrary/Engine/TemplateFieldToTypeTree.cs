using AssetsTools.NET;
using System.Text;

namespace LumiTool.Engine
{
    public class TemplateFieldToTypeTree
    {
        private ClassDatabaseFile cldbFile;
        private uint stringTablePos;
        private Dictionary<string, uint> stringTableLookup;
        private Dictionary<string, uint> commonStringTableLookup;
        private List<TypeTreeNode> typeTreeNodes;

        public TypeTreeType ConvertInternal(ClassDatabaseFile cldbFile, AssetTypeTemplateField templateField, int typeId, ushort scriptIndex)
        {
            TypeTreeType typeTreeType = new TypeTreeType()
            {
                TypeId = typeId,
                ScriptTypeIndex = scriptIndex,
                IsStrippedType = false,
                ScriptIdHash = Hash128.NewBlankHash(),
                TypeHash = Hash128.NewBlankHash(),
                TypeDependencies = new int[0]
            };

            this.cldbFile = cldbFile;

            stringTablePos = 0;
            stringTableLookup = new Dictionary<string, uint>();
            commonStringTableLookup = new Dictionary<string, uint>();
            typeTreeNodes = new List<TypeTreeNode>();
            InitializeDefaultStringTableIndices();

            ConvertFields(templateField, 0);

            StringBuilder stringTableBuilder = new StringBuilder();
            List<KeyValuePair<string, uint>> sortedStringTable = stringTableLookup.OrderBy(n => n.Value).ToList();
            foreach (KeyValuePair<string, uint> entry in sortedStringTable)
            {
                stringTableBuilder.Append(entry.Key + '\0');
            }

            typeTreeType.StringBuffer = stringTableBuilder.ToString();
            typeTreeType.Nodes = typeTreeNodes;
            return typeTreeType;
        }

        private void InitializeDefaultStringTableIndices()
        {
            int commonStringTablePos = 0;
            List<ushort> commonStringIndices = cldbFile.CommonStringBufferIndices;
            foreach (ushort entry in commonStringIndices)
            {
                string strEntry = cldbFile.StringTable.GetString(entry);
                if (strEntry != string.Empty)
                {
                    commonStringTableLookup.Add(strEntry, (uint)commonStringTablePos);
                    commonStringTablePos += strEntry.Length + 1;
                }
            }
        }

        private void ConvertFields(AssetTypeTemplateField node, int depth)
        {
            string fieldName = node.Name;
            string typeName = node.Type;
            uint fieldNamePos;
            uint typeNamePos;

            if (stringTableLookup.ContainsKey(fieldName))
            {
                fieldNamePos = stringTableLookup[fieldName];
            }
            else if (commonStringTableLookup.ContainsKey(fieldName))
            {
                fieldNamePos = commonStringTableLookup[fieldName] + 0x80000000;
            }
            else
            {
                fieldNamePos = stringTablePos;
                stringTableLookup.Add(fieldName, stringTablePos);
                stringTablePos += (uint)fieldName.Length + 1;
            }

            if (stringTableLookup.ContainsKey(typeName))
            {
                typeNamePos = stringTableLookup[typeName];
            }
            else if (commonStringTableLookup.ContainsKey(typeName))
            {
                typeNamePos = commonStringTableLookup[typeName] + 0x80000000;
            }
            else
            {
                typeNamePos = stringTablePos;
                stringTableLookup.Add(typeName, stringTablePos);
                stringTablePos += (uint)typeName.Length + 1;
            }

            typeTreeNodes.Add(new TypeTreeNode()
            {
                Level = (byte)depth,
                MetaFlags = node.IsAligned ? 0x4000u : 0u,
                Index = (uint)typeTreeNodes.Count,
                TypeFlags = node.IsArray ? TypeTreeNodeFlags.Array : TypeTreeNodeFlags.None,
                NameStrOffset = fieldNamePos,
                ByteSize = GetSize(node.ValueType),
                TypeStrOffset = typeNamePos,
                Version = 1
            });

            foreach (AssetTypeTemplateField child in node.Children)
            {
                ConvertFields(child, depth + 1);
            }
        }

        private int GetSize(AssetValueType type)
        {
            switch (type)
            {
                case AssetValueType.Int8:
                case AssetValueType.UInt8:
                case AssetValueType.Bool:
                    return 1;
                case AssetValueType.Int16:
                case AssetValueType.UInt16:
                    return 2;
                case AssetValueType.Int32:
                case AssetValueType.UInt32:
                case AssetValueType.Float:
                    return 4;
                case AssetValueType.Int64:
                case AssetValueType.UInt64:
                case AssetValueType.Double:
                    return 8;
                default:
                    return -1;
            }
        }
    }
}
