using System;
using System.Globalization;
using System.IO.Ports;
using GemBox.Spreadsheet;
using Ini;

namespace Parametri_in_MODBUS
{
    class Funzioni
    {
        //-------Variabili------
        public string RxBuf;
        public string msgTextRx;
        public string indRx = "-";
        public string funzioneRx = "-";
        public string valoreRx = "-";
        public string dataRx = "-";
        public string byteRx = "-";
        public string LRCCalcHex;
        public string indHex, funzioneHex, indStartHex, valoreHex = "";
        public string valoreHex1;
        public string valoreHex2;
        public string indStartHex1;
        public string indStartHex2;
        public string LRCTx;
        public string PathImpostazioni = "D:\\settings.ini";
        int uno = 2;
        //--------Chiamate------
        ExcelFile ef = new ExcelFile();
        IniFile ini = new IniFile();
        //--------Funzioni------
        public void portaserialeDataRecived(object sender, SerialDataReceivedEventArgs e, SerialPort portaSeriale)
        {
            RxBuf = portaSeriale.ReadExisting();
        }
        public string RxData(SerialPort portaSeriale)
        {
            msgTextRx = "";
            msgTextRx = portaSeriale.ReadExisting();
            return msgTextRx;
        }
        public string DecToHex8bit(int dec)
        {
            string converted = string.Format("{0:X}", dec);
            if (dec < 16)
            {
                converted = "0" + converted;
            }
            return converted;
        }
        public string DecToHex16bit(int dec)
        {
            string converted = string.Format("{0:X}", dec);
            if (dec <= 15)
            {
                converted = "000" + converted;
            }
            if (dec <= 255 && dec > 16)
            {
                converted = "00" + converted;
            }
            if (dec <= 4095 && dec > 255)
            {
                converted = "0" + converted;
            }
            if (dec < 0)
            {
                converted = converted.Remove(0, 7);
            }
            return converted;
        }
        public string CalcoloLRCLetturaTx()
        {
            Int16 indDecTemp = Int16.Parse(indHex, NumberStyles.HexNumber);
            Int16 funzioniDecTemp = Int16.Parse(funzioneHex, NumberStyles.HexNumber);
            Int16 indStartDecTemp1 = Int16.Parse(indStartHex1, NumberStyles.HexNumber);
            Int16 indStartDecTemp2 = Int16.Parse(indStartHex2, NumberStyles.HexNumber);
            Int32 LRC = ((indDecTemp + funzioniDecTemp + indStartDecTemp1 + indStartDecTemp2 + 1)* -1);
            string converted = string.Format("{0:X}", LRC);
            converted = converted.Remove(0, 6);
            return converted.ToString();
        }
        public string CalcoloLRCScritturaTx()
        {
            Int16 indDecTemp = Int16.Parse(indHex, NumberStyles.HexNumber);
            Int16 funzioniDecTemp = Int16.Parse(funzioneHex, NumberStyles.HexNumber);
            Int16 indStartDecTemp1 = Int16.Parse(indStartHex1, NumberStyles.HexNumber);
            Int16 indStartDecTemp2 = Int16.Parse(indStartHex2, NumberStyles.HexNumber);
            Int16 valoreDecTemp1 = Int16.Parse(valoreHex1, NumberStyles.HexNumber);
            Int16 valoreDecTemp2 = Int16.Parse(valoreHex2, NumberStyles.HexNumber);
            Int32 LRC = ((indDecTemp + funzioniDecTemp + indStartDecTemp1 + indStartDecTemp2 + valoreDecTemp1 + valoreDecTemp2) * -1);
            string converted = string.Format("{0:X}", LRC);
            converted = converted.Remove(0, 6);
            return converted.ToString();
        }
        public void CalcoloLRCTx(int indDec, int funzioneDec, int indStartDec, int valoreDec)
        {
            {
                if (indDec < 256)
                {
                    indHex = DecToHex8bit(indDec);
                }
                else
                {
                    indHex = "";
                }
            }
            {
                if (funzioneDec.ToString() != "")
                {
                    funzioneHex = DecToHex8bit(funzioneDec);
                }
                else
                {
                    funzioneHex = "";
                }
            }
            {
                if (indStartDec < 65535)
                {
                    indStartHex = DecToHex16bit(indStartDec);
                    indStartHex1 = indStartHex.Remove(2);
                    indStartHex2 = indStartHex.Remove(0, 2); 
                }
                else
                {
                    indStartHex = "";
                }
            }
            {
                if (valoreDec != 0)
                {
                    valoreHex = DecToHex16bit(valoreDec);
                    valoreHex1 = valoreHex.Remove(2);
                    valoreHex2 = valoreHex.Remove(0, 2);
                }
                else
                {
                    valoreHex = "";
                }
            }
            if (valoreDec == 0)
            {
                LRCTx = CalcoloLRCLetturaTx();
            }
            if (valoreDec != 0)
            {
                LRCTx = CalcoloLRCScritturaTx();
            }
        }
        public bool CalcoloLRCRx(string source)
        {
            if (source.Length == 15)
            {
                string _indirizzo = source;
                _indirizzo = _indirizzo.Remove(0, 1);
                _indirizzo = _indirizzo.Remove(2);
                //----
                string _funzione = source;
                _funzione = _funzione.Remove(0, 3);
                _funzione = _funzione.Remove(2);
                //----
                string _byte = source;
                _byte = _byte.Remove(0, 5);
                _byte = _byte.Remove(2);
                //----
                string _valore1 = source;
                _valore1 = _valore1.Remove(0, 7);
                _valore1 = _valore1.Remove(2);
                //----
                string _valore2 = source;
                _valore2 = _valore2.Remove(0, 9);
                _valore2 = _valore2.Remove(2);
                //----
                int _ind = int.Parse(_indirizzo, NumberStyles.HexNumber);
                int _fun = int.Parse(_funzione, NumberStyles.HexNumber);
                int _byt = int.Parse(_byte, NumberStyles.HexNumber);
                int _val1 = int.Parse(_valore1, NumberStyles.HexNumber);
                int _val2 = int.Parse(_valore2, NumberStyles.HexNumber);
                int LRCcalcDec = ((_ind + _fun + _byt + _val1 + _val2) * -1);
                LRCCalcHex = DecToHex8bit(LRCcalcDec);
                LRCCalcHex = LRCCalcHex.Remove(0, 7);
                string LRCorig = source.Remove(0, 11);
                LRCorig = LRCorig.Remove(2);
                if (LRCCalcHex == LRCorig)
                {
                    return true;
                }                
            }
            if (source.Length == 17)
            {
                string source_2 = source.Remove(0, 13);
                source_2 = source_2.Remove(2);
                //----
                string _indirizzo = source;
                _indirizzo = _indirizzo.Remove(0, 1);
                _indirizzo = _indirizzo.Remove(2);
                //----
                string _funzione = source;
                _funzione = _funzione.Remove(0, 3);
                _funzione = _funzione.Remove(2);
                //----
                string _start1 = source;
                _start1 = _start1.Remove(0, 5);
                _start1 = _start1.Remove(2);
                //----
                string _start2 = source;
                _start2 = _start2.Remove(0, 7);
                _start2 = _start2.Remove(2);
                //----
                string _data1 = source;
                _data1 = _data1.Remove(0, 9);
                _data1 = _data1.Remove(2);
                //----
                string _data2 = source;
                _data2 = _data2.Remove(0, 11);
                _data2 = _data2.Remove(2);
                //----
                int _ind = int.Parse(_indirizzo, NumberStyles.HexNumber);
                int _fun = int.Parse(_funzione, NumberStyles.HexNumber);
                int _sta1 = int.Parse(_start1, NumberStyles.HexNumber);
                int _sta2 = int.Parse(_start2, NumberStyles.HexNumber);
                int _dat1 = int.Parse(_data1, NumberStyles.HexNumber);
                int _dat2 = int.Parse(_data2, NumberStyles.HexNumber);
                int LRCcalcDec = ((_ind + _fun + _sta1 + _sta2 + _dat1 + _dat2) * -1);
                LRCCalcHex = DecToHex8bit(LRCcalcDec);
                LRCCalcHex = LRCCalcHex.Remove(0, 7);
                string LRCorig = source.Remove(0, 13);
                LRCorig = LRCorig.Remove(2);
                if (LRCorig == LRCCalcHex)
                {
                    return true;
                }
            }
            return false;
        }
        public string HexToDec(string Hex)
        {
            Int16 Dec = Int16.Parse(Hex, NumberStyles.HexNumber);
            return Dec.ToString();
        }
        public void Decript(string source)
        {
            string source_s2p = source.Remove(0, 1);
            if (source.Length == 15)
            {
                indRx = source_s2p;
                indRx = indRx.Remove(2);
                indRx = HexToDec(indRx);
                //----
                funzioneRx = source_s2p;
                funzioneRx = funzioneRx.Remove(0, 2);
                funzioneRx = funzioneRx.Remove(2);
                funzioneRx = HexToDec(funzioneRx);
                //----
                valoreRx = source_s2p;
                valoreRx = valoreRx.Remove(0, 6);
                valoreRx = valoreRx.Remove(4);
                valoreRx = HexToDec(valoreRx);
                //----
                byteRx = source_s2p;
                byteRx = byteRx.Remove(0, 4);
                byteRx = byteRx.Remove(6);
            }
            if (source.Length == 17)
            {
                indRx = source_s2p;
                indRx = indRx.Remove(2);
                indRx = HexToDec(indRx);
                //----
                funzioneRx = source_s2p;
                funzioneRx = funzioneRx.Remove(0, 2);
                funzioneRx = funzioneRx.Remove(2);
                funzioneRx = HexToDec(funzioneRx);
                //----
                valoreRx = source_s2p;
                valoreRx = valoreRx.Remove(0, 4);
                valoreRx = valoreRx.Remove(4);
                valoreRx = HexToDec(valoreRx);
                //----
                dataRx = source_s2p;
                dataRx = dataRx.Remove(0, 8);
                dataRx = dataRx.Remove(4);
                dataRx = HexToDec(dataRx);
                //----
                byteRx = "-";
            }
        }
        public void FileXLS(int indirizzo, int funzione, int valore, int data, string ora)
        {
            ef.Worksheets.ActiveWorksheet.Cells["A" + uno.ToString()].Value = ora;
            ef.Worksheets.ActiveWorksheet.Cells["B" + uno.ToString()].Value = indirizzo;
            ef.Worksheets.ActiveWorksheet.Cells["C" + uno.ToString()].Value = funzione;
            ef.Worksheets.ActiveWorksheet.Cells["D" + uno.ToString()].Value = valore;
            ef.Worksheets.ActiveWorksheet.Cells["E" + uno.ToString()].Value = data;
            uno = uno + 1;
        }
        public void NewSheet()
        {
            ef.Worksheets.Add("Data");
            ef.Worksheets.ActiveWorksheet.Cells["A1"].Value = "Ora";
            ef.Worksheets.ActiveWorksheet.Cells["B1"].Value = "Indirizzo";
            ef.Worksheets.ActiveWorksheet.Cells["C1"].Value = "Funzione";
            ef.Worksheets.ActiveWorksheet.Cells["D1"].Value = "Valore";
            ef.Worksheets.ActiveWorksheet.Cells["E1"].Value = "Data";
        }
        public void salvaExcel()
        {
            if (ini.IniReadValue("Save", "Formato") == "xls")
            {
                ef.SaveXls(ini.IniReadValue("Save", "Nome").ToString() + ".xls");
            }
            if (ini.IniReadValue("Save", "Formato") == "xlsx")
            {
                ef.SaveXlsx(ini.IniReadValue("Save", "Nome").ToString() + ".xlsx");
            }
            if (ini.IniReadValue("Save", "Formato") == "ods")
            {
                ef.SaveOds(ini.IniReadValue("Save", "Nome").ToString() + ".ods");
            }
            if (ini.IniReadValue("Save", "Formato") == "csv")
            {
                ef.SaveCsv(ini.IniReadValue("Save", "Nome").ToString() + ".csv", ';');
            }
            if (ini.IniReadValue("Save", "Formato") == "html")
            {
                ef.SaveHtml(ini.IniReadValue("Save", "Nome").ToString() + ".html", null, true);
            }
            if (ini.IniReadValue("Save", "Formato") == "none")
            {
                return;
            }
            ef.Worksheets.ActiveWorksheet.Delete();
        }
        public void Esci()
        {
            ef.Worksheets.ActiveWorksheet.Delete();
        }
    }
}
