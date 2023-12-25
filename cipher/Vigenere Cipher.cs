using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cipher
{
    public partial class VigenereCipher : Form
    {
        public VigenereCipher()
        {
            InitializeComponent();
        }

        List<char> encryptedText = new  List<char>();
        List<char> decryptedText = new List<char>();
        
        char[] alphabates = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public void doEncryption(string text)
        {
            int keyCounter = 0;   
            char[] charArray = text.ToArray();
            char[] keyArray = key_TB.Text.ToArray();

            for (int i = 0; i < charArray.Count(); i++)
            {
                for (int j = 0; j < alphabates.Count(); j++)
                {
                    try
                    {
                        if (charArray[i] == alphabates[j])
                        {
                            for (int k = 0; k < alphabates.Count(); k++)
                            {
                                if (keyArray[keyCounter] == alphabates[k])
                                {
                                    encryptedText.Add(alphabates[(j + k) % 26]);
                                    keyCounter++;
                                    break;
                                }
                            }

                            if (keyCounter == keyArray.Count())
                                keyCounter = 0;
                        }

                        else if (charArray[i] == ' ')
                        {
                            encryptedText.Add(' ');
                            break;
                        }
                    }
                    catch (Exception) { };
                }
            }
        }

        public void doDecryption(string text)
        {
            int keyCounter = 0;
            char[] charArray = text.ToArray();
            char[] keyArray = key_TB.Text.ToArray();

            for (int i = 0; i < charArray.Count(); i++)
            {
                for (int j = 0; j < alphabates.Count(); j++)
                {
                    try
                    {
                        if (charArray[i] == alphabates[j])
                        {
                            for (int k = 0; k < alphabates.Count(); k++)
                            {
                                if (keyArray[keyCounter] == alphabates[k])
                                {
                                    if ((j - k) < 0)
                                    {
                                        decryptedText.Add(alphabates[(j - k) + 26]);
                                        keyCounter++;
                                        break;
                                    }
                                    else
                                    {
                                        decryptedText.Add(alphabates[(j - k) % 26]);
                                        keyCounter++;
                                        break;
                                    }
                                }
                            }

                            if (keyCounter == keyArray.Count())
                                keyCounter = 0;
                        }

                        else if (charArray[i] == ' ')
                        {
                            decryptedText.Add(' ');
                            break;
                        }
                    }
                    catch (Exception) { };
                }
            }
        }

        private void encrypt_BTN_Click(object sender, EventArgs e)
        {
            doEncryption(inputText_TB.Text);
            string encrypt = string.Join("", encryptedText);
            encryptedText_TB.Text = encrypt;
            encryptedText.Clear();
        }

        private void decrypt_BTN_Click(object sender, EventArgs e)
        {
            doDecryption(encryptedText_TB.Text);
            string decrypt = string.Join("", decryptedText);
            decryptedText_TB.Text = decrypt;
            decryptedText.Clear();
        }

        private void inputText_TB_TextChanged(object sender, EventArgs e)
        {
            encryptedText.Clear();
            decryptedText.Clear();

            encryptedText_TB.Clear();
            decryptedText_TB.Clear();
        }
    }
}
