using System;
using System.Collections.Generic;

namespace SSD1289.Net
{
    [Serializable]
    public class SSD1289BitField
    {
        #region Private Constants
        const byte MAX_BIT = 32; // For now, 32-bit is good for me.
        #endregion Private Constants

        #region Private Data
        UInt32 _bits = 0;
        UInt32 _offset = 0;
        #endregion Private Data

        #region Public Properties
        public string Name { get; set; }
        public UInt32 Offset
        {
            get
            {
                return _offset;
            }
            set
            {
                // 0 <= offset < MAX_BIT
                if ((_offset >= 0) && (_offset < MAX_BIT))
                {
                    _offset = value;
                }
                else
                {
                    throw new Exception("Invalid offset value.");
                };
            }
        }
        public UInt32 Bits
        {
            get
            {
                return _bits;
            }
            set
            {
                // 0 <= bits <= MAX_BIT
                if ((_bits >= 0) && (_bits <= MAX_BIT))
                {
                    _bits = value;
                }
                else
                {
                    throw new Exception("Invalid bits value.");
                }
            }
        }
        public UInt32 Value { get; set; }
        public string Description { get; set; }
        #endregion Public Properties

        #region Public Static Methods
        public static UInt32 CalculateValueFromBitFields(List<SSD1289BitField> bitFields)
        {
            UInt32 value = 0;

            foreach (SSD1289BitField bitField in bitFields)
            {
                value |= ((UInt32)bitField.Value << (int)bitField.Offset);
            }

            return value;
        }

        public static List<SSD1289BitField> CreateBitFieldsFromValue(SSD1289Register regTemplate, UInt32 value)
        {
            List<SSD1289BitField> bitFields = new List<SSD1289BitField>();

            foreach (SSD1289BitField bfItem in regTemplate.BitFields)
            {
                UInt32 unshiftedValue = 0;
                UInt32 shiftedValue = 0;
                UInt32 mask = 0;

                for (byte i = 0; i < bfItem.Bits; i++)
                    mask |= (ushort)(0x0001 << i);
                mask <<= (ushort)bfItem.Offset;

                unshiftedValue = (value & mask);
                shiftedValue = (unshiftedValue >> (ushort)bfItem.Offset);

                if (shiftedValue > 0)
                {
                    SSD1289BitField bitField = new SSD1289BitField()
                    {
                        Bits = bfItem.Bits,
                        Description = bfItem.Description,
                        Name = bfItem.Name,
                        Offset = bfItem.Offset,
                        Value = shiftedValue
                    };
                    bitFields.Add(bitField);
                }
            }

            return bitFields;
        }
        #endregion Public Static Methods

        #region Public Methods
        public string GetStringValueInHex()
        {
            if ((_bits >= 1) && (_bits <= 8))
            {
                return string.Format($"{Value:X2}");
            }
            else if ((_bits > 8) && (_bits <= 16))
            {
                return string.Format($"{Value:X4}");
            }
            else if ((_bits > 16) && (_bits <= 32))
            {
                return string.Format($"{Value:X8}");
            }
            else if ((_bits > 32) && (_bits <= 64))
            {
                return string.Format($"{Value:X16}");
            }
            
            return string.Empty;
        }
        #endregion Public Methods
    }
}
