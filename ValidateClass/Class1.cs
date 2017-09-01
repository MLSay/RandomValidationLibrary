using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidateClass
{
    public class clsValidation
    {
        public static bool ValidateTextBox(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
