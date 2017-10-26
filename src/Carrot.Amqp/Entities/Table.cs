using System;
using System.Collections.Generic;
using System.Linq;

namespace Carrot.Amqp.Entities
{
    internal class Table
    {
        internal readonly IDictionary<String, Object> Fields;

        internal Table(IDictionary<String, Object> fields)
        {
            Fields = fields;
        }

        internal T Field<T>(String key)
        {
            return Fields.ContainsKey(key) ? (T)Fields[key] : default(T);
        }

        internal Boolean IsEmpty => !Fields.Any();

        public override String ToString()
        {
            return $"{{{String.Join(",", Fields.Select(_ => $"\"{_.Key}\":{FormatValue(_.Value)}"))}}}";
        }

        private static String FormatValue(Object obj)
        {
            if (obj is String)
                return $"\"{obj.ToString()}\"";

            if (obj is Boolean)
                return $"{obj.ToString().ToLowerInvariant()}";

            return $"{obj.ToString()}";
        }
    }
}