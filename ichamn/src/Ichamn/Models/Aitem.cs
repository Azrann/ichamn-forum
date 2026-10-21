using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using Ichamn.Helpers;

namespace Ichamn.Models
{
    public class Aitem<T> : IAitem<T> where T : IJobable
    {
        private const int NumMinSeconds = 0;
        /* Grouped by officeId*/ 
        private Dictionary<Guid,List<T>> m_ItemList;
        private readonly object m_myLock;
        private EventWaitHandle m_semaphore;
        private DateTime m_lastChanged;

        public Aitem()
        {
            m_ItemList = new Dictionary<Guid, List<T>>();
            m_myLock = new object();
            m_lastChanged = DateTime.Now;
        }

        /*EventWaitHandle myEvent  */
        public void AddItemList(List<T> p_list, Guid p_officeId)
        {
            try
            {
               lock (m_myLock)
                {
                    if (m_ItemList.ContainsKey(p_officeId))
                    {
                        if (m_ItemList[p_officeId] == null)
                        {
                            m_ItemList[p_officeId] = new List<T>();
                        }
                        m_ItemList[p_officeId].AddRange(p_list);
                    }
                    else
                    {
                         m_ItemList.Add(p_officeId, p_list);
                    }
                }
               if (m_semaphore != null)
               {
                   m_semaphore.Set();
               }
            }catch(Exception ex)
            {
                var lh = new LoggerHelper();
                lh.LogError("AddItemList(numItems:" + m_ItemList.Count + ") :" + ex.Message + ex.StackTrace);
            }
       }

        public string GetFinishedJobs()
        {
            try
            {
                string result;
                if (ProcessFinishedJobs(out result))
                {
                    return result;
                }

                m_semaphore = new ManualResetEvent(false);
                if (!m_semaphore.WaitOne(60000))
                {
                    return String.Empty;
                }

                var secondsSinceLastTime = (int) (DateTime.Now - m_lastChanged).TotalSeconds;
                if (secondsSinceLastTime < NumMinSeconds)
                {
                    Thread.Sleep((NumMinSeconds - secondsSinceLastTime)*1000);
                }

                if (ProcessFinishedJobs(out result))
                {
                    return result;
                }
                return string.Empty;
            }
            catch(Exception ex)
            {   
                var lh = new LoggerHelper();
                lh.LogError("GetFinishedJobs(numItems:" + m_ItemList.Count + ") :" + ex.Message + ex.StackTrace);
                return string.Empty;
            }
        }

        public void Clean()
        {
            m_ItemList.Clear();
            m_semaphore.Set();
        }

        private bool ProcessFinishedJobs(out string p_result)
        {
            p_result = string.Empty;
            lock (m_myLock)
            {
                var sb = new StringBuilder();
                if (m_ItemList.Count > 0)
                {
                    sb.Append("[");
                    int i = 0;
                    foreach (var typeList in m_ItemList)
                    {
                        if (i>0)
                        {
                            sb.Append(",");
                        }
                        sb.AppendFormat("{{\"officeId\": \"{0}\", \"type\": \"{1}\" ,\"value\":{2}}}", typeList.Key,typeList.Value[0].Type(), GetJson(typeList.Value));
                        i++;
                    }
                    sb.Append("]");
                    m_ItemList.Clear();
                    m_lastChanged = DateTime.Now;
                    p_result = sb.ToString();
                    return true;
                }
                return false;
            }
            
        }

        private string GetJson(List<T> p_list)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(p_list);
        }

    }

    public interface IAitem<T>
    {
        void AddItemList(List<T> p_list, Guid p_officeId);
        string GetFinishedJobs();
        void Clean();
    }

   
}