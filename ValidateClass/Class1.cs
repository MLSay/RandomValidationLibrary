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

        public static bool ValidateDOB(DateTimePicker dateTimePicker)
        {
            if (string.IsNullOrWhiteSpace(dateTimePicker.Text))
            {
                MessageBox.Show("Please select " + dateTimePicker.Tag);
                dateTimePicker.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ValidateEmail(TextBox txt)
        {
            if (!ValidateTextBox(txt))
            {
                return false;
            }
            String email = txt.Text;        

            Regex reg = new Regex(@"^([A-Z]{1})([a-z]+)([A-Z]{1})([a-z]+)@([d]{1}[u]{1}[m]{2}[y]{1})([M]{1}[a]{1}[i]{1}[l]{1})(\.[c]{1}[o]{1}[m]{1})\.([a]{1}[u]{1})$");
            if (email.IndexOf("@") == -1)
            {
                MessageBox.Show(txt.Tag + " must contain an @ character" + "\nImportant Note: " + txt.Tag + " format must be:\nFirstnameLastname@dummyMail.com.au");
                return false;
            }
            if (email.IndexOf("@") != email.LastIndexOf("@"))
            {
                MessageBox.Show(txt.Tag + " must only contain one @ character");
                return false;
            }
            if (email.IndexOf("@") == 0 || email.LastIndexOf("@") == email.Length - 1)
            {
                MessageBox.Show("The @ character cannot be on the first and last position");
                return false;
            }
            if (email.IndexOf(".") == -1)
            {
                MessageBox.Show(txt.Tag + " must contain at least on . character");
                return false;
            }
            if (email.IndexOf("@.") > -1 || email.IndexOf(".@") > -1)
            {
                MessageBox.Show(txt.Tag + " cannot contain the @. or .@ together");
                return false;
            }
            if (email.IndexOf(".") == 0 || email.LastIndexOf(".") == email.Length - 1)
            {
                MessageBox.Show("The . cannot be the first or last character");
                return false;
            }
            if (!reg.IsMatch(txt.Text))
            {
                MessageBox.Show("Important note: " + txt.Tag + " format must be:\nFirstnameLastname@dummyMail.com.au");
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

        public static bool ValidateStreetAddress(TextBox txt)
        {
            Regex reg = new Regex(@"^([\d]+)\s([A-Z]{1})([a-z]+)\s([A-Z]{1})([a-z]+)([\.]?)$");
            if (reg.IsMatch(txt.Text)) return true;
            else MessageBox.Show(txt.Tag + " must begin with the street number followed by the street name. Each word must begin with a capital letter. \nFor example: 8 Happy St.");
            return false;
        }

        public static bool ValidatePostCode(string code)
        {
            if (code == null || code.Length != 4)
            {
                MessageBox.Show("Post code must contain four numeric characters.");
                return false;
            }
            var characters = code.ToCharArray();
            if (characters.Any(character => !Char.IsNumber(character)))
            {
                MessageBox.Show("Post code must contain four numeric characters.");
                return false;
            }
            if ("013456789".Contains(characters.First()))
            {
                MessageBox.Show("Invalid post code!\nPost code must start with 2 and contain four numeric characters.");
                return false;
            }
            return true;
        }

        public static bool ValidatePhoneNumber(TextBox txt)
        {
            Regex reg = new Regex(@"^[0]{1}[4]{1}[0-9]{8}$");
            if (reg.IsMatch(txt.Text)) return true;
            else MessageBox.Show("Invalid! " + txt.Tag + " Try again.\n" + txt.Tag + " should start with 04********\nand consist of 10 numeric values");
            return false;
        }

        public static bool ValidateNameFormat(TextBox txt)
        {
            Regex reg = new Regex(@"^[A-Z]{1}([a-z]+)$");
            if (reg.IsMatch(txt.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show(txt.Tag + " must start with a capital letter and consist of more than 1 alphabet.");
                return false;
            }
        }
    }
}
