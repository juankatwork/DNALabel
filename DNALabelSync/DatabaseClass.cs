using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNALabelSync
{

    class DatabaseClass
    {
        DNASerialDataClassesDataContext m_dnaDataContext = new DNASerialDataClassesDataContext();
        public string ErrorMessage { set; get; }
        public DatabaseClass()
        {
           
        }
        public bool Connect(string connString)
        {
            try
            {
                m_dnaDataContext = new DNASerialDataClassesDataContext(connString);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public string GetLabelPath(int assemblyLineNo)
        {
            try
            {
                    var query = (from i in m_dnaDataContext.AssemblyLineInformations
                            where i.Line_No_ == assemblyLineNo
                            select i).FirstOrDefault();

                if (query != null)
                {
                    return query.Label_Path;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return string.Empty;
            }
        }
        public List<AssemblyLineInformation> LoadAssemblyLineInfo()
        {
            try
            {
                var query = from i in m_dnaDataContext.AssemblyLineInformations
                            select i;
                if (query.Count() > 0)
                    return query.ToList();
                else
                {
                    ErrorMessage = "No data.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return null;
            }
        }
        public bool InsertAssemblyLineInfo(AssemblyLineInformation ali)
        {
            try
            {
                m_dnaDataContext.AssemblyLineInformations.InsertOnSubmit(ali);
                m_dnaDataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return false;
            }

            return true;
        }
        public bool UpdateAssemblyLineInfo(AssemblyLineInformation ali)
        {
            try
            {
                var lAssemblyLineInfo = (from i in m_dnaDataContext.AssemblyLineInformations
                                   where i.Line_No_ == ali.Line_No_
                                   select i).FirstOrDefault();
                if (lAssemblyLineInfo != null)
                {
                    lAssemblyLineInfo.Location = ali.Location;
                    lAssemblyLineInfo.Label_Path = ali.Label_Path;
                    m_dnaDataContext.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return false;
            }
        }
        public string GetItemMasterSerialIdentifierAndUPC(string ItemModel,ref string UPC,ref string description)
        {
            var lItemMaster = (from i in m_dnaDataContext.ItemMasters
                               where i.Item_Model_Number.ToLower() == ItemModel.ToLower()
                               select i).FirstOrDefault();
            if (lItemMaster != null)
            {
                
                UPC = lItemMaster.UPC_Code;
                description = lItemMaster.Description;
                return lItemMaster.Engine_Serial_No__Identifier;
            }
            return string.Empty;
        }
        public List<ItemMaster> LoadMasterItems()
        {
            try
            {
                var query = from i in m_dnaDataContext.ItemMasters
                            select i;
                if (query.Count() > 0)
                    return query.ToList();
                else
                {
                    ErrorMessage = "No data.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return null;
            }
        }
        public bool InserItemMaster(ItemMaster im)
        {
            try
            {
                m_dnaDataContext.ItemMasters.InsertOnSubmit(im);
                m_dnaDataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return false;
            }

            return true;
        }
        public bool UpdateItemMaster(ItemMaster im)
        {
            try
            {
                var lItemMaster = (from i in m_dnaDataContext.ItemMasters 
                                   where i.Item_Model_Number == im.Item_Model_Number
                                   select i).FirstOrDefault();
                if (lItemMaster != null)
                {
                    lItemMaster.Description = im.Description;
                    lItemMaster.UPC_Code = im.UPC_Code;
                    lItemMaster.Label_Name = im.Label_Name;
                    lItemMaster.Engine_Serial_No__Identifier = im.Engine_Serial_No__Identifier;
                    m_dnaDataContext.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return false;
            }
        }
        public bool DeleteItemMaster(ItemMaster im)
        {
            try
            {
                var lItemMaster = (from i in m_dnaDataContext.ItemMasters
                                   where i.Item_Model_Number == im.Item_Model_Number
                                   select i).FirstOrDefault();
                if (lItemMaster != null)
                {
                    m_dnaDataContext.ItemMasters.DeleteOnSubmit(lItemMaster);
                    m_dnaDataContext.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return false;

            }
        }
       
        //Transactions
        public bool SerialNoExist(string SerialNo)
        {
            try
            {
                var lSerialNo = (from i in m_dnaDataContext.Serial_No__Trackers
                                 where i.Serial_No_ == SerialNo
                                 select i).FirstOrDefault();
                if (lSerialNo != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return false;
            }
        }
     
        public bool InsertSerialInfo(Serial_No__Tracker snt)
        {
            ErrorMessage = "";
            try
            {
                m_dnaDataContext.Serial_No__Trackers.InsertOnSubmit(snt);
                m_dnaDataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return false;
            }
        }
        public List<Serial_No__Tracker> LoadSerialTracker()
        {
            try
            {
                var query = from i in m_dnaDataContext.Serial_No__Trackers
                            select i;
                if (query.Count() > 0)
                    return query.ToList();
                else
                {
                    ErrorMessage = "No data.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("Source={0}, Message={1}.", ex.Source, ex.Message);
                return null;
            }
        }

    }
}
