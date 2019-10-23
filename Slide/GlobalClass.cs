using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide
{
    class GlobalClass
    {
        private static string v_Name = "";

        public static string VariableName
        {
            get { return v_Name; }
            set { v_Name = value; }
        }

        private static string v_Username = "";

        public static string Username
        {
            get { return v_Username; }
            set { v_Username = value; }
        }
    }
}
