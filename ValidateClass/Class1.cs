using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ValidationClass
{
    public class clsValidation
    {
        public static bool ValidateTextBox(TextBox txt)
        {
            // if (String.IsNullOrEmpty(txt.Text))
            if (String.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show(txt.Tag + " is required");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateTextBoxForNumeric(TextBox txt)
        {
            try
            {
                Convert.ToInt32(txt.Text);
                return true;
            }
            catch
            {
                MessageBox.Show(txt.Tag + " must be numeric");
                return false;
            }
        }
        public static bool ValidateForNumeric(String str1, String str2)
        {
            try
            {
                Convert.ToInt32(str1);
                return true;
            }
            catch
            {
                MessageBox.Show(str2 + " must be numeric");
                return false;
            }
        }
        public static bool ValidateRadioButton(RadioButton rdb1, RadioButton rdb2)
        {
            if (rdb1.Checked == false && rdb2.Checked == false)
            {
                MessageBox.Show("Please select a " + rdb1.Tag);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateComboBox(ComboBox cmb)
        {
            if (cmb.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a " + cmb.Tag);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateDOB(TextBox txt)
        {
            if (!ValidateTextBox(txt))
            {
                return false;
            }

            try
            {
                String strYear = txt.Text.Substring(0, 4);
                String strMonth = txt.Text.Substring(5, 2);
                String strDay = txt.Text.Substring(8, 2);
                String strFifthChar = txt.Text.Substring(4, 1);
                String strEightChar = txt.Text.Substring(7, 1);

                if (!ValidateForNumeric(strYear, "Year"))
                {
                    return false;
                }
                if (!ValidateForNumeric(strMonth, "Month"))
                {
                    return false;
                }
                if (!ValidateForNumeric(strDay, "Day"))
                {
                    return false;
                }
                if (strFifthChar != "-")
                {
                    MessageBox.Show("The fifth character must be a hyphen");
                    return false;
                }
                if (strEightChar != "-")
                {
                    MessageBox.Show("The eight character must be a hyphen");
                    return false;
                }
                return true;
            }
            catch
            {
                MessageBox.Show(txt.Tag + " format is incorrect!\nMust be YYYY-MM-DD format");
                return false;
            }

        }

        public static bool ValidateEmail(TextBox txt)
        {
            if (!ValidateTextBox(txt))
            {
                return false;
            }
            String email = txt.Text;
            if (email.IndexOf("@") == -1)
            {
                MessageBox.Show("Email address must contain an @ character");
                return false;
            }
            if (email.IndexOf("@") != email.LastIndexOf("@"))
            {
                MessageBox.Show("Email address must only contain one @ character");
                return false;
            }
            if (email.IndexOf("@") == 0 || email.LastIndexOf("@") == email.Length - 1)
            {
                MessageBox.Show("The @ character cannot be on the first and last position");
                return false;
            }
            if (email.IndexOf(".") == -1)
            {
                MessageBox.Show("The email must contain at least on . character");
                return false;
            }
            if (email.IndexOf("@.") > -1 || email.IndexOf(".@") > -1)
            {
                MessageBox.Show("The email address cannot contain the @. or .@ together");
                return false;
            }
            if (email.IndexOf(".") == 0 || email.LastIndexOf(".") == email.Length - 1)
            {
                MessageBox.Show("The . cannot be the first or last character");
                return false;
            }
            return true;

        }

        public static bool ValidateTextBoxRange(TextBox txt1, int min, int max)
        {
            if (Convert.ToInt32(txt1.Text) > min && Convert.ToInt32(txt1.Text) < max)
            {
                return true;
            }
            else
            {
                MessageBox.Show(txt1.Tag + " is out of range");
                return false;
            }
        }

        //public static bool ValidateDateRange()
        //{

        //}

        public static bool ValidateTextBoxLength(TextBox txt, int len)
        {
            if (txt.Text.Length != len)
            {
                MessageBox.Show(txt.Tag + " must be " + len + " characters");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateForAlphabet(TextBox txt)
        {
            foreach (char item in txt.Text)
            {
                if (char.IsDigit(item) || char.IsSymbol(item) || char.IsPunctuation(item))
                {
                    MessageBox.Show(txt.Tag + " must only contain alphabetic characters.");
                    return false;
                }
            }
            return true;
        }
        public static bool CheckDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                MessageBox.Show("Date is out of range.\nPlease enter month range between 1-12 and day range between 1-31");
                return false;
            }
        }
        public static bool ValidateStringForNumeric(String txt, String str)
        {
            try
            {
                Convert.ToInt32(txt);
                return true;
            }
            catch
            {
                MessageBox.Show(str);
                return false;
            }
        }
    }
}
