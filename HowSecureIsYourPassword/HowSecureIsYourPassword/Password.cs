using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace HowSecureIsYourPassword
{
    public class PasswordManager
    {
        public PasswordManager(string password)
        {
            _password = password;
            CalcCharsetLenght();
        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _charsetLenght;
        public int CharsetLenght
        {
            get { return _charsetLenght; }
            private set { _charsetLenght = value; }
        }

        private int CalcCharsetLenght()
        {
            int charsetLenght = 0;

            // Lettere minuscole
            charsetLenght = 26;

            // Lettere maiuscole
            for (int i = 0; i < 26; i++)
            {
                if (_password.Contains((char)(i + 65)))
                {
                    charsetLenght += 26;
                    break;
                }
            }

            // Numeri
            for (int i = 0; i < 10; i++)
            {
                if (_password.Contains(i.ToString()))
                {
                    charsetLenght += 10;
                    break;
                }
            }

            // Simboli
            bool temp = false;
            do
            {
                for (int i = 0; i < 32; i++)
                {
                    if (_password.Contains((char)(i + 32)))
                    {
                        temp = true;
                        break;
                    }
                }
                if (temp)
                    break;
                for (int i = 0; i < 6; i++)
                {
                    if (_password.Contains((char)(i + 91)))
                    {
                        temp = true;
                        break;
                    }
                }
                if (temp)
                    break;
                for (int i = 0; i < 132; i++)
                {
                    if (_password.Contains((char)(i + 123)))
                    {
                        temp = true;
                        break;
                    }
                }
            } 
            while (false); // ciclo usato solo per uscire rapidamente dai tre for
            if (temp)
                charsetLenght += 170;

            _charsetLenght = charsetLenght;
            return charsetLenght;
        }

        public string CalcTotalTime(BigInteger pws_per_second)
        {
            BigInteger total = BigInteger.Pow(new BigInteger(_charsetLenght), _password.Length);
            BigInteger seconds = total / pws_per_second;
            return GooderTheString(seconds);          
        }

        private string GooderTheString(BigInteger seconds)
        {
            if (seconds < 60)
                return seconds.ToString() + " secondi";
            if (seconds < 3600)
                return (seconds / 60).ToString() + " minuti";
            if (seconds < 86400)
                return (seconds / 3600).ToString() + " ore";
            if (seconds < 2629800)
                return (seconds / 86400).ToString() + " giorni";
            if (seconds < 31557600)
                return (seconds / 2629800).ToString() + " mesi";
            if (seconds < 3155760000)
                return (seconds / 31557600).ToString() + " anni";
            BigInteger anni = seconds / 31557600;
            if (anni < 1000)
                return (anni / 100).ToString() + " secoli";
            if (anni < 1000000)
                return (anni / 1000).ToString() + " millenni";
            if (anni < 1000000000)
                return (anni / 1000000).ToString() + " milioni di anni";
            if (anni < 1000000000000)
                return (anni / 1000000000).ToString() + " miliardi di anni";

            string totAnni = anni.ToString("N0", new System.Globalization.CultureInfo("it-IT"));
            if (totAnni.Length > 20)
                totAnni = anni.ToString("E", new System.Globalization.CultureInfo("it-IT")).Replace("E+", " x10^");
            return totAnni + " anni. Un po' troppi...";

        }
    }
}
