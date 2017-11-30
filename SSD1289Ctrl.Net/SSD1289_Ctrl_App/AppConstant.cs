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
    }
}
