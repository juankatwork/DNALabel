using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.TypeConverter;

namespace DNALabelSync
{
    internal class Util
    {
        public GlobalSettings GlblSettings
        {
            set;
            get;
        }
        private string m_labelPath = string.Empty;
        private string m_labelType = string.Empty;
        /*
        private string GetLabelTemplate1()
        {
            string label = string.Format(@"^XA ^FX Top section with logo, name and address.
            ^CF0,30
            ^FO10,30 ^A0,30 ^FDFactory Production Order: dym210110202^FS
            ^FO10,70 ^FDItem No.:^FS
            ^FO10,105 ^FDSupplier STK:^FS
            ^FO10,140 ^FDModel No.:^FS
            ^FO10,175 ^FDSerial No.:^FS
            ^FO200,140^BCN,90,Y,N,N,A^FDA202104000001^FS
            ^FX The next one is a data matrix
            ^FO50,260^BXN,9,200^FDA202104000001^FS
            ^FO200,260^BQN,2,6^FDQA,12345678^FS
            ^XZ
            ");
            label = label.Replace(" ", string.Empty).ToLower().Replace("\r\n", string.Empty).Trim();
            return label;
        }
        public string GetLabelTemplate2(string modelNo,string departmentNo, string serialNo)
        {
            string label = string.Format(@"^XA 
             ^CF0,30
             ^FO10,30 ^A0,30 ^FDP.O. Number:^FS
             ^FO10,70 ^FDSKU Number:^FS
             ^FO10,105 ^FDDepartment Number:{0}^FS
             ^FO10,140 ^FDModel No.:{1}^FS
             ^FO10,175 ^FDSerial No.:{2}^FS
             ^FO15,220^BCN,90,Y,N,N,A^FD{2}^FS
             ^XZ",departmentNo,modelNo,serialNo);
            return label;
        }
        public string GetLabelTemplate2()
        {
            string label = string.Format(@"^XA 
             ^CF0,30
             ^FO10,30 ^A0,30 ^FDP.O. Number:^FS
             ^FO10,70 ^FDSKU Number:^FS
             ^FO10,105 ^FDDepartment Number:{0}^FS
             ^FO10,140 ^FDModel No.:{1}^FS
             ^FO10,175 ^FDSerial No.:{2}^FS
             ^FO15,220^BCN,90,Y,N,N,A^FD{2}^FS
             ^XZ");
            return label;
        }
        */
      
       
        public void SetLabelPathAndType(string path,string type)
        {
            m_labelPath = path;
            m_labelType = type;
            
        }
      
        public void GetLabel(string fileName, string modelNo, string departmentNo, string serialNo, string upc, string description)
        { 
            string ErrorMessage = string.Empty;
            string label = string.Empty;
            string url = string.Empty;
            if (!string.IsNullOrEmpty(m_labelPath))
            {
                switch (m_labelType)
                {
                    case "LabelType1":
                        label = string.Format(File.ReadAllText(m_labelPath), departmentNo, modelNo, serialNo);
                        break;
                    case "LabelTypeUPC":
                        label = string.Format(File.ReadAllText(m_labelPath), modelNo, description , serialNo,upc);
                        break;
                }
            }
            else
            {
                throw new Exception("You must setup the label path.");
            }
            if (GlblSettings.SendToPrinter)
            {
                if (File.Exists(fileName + ".txt"))
                {
                    fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt";
                }
                else
                    fileName = fileName + ".txt";

                File.WriteAllText(fileName, label);
                if (!SendToPrinter(fileName, 10, ref ErrorMessage))
                    MessageBox.Show(ErrorMessage);
            }
            else
            {
                if (File.Exists(fileName + ".pdf"))
                {
                    fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
                }
                else
                    fileName = fileName + ".pdf";
                if (GlblSettings.CurrentLabelSize == "3x2")
                {
                    url = GlblSettings.Label3x2Url;
                }
                else
                {
                    url = GlblSettings.Label4x6Url;
                }
                if (!SendLabelRequest(fileName,url, label, ref ErrorMessage))
                {
                    MessageBox.Show(ErrorMessage);
                }
            }

        }
        public  bool SendToPrinter(string fileName, int labelDelay, ref string ErrorMessage)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = fileName; // @"c:\output.pdf";
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Normal;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                p.WaitForInputIdle();
                if (labelDelay < 1000)
                    System.Threading.Thread.Sleep(2000);
                else
                    System.Threading.Thread.Sleep(labelDelay);
                if (false == p.CloseMainWindow())
                    p.Kill();

                return true;
            }
            catch (Exception ex)
            {   if (ex.Message.Contains("has exited")) {
                    return true;
                }
                ErrorMessage = string.Format("Unable to print. Error='{0}'", ex.Message, ex.StackTrace);
                return false;
            }
        }
        public bool SendLabelRequest(string fileName,string url , string label, ref string ErrorMessage)
        {
            byte[] zpl = Encoding.UTF8.GetBytes(label);
            // adjust print density (8dpmm), label width (4 inches), label height (6 inches), and label index (0) as necessary

//            GlblSettings.Label3x2Url = "http://api.labelary.com/v1/printers/8dpmm/labels/6x4/0/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "application/pdf"; // omit this line to get PNG images back
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = zpl.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(zpl, 0, zpl.Length);
            requestStream.Close();

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();
                var fileStream = File.Create(fileName); // change file name for PNG images
                responseStream.CopyTo(fileStream);
                responseStream.Close();
                fileStream.Close();
                return true;
            }
            catch (WebException ex)
            {
                ErrorMessage = string.Format("Unable to print. Error='{0}'", ex.Message, ex.StackTrace);
                return false;
            }
        }
    }
}
