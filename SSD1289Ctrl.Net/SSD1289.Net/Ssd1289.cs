using SSD1289.Net.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD1289.Net
{
    /// <summary>
    /// R00h
    /// Read only, Command
    /// Fixed value : 0x8989
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct DeviceCodeReadReg : IBitField
    {
        [BitFieldInfo(0, 16)]
        public ushort DeviceCode { get; set; }
    }

    /// <summary>
    /// R00h
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct OscillatorReg : IBitField
    {
        [BitFieldInfo(0, 1)]
        public bool OSCEN { get; set; }
    }

    /// <summary>
    /// Driver Output Control
    /// R01h
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct DriverOutCtrlReg : IBitField
    {
        [BitFieldInfo(0, 9)]
        public ushort MUX { get; set; }

        [BitFieldInfo(9, 1)]
        public bool TB { get; set; }

        [BitFieldInfo(10, 1)]
        public bool SM { get; set; }

        [BitFieldInfo(11, 1)]
        public bool BGR { get; set; }

        [BitFieldInfo(12, 1)]
        public bool CAD { get; set; }

        [BitFieldInfo(13, 1)]
        public bool REV { get; set; }

        [BitFieldInfo(14, 1)]
        public bool RL { get; set; }
    }

    /// <summary>
    /// LCD-Driving-Waveform Control
    /// R02h
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct LcdDrivingWaveformCtrlReg : IBitField
    {
        [BitFieldInfo(0, 8)]
        public ushort NW { get; set; }

        [BitFieldInfo(8, 1)]
        public bool WSMD { get; set; }

        [BitFieldInfo(9, 1)]
        public bool EOR { get; set; }

        [BitFieldInfo(10, 1)]
        public bool BC { get; set; }

        [BitFieldInfo(11, 1)]
        public bool ENWS { get; set; }

        [BitFieldInfo(12, 1)]
        public bool FLD { get; set; }
    }

    /// <summary>
    /// R03h
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct PowerControl1Reg : IBitField
    {
        [BitFieldInfo(1, 3)]
        public byte AP { get; set; }
        [BitFieldInfo(4, 4)]
        public byte DC { get; set; }
        [BitFieldInfo(9, 3)]
        public byte BT { get; set; }
        [BitFieldInfo(12, 4)]
        public byte DCT { get; set; }
    }

    /// <summary>
    /// Compare register1
    /// R05h
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct Compare1Reg : IBitField
    {
        [BitFieldInfo(2, 6)]
        public byte CPG { get; set; }
        [BitFieldInfo(10, 6)]
        public byte CPR { get; set; }
    }

    /// <summary>
    /// Compare register2
    /// R06h
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct Compare2Reg : IBitField
    {
        [BitFieldInfo(2, 6)]
        public byte CPB { get; set; }
    }

    /// <summary>
    /// Display control
    /// R07h
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct DisplayCtrlReg : IBitField
    {
        [BitFieldInfo(0, 2)]
        public byte D { get; set; }

        [BitFieldInfo(3, 1)]
        public bool CM { get; set; }

        [BitFieldInfo(4, 1)]
        public bool DTE { get; set; }

        [BitFieldInfo(5, 1)]
        public bool GON { get; set; }

        [BitFieldInfo(8, 1)]
        public bool SPT { get; set; }

        [BitFieldInfo(9, 2)]
        public bool VLE { get; set; }

        [BitFieldInfo(11, )]
        public bool PT { get; set; }
    }

    /// <summary>
    /// Frame Cycle Control
    /// R0Bh
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct FrameCycleCtrlReg : IBitField
    {
        [BitFieldInfo(0, 4)]
        public byte RTN { get; set; }

        [BitFieldInfo(5, 1)]
        public bool SDIV { get; set; }

        [BitFieldInfo(6, 2)]
        public byte DIV { get; set; }

        [BitFieldInfo(8, 3)]
        public byte EQ { get; set; }

        [BitFieldInfo(12, 2)]
        public byte SDT { get; set; }

        [BitFieldInfo(14, 2)]
        public byte NO { get; set; }
    }

    /// <summary>
    /// R0Ch
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct PowerControl2Reg : IBitField
    {
        [BitFieldInfo(0, 3)]
        public byte VRC { get; set; }
    }

    /// <summary>
    /// R0Dh
    /// Write, Command
    /// </summary>
    [BitFieldNumberOfBitsAttribute(16)]
    public struct PowerControl3Reg : IBitField
    {
        [BitFieldInfo(0, 4)]
        public bool VRH { get; set; }
    }


    public class Ssd1289
    {
        public DeviceCodeReadReg DeviceCodeReg;
        public OscillatorReg OscillatorReg;
        public PowerControl1Reg PowerCtrl1Reg;
        public PowerControl2Reg PowerCtrl2Reg;
        public PowerControl3Reg PowerCtrl3Reg;
    }
}
