using System;

namespace DrDoc.Associations
{
    public class UndocumentedTypeAssociation : TypeAssociation
    {
        public UndocumentedTypeAssociation(string name, Type type)
            : base(name, null, type)
        {
            Type = type;
        }
    }
}