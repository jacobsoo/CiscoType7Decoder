using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CiscoType7Decrypter
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            Type7Decryption();
        }

        public void Type7Decryption()
        {
            byte[] xlat = { 0x64, 0x73, 0x66, 0x64, 0x3b, 0x6b, 0x66, 0x6f, 0x41, 0x2c, 0x2e, 0x69, 0x79, 0x65, 0x77, 0x72, 0x6b, 0x6c, 0x64, 0x4a, 0x4b, 0x44, 0x48, 0x53, 0x55, 0x42 };
            int val = 0;
            string szEncrypted = EncPass.Text;
            string szDecrypted = "";
            int iUnEncrypted_length = (szEncrypted.Length - 2) / 2;
            int iXORindex = ((HexToInt(szEncrypted[0]) - 0) * 10) + (HexToInt(szEncrypted[1]) - 0);

            for (int i = 2; i < szEncrypted.Length; i = i + 2){
                val = HexToInt(szEncrypted[i]) * 16 + HexToInt(szEncrypted[i + 1]);
                szDecrypted += Convert.ToChar(val ^ xlat[iXORindex]);
                iXORindex++;
            }
            DecPass.Text = szDecrypted;
        }

        int HexToInt(char hexChar)
        {
            hexChar = char.ToUpper(hexChar);  // may not be necessary

            return (int)hexChar < (int)'A' ?
                ((int)hexChar - (int)'0') :
                10 + ((int)hexChar - (int)'A');
        }
    }
}
