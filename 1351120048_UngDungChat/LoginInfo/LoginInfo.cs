using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginInfo
{
    /* Lớp chứa dữ liệu đăng nhập, giúp ta phân biệt các client với nhau thông qua ID */
    public class Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Info()
        {
            Id = 0;
            Name = "";
        }

        public Info(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        /// <summary>
        /// Chuyển object Info thành mảng byte
        /// </summary>
        /// <returns></returns>
        public byte[] Serialize()
        {
            MemoryStream m = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(m);
            writer.Write(Id);
            writer.Write(Name);
            return m.ToArray();
        }
    }

    /// <summary>
    /// Chuyển mảng byte thành object Info
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static Info Desserialize(byte[] data)
    {
        Info result = new Info();
        MemoryStream m = new MemoryStream(data));
        BinaryReader reader = new BinaryReader(m);
        result.Id = reader.ReadInt32();
        result.Name = reader.ReadString();
        return result;
    }
}
