using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD1289_Ctrl_App
{
    class AppConstant
    {
        public const char DELIMITER_CMD_END = '\n';
        public const char DELIMITER_CMD_ARG = ' ';
        public const uint RESPONSE_WAIT_TIME_IN_SEC = 2; // seconds
        public const int COMMAND_FAIL = -1;

        public const ushort COLOR_WHITE = 0xFFFF;
        public const ushort COLOR_BLACK = 0x0000;
        public const ushort COLOR_GRAY = 0xF7DE;
        public const ushort COLOR_BLUE = 0x001F;
        public const ushort COLOR_RED = 0xF800;
        public const ushort COLOR_MAGENTA = 0xF81F;
        public const ushort COLOR_GREEN = 0x07E0;
        public const ushort COLOR_CYAN = 0x7FFF;
        public const ushort COLOR_YELLOW = 0xFFE0;
    }
}
