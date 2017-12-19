using Newtonsoft.Json;
using SSD1289.Net;
using SSD1289_Ctrl_App.AppUtility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace SSD1289_Ctrl_App.SSD1289
{
    struct RegisterValuePair
    {
        public string register;
        public string registerValue;
    }

    enum AppJob
    {
        Unknown,

        BatchWrite,

        Line,

        FillWhite,

        MarkCorner,

        Character
    }

    class AppUtil
    {
        // Load register,value pairs.
        // File format : 
        // hexadecimal_register_without_0x_prefix,hexadecimal_value_without_0x_prefix
        // or
        // sleep,decimal_value_in_millisec
        public static List<RegisterValuePair> LoadRegisterValue(string fileName)
        {
            List<RegisterValuePair> regValues = new List<RegisterValuePair>();
            char[] delimiters = new char[] { ',' };

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] elements = line.Split(delimiters);
                    if (elements?.Length == 2)
                    {
                        regValues.Add(new RegisterValuePair() { register = elements[0], registerValue = elements[1] });
                    }
                }
            }

            return regValues;
        }

        public static List<RegisterValuePair> CreateLineWithBlack()
        {
            List<RegisterValuePair> regValues = new List<RegisterValuePair>();
            string reg;
            string regValue;

            for (int i = 0; i < 240; i++)
            {
                // x coordinate.
                reg = string.Format("{0:x4}", 0x004E);
                regValue = string.Format("{0:x4}", i);
                regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });

                // y coordinate.
                reg = string.Format("{0:x4}", 0x004F);
                regValue = string.Format("{0:x4}", i);
                regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });

                // black color.
                reg = string.Format("{0:x4}", 0x0022);
                regValue = string.Format("{0:x4}", 0);
                regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });
            }

            return regValues;
        }

        public static List<RegisterValuePair> CreateBackgroudWithWhite()
        {
            List<RegisterValuePair> regValues = new List<RegisterValuePair>();
            string reg;
            string regValue;

            for (int i = 0; i < 240; i++)
            {
                for (int j = 0; j < 320; j++)
                {
                    // x coordinate.
                    reg = string.Format("{0:x4}", 0x004E);
                    regValue = string.Format("{0:x4}", i);
                    regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });

                    // y coordinate.
                    reg = string.Format("{0:x4}", 0x004F);
                    regValue = string.Format("{0:x4}", j);
                    regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });

                    // white color.
                    reg = string.Format("{0:x4}", 0x0022);
                    regValue = string.Format("{0:x4}", 0xFFFF);
                    regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });
                }
            }

            return regValues;
        }

        public static List<RegisterValuePair> CreateBackgroudWithColor(ushort color)
        {
            List<RegisterValuePair> regValues = new List<RegisterValuePair>();
            string reg;
            string regValue;

            // x coordinate.
            reg = string.Format("{0:x4}", 0x004E);
            regValue = string.Format("{0:x4}", 0);
            regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });

            // y coordinate.
            reg = string.Format("{0:x4}", 0x004F);
            regValue = string.Format("{0:x4}", 0);
            regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });

            for (int i = 0; i < 240; i++)
            {
                for (int j = 0; j < 320; j++)
                {
                    // Color.
                    reg = string.Format("{0:x4}", 0x0022);
                    regValue = string.Format("{0:x4}", color);
                    regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });

                    //reg = "sleep";
                    //regValue = "10";
                    //regValues.Add(new RegisterValuePair() { register = reg, registerValue = regValue });
                }
            }

            return regValues;
        }

        public static List<T> LoadRegister<T>(string fileName)
        {
            List<T> registers = null;

            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sr = File.OpenText(fileName))
            {
                registers = (List<T>)serializer.Deserialize(sr, typeof(List<T>));
            }
            
            return registers;
        }

        public static List<SSD1289BitField> CreateUniqueBitFields(List<SSD1289BitField> templates, List<SSD1289BitField> currentBitFields)
        {
            List<SSD1289BitField> uniqueBitFields = null;

            if (currentBitFields == null || currentBitFields.Count == 0)
            {
                uniqueBitFields = new List<SSD1289BitField>();
                uniqueBitFields.AddRange(templates);
            }
            else
            {
                foreach (SSD1289BitField template in templates)
                {
                    bool found = false;
                    foreach (SSD1289BitField item in currentBitFields)
                    {
                        if (template.Offset == item.Offset)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        if (uniqueBitFields == null)
                        {
                            uniqueBitFields = new List<SSD1289BitField>();
                        }
                        uniqueBitFields.Add(template);
                    }
                }
            }

            return uniqueBitFields;
        }

        internal static List<RegisterValuePair> CreateCornerPixels()
        {
            List<RegisterValuePair> regValues = new List<RegisterValuePair>();

            // (0, 0), black
            AddPixel(regValues, 1, 1, AppConstant.COLOR_BLACK);

            // (239, 0), red
            AddPixel(regValues, 238, 1, AppConstant.COLOR_RED);

            // (239, 319), blue
            AddPixel(regValues, 238, 318, AppConstant.COLOR_BLUE);

            // (0, 319), green
            AddPixel(regValues, 1, 318, AppConstant.COLOR_GREEN);

            return regValues;
        }

        internal static void AddPixel(List<RegisterValuePair> data, UInt32 x, UInt32 y, ushort color)
        {
            string reg;
            string regValue;

            // x coordinate.
            reg = string.Format("{0:x4}", 0x004E);
            regValue = string.Format("{0:x4}", x);
            data.Add(new RegisterValuePair() { register = reg, registerValue = regValue });

            // y coordinate.
            reg = string.Format("{0:x4}", 0x004F);
            regValue = string.Format("{0:x4}", y);
            data.Add(new RegisterValuePair() { register = reg, registerValue = regValue });

            // Color.
            reg = string.Format("{0:x4}", 0x0022);
            regValue = string.Format("{0:x4}", color);
            data.Add(new RegisterValuePair() { register = reg, registerValue = regValue });
        }

        internal static List<RegisterValuePair> CreateAscii()
        {
            byte[,] ascii = AppFont.MsGothicAscii;
            List<RegisterValuePair> asciiData = new List<RegisterValuePair>();

            for (int i = 0; i < 16; i++)
            {
                byte line = ascii[33, i];
                for (int ii = 0; ii < 8; ii++)
                {
                    if (((line >> (7 - ii)) & 0x01) == 0x01)
                    {
                        AddPixel(asciiData, (UInt32)(10 + ii), (UInt32)(10 + i), AppConstant.COLOR_BLACK);
                    }
                    else
                    {
                        AddPixel(asciiData, (UInt32)(10 + ii), (UInt32)(10 + i), AppConstant.COLOR_GREEN);
                    }
                }
            }

            return asciiData;
        }
    }
}
