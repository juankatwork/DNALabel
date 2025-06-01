using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DNALabelSync
{
    [Serializable]
    public class GlobalSettings
    {
        private string m_AssemblyLine;
        private string m_ModelNumber;
        private string m_WorkDirectory;
        private string m_PrinterName;
        private string m_outputLabel1;
        private string m_outputLabel2;
        private string m_outputLabel3;
        private string m_CurrLabelOutput;
        private string m_CurrLabelSize;
        private bool m_SendToPrinter;
        private string m_Label3x2Url = @"http://api.labelary.com/v1/printers/8dpmm/labels/3x2/0/";
        private string m_Label4x6Url = @"http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/";

        [CategoryAttribute("General Configuration"), DescriptionAttribute("Connection String")]
        public string ConnectionString { set; get; }
        [CategoryAttribute("General Configuration"), DescriptionAttribute("Label Directory")]
        public string WorkDirectory
        {
            set { m_WorkDirectory = value; }
            get { return m_WorkDirectory; }
        }
        [CategoryAttribute("General Configuration"), DescriptionAttribute("Label 3x2 Url")]
        public string Label3x2Url
        {
            get { return m_Label3x2Url; }
            set {  m_Label3x2Url = value;}
        }

        [CategoryAttribute("General Configuration"), DescriptionAttribute("Label 4x6 Url")]
        public string Label4x6Url
        {
            get { return m_Label4x6Url; }
            set { m_Label4x6Url = value; }
        }
        [CategoryAttribute("Daily Configuration"), DescriptionAttribute("Assembly Line")]
        public string AssemblyLine
        {
            set { m_AssemblyLine = value; }
            get { return m_AssemblyLine; }
        }
        [CategoryAttribute("Daily Configuration"), DescriptionAttribute("Model Number")]
        public string ModelNumber
        {
            set { m_ModelNumber = value; }
            get { return m_ModelNumber; }
        }
        [CategoryAttribute("Daily Configuration"), DescriptionAttribute("Printer Name")]
        public string PrinterName
        {
            set { m_PrinterName = value; }
            get { return m_PrinterName; }
        }

         
        [CategoryAttribute("Daily Configuration"), DescriptionAttribute("Send to Printer")]
        public bool SendToPrinter
        {
            set { m_SendToPrinter = value; }
            get { return m_SendToPrinter; }
        }
        [Browsable(true)]
        [DefaultValue("LabelType1")]
        [CategoryAttribute("Daily Configuration")]
        [TypeConverter(typeof(LabelOptions))]
        public string CurrentLabelOutput
        {
            get { return m_CurrLabelOutput; }
            set { m_CurrLabelOutput = value; }
        }

        [Browsable(true)]
        [DefaultValue("3x2")]
        [CategoryAttribute("Daily Configuration")]
        [TypeConverter(typeof(LabelSize))]
        public string CurrentLabelSize
        {
            get { return m_CurrLabelSize; }
            set { m_CurrLabelSize = value; }
        }
    }
   
    [Serializable]
    public class GlobalSettingsMgr
    {
        private const String _configFileName = "GlobalSettings.bin";

        public bool ReadSettings(ref  GlobalSettings settings)
        {
            IFormatter frmtr = new BinaryFormatter();
            IsolatedStorageFile isoStore =
                IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            Stream stream = null;
            try
            {
                // check if file exists
                string[] fileNames = isoStore.GetFileNames(_configFileName);
                if (fileNames.Length > 0)
                {

                    //isoStore.DeleteFile(_configFileName); 

                    stream =
                       new IsolatedStorageFileStream(_configFileName, FileMode.Open, isoStore);

                    settings = (GlobalSettings)frmtr.Deserialize(stream);
                    stream.Close();
                }
                else
                {
                    //file doesn't exist
                    settings = null;
                }
            }
            catch (Exception)
            {
                // file may be corrupted or inaccessable, try to delete and continue with defaults
                try
                {
                    isoStore.DeleteFile(_configFileName);

                }
                catch
                {
                    return false;
                }
            }
            finally
            {


                if (!(stream == null))
                    stream.Close();
            }

            return true;
        }

        public bool ReadSettings(ref GlobalSettings settings, string filePath)
        {
            IFormatter frmtr = new BinaryFormatter();
            Stream stream = null;
            try
            {
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                settings = (GlobalSettings)frmtr.Deserialize(stream);
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Failed to read settings from file:" + filePath + "." + ex.Message);
            }
            finally
            {
                if (!(stream == null))
                    stream.Close();
            }
        }

        public bool SaveSettings(GlobalSettings settings, string filePath)
        {
            Stream stream = null;
            try
            {
                IFormatter frmtr = new BinaryFormatter();
                stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                frmtr.Serialize(stream, settings);
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Failed to save settings to file:" + filePath + "." + ex.Message);
            }
            finally
            {
                if (!(stream == null))
                    stream.Close();
            }
        }


        public bool SaveSettings(GlobalSettings settings)
        {
            IsolatedStorageFile isoStore =
             IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            // IsolatedStorageFile.GetUserStoreForApplication();
            Stream stream = null;
            try
            {
                IFormatter frmtr = new BinaryFormatter();
                stream = new IsolatedStorageFileStream(_configFileName, FileMode.Create, isoStore);
                frmtr.Serialize(stream, settings);
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                try
                {
                    isoStore.DeleteFile(_configFileName);
                }
                catch
                {
                    return false;
                }

                return false;
            }
            finally
            {


                if (!(stream == null))
                    stream.Close();
            }
        }
    }
    class LabelOptions : System.ComponentModel.StringConverter
    {
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] {"LabelType1",
                                                 "LabelTypeUPC",
                                                 "LabelType3"});

        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    class LabelSize : System.ComponentModel.StringConverter
    {
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] {"3x2",
                                                 "4x6"
                                                 });

        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
