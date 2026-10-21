using System;
using System.Collections.Generic;
using Ichamn.Helpers;

namespace Ichamn.Models
{
    public class Warehouse<TW> : IWarehouse<TW>  where TW : IJobable
    {
        private readonly Dictionary<Guid, IAitem<TW>> m_aitems;
        public Warehouse()
        {
            m_aitems = new Dictionary<Guid, IAitem<TW>>();
        }

        public void AddSession(Guid p_sessionId)
        {
            try
            {
                if (!m_aitems.ContainsKey(p_sessionId))
                {
                    m_aitems.Add(p_sessionId,new Aitem<TW>());
                }
            }
            catch (Exception ex)
            {
                var lh = new LoggerHelper();
                lh.LogError("Office.Add: " + ex.Message + ex.StackTrace);
            }
        }

        public void DeleteSession(Guid p_sessionId)
        {
            m_aitems.Remove(p_sessionId);
        }

        public void CleanSession(Guid p_sessionId)
        {
            if (m_aitems.ContainsKey(p_sessionId))
            {
                m_aitems[p_sessionId].Clean();
            }
        }

        public void AddAitem(Guid p_sessionId, List<TW> p_list, Guid p_officeId)
        {
            if (!m_aitems.ContainsKey(p_sessionId))
            {
                AddSession(p_sessionId);
            }
            m_aitems[p_sessionId].AddItemList(p_list,p_officeId);
        }

        public string GetAitems(Guid p_sessionId)
        {
            try
            
            {
                if (m_aitems.ContainsKey(p_sessionId))
                {
                    return m_aitems[p_sessionId].GetFinishedJobs();
                }
                AddSession(p_sessionId);
                return string.Empty;
            }
            catch (Exception ex)
            {
                var lh = new LoggerHelper();
                lh.LogError("GetAitems("+p_sessionId+") :" + ex.Message + ex.StackTrace);
                return string.Empty;
            }
        }
    }

    public interface IWarehouse<T>
    {
        void AddAitem(Guid p_sessionId, List<T> p_list, Guid p_officeId);
        string GetAitems(Guid p_sessionId);
        void AddSession(Guid p_sessionId);
        void DeleteSession(Guid p_sessionId);
        void CleanSession(Guid p_sessionId);
    }
}