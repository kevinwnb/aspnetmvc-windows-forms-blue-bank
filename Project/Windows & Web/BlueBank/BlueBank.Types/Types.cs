using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BlueBank.Types
{
    public struct ParmStruct
    {
        public ParmStruct(string name, object value,
            SqlDbType dataType, ParameterDirection direction = ParameterDirection.Input, int size = 0)
        {
            Name = name;
            Value = value;
            Size = size;
            DataType = dataType;
            Direction = direction;
        }

        public string Name;
        public object Value;
        public int Size;
        public SqlDbType DataType;
        public ParameterDirection Direction;

    }

}
