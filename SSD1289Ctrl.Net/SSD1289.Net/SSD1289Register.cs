using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD1289.Net
{
    public enum RwType
    {
        Write,

        Read
    }

    public enum DcType
    {
        Data,

        Command
    }

    [Serializable]
    public class SSD1289Register
    {
        public string Name { get; set; }
        public UInt32 Address { get; set; }
        public UInt32 Bits { get; set; }
        public string Description { get; set; }
        public RwType RW { get; set; }
        public DcType DC { get; set; }
        public UInt32? Value { get; set; }
        public new List<SSD1289BitField> BitFields { get; set; }
    }

}
