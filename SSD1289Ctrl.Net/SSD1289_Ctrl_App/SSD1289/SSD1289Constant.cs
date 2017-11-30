using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD1289_Ctrl_App.SSD1289
{
    public enum SSD1289_REGISTER
    {
        /// <summary>
        /// Oscillation Start. 
        /// </summary>
        OSC_START = 0x00,

        /// <summary>
        /// Driver output control. 
        /// </summary>
        DRV_OUTPUT = 0X01,

        /// <summary>
        /// LCD drive AC control.
        /// </summary>
        LCD_DRV_AC_COTRL = 0x02,

        /// <summary>
        /// Power control1. 
        /// </summary>
        PWR_CTRL1 = 0x03,

        /// <summary>
        /// Compare register1.
        /// </summary>
        CMP_REG1 = 0x05,

        /// <summary>
        /// Compare register2. 
        /// </summary>
        CMP_REG2 = 0x06,

        /// <summary>
        /// Display control. 
        /// </summary>
        DISP_CTRL = 0x07,

        /// <summary>
        /// Frame cycle control.
        /// </summary>
        FRAME_CYCLE_CTRL = 0x0B,

        /// <summary>
        /// Power control2.
        /// </summary>
        PWR_CTRL2 = 0x0C,

        /// <summary>
        /// Power control3.
        /// </summary>
        PWR_CTRL3 = 0x0D,

        /// <summary>
        /// Power control.
        /// </summary>
        PWR_CTRL4 = 0x0E,

        /// <summary>
        /// Gate scan start position.
        /// </summary>
        GATE_SCAN_START = 0x0F,

        /// <summary>
        /// Sleep mode.
        /// </summary>
        SLEEP_MODE = 0x10,

        /// <summary>
        /// Entry mode.
        /// </summary>
        ENTRY_MODE = 0x11,

        /// <summary>
        /// Optimize Access Speed3.
        /// </summary>
        OPT_ACCESS_SPD3 = 0x12,

        /// <summary>
        /// Generic Interface Control.
        /// </summary>
        GENERIC_IF_CTRL = 0x15,

        /// <summary>
        /// Horizontal Porch.
        /// </summary>
        HORIZONTAL_PORCH = 0x16,

        /// <summary>
        /// Vertical Porch.
        /// </summary>
        VERTICAL_PORCH = 0x17,

        /// <summary>
        /// Power control5.
        /// </summary>
        PWR_CTRL5 = 0x1E,

        /// <summary>
        /// RAM data read(when R/W=1)/write(when R/W=0).
        /// </summary>
        RAM_DATA_RW = 0x22,

        /// <summary>
        /// RAM data write mask1.
        /// </summary>
        RAM_DATA_W_MASK1 = 0x23,

        /// <summary>
        /// RAM data write mask2.
        /// </summary>
        RAM_DATA_W_MASK2 = 0x24,

        /// <summary>
        /// Frame Frequency.
        /// </summary>
        FRAME_FREQ = 0x25,

        /// <summary>
        /// VCOM OTP1(WRONG register number?).
        /// Datasheet Rev 0.32, Datasheet Rev 1.3
        /// </summary>
        VCOM_OTP1 = 0x28,

        /// <summary>
        /// Optimize Access Speed1(WRONG register number?).
        /// Datasheet Rev 1.3
        /// </summary>
        OPT_ACCESS_SPD1 = 0x28,

        /// <summary>
        /// VCOM OTP2(WRONG register number?).
        /// Datasheet Rev 0.32, Datasheet Rev 1.3
        /// </summary>
        VCOM_OTP2 = 0x29,

        /// <summary>
        /// Optimize Access Speed.
        /// </summary>
        OPT_ACCESS_SPD2 = 0x2F,

        /// <summary>
        /// Gamma control1.
        /// </summary>
        GAMMA_CTRL1 = 0x30,

        /// <summary>
        /// Gamma control2.
        /// </summary>
        GAMMA_CTRL2 = 0x31,

        /// <summary>
        /// Gamma control3.
        /// </summary>
        GAMMA_CTRL3 = 0x32,

        /// <summary>
        /// Gamma control4.
        /// </summary>
        GAMMA_CTRL4 = 0x33,

        /// <summary>
        /// Gamma control5.
        /// </summary>
        GAMMA_CTRL5 = 0x34,

        /// <summary>
        /// Gamma control6.
        /// </summary>
        GAMMA_CTRL6 = 0x35,

        /// <summary>
        /// Gamma control7.
        /// </summary>
        GAMMA_CTRL7 = 0x36,

        /// <summary>
        /// Gamma control8.
        /// </summary>
        GAMMA_CTRL8 = 0x37,

        /// <summary>
        /// Gamma control9.
        /// </summary>
        GAMMA_CTRL9 = 0x3A,

        /// <summary>
        /// Gamma control10.
        /// </summary>
        GAMMA_CTRL10 = 0x3B,

        /// <summary>
        /// Vertical scroll control1.
        /// </summary>
        V_SCROLL_CTRL1 = 0x41,

        /// <summary>
        /// Vertical scroll control2.
        /// </summary>
        V_SCROLL_CTRL2 = 0x42,

        /// <summary>
        /// Horizontal RAM address position.
        /// </summary>
        H_RAM_ADDR_POS = 0x44,

        /// <summary>
        /// Vertical RAM address start position.
        /// </summary>
        V_RAM_ADDR_START_POS = 0x45,

        /// <summary>
        /// Vertical RAM address end position.
        /// </summary>
        V_RAM_ADDR_END_POS = 0x46,

        /// <summary>
        /// First window start.
        /// </summary>
        FIRST_WND_START = 0x48,

        /// <summary>
        /// First window end.
        /// </summary>
        FIRST_WND_END = 0x49,

        /// <summary>
        /// Second window start.
        /// </summary>
        SECOND_WND_START = 0x4A,

        /// <summary>
        /// Second window end.
        /// </summary>
        SECOND_WND_END = 0x4B,

        /// <summary>
        /// Set Gamma x address counter.
        /// </summary>
        SET_GAMMA_X_ADDR_COUNTER = 0x4E,

        /// <summary>
        /// Set Gamma y address counter.
        /// </summary>
        SET_GAMMA_Y_ADDR_COUNTER = 0x4F
    }

    class SSD1289Constant
    {
    }
}
