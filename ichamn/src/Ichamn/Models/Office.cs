using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ichamn.Helpers;

namespace Ichamn.Models
{
    public class Office<T> : IOffice<T> where T : ICloneable, IJobable
    {
        private readonly Guid m_mId;
        private readonly object m_mMyLock;
        private readonly IList<T> m_packects;
        private readonly Dictionary<Guid, Subscriptor> m_subscriptors;
        protected readonly IWarehouse<IJobable> Warehouse;
        private int m_secuenceNumber;
        private Task m_transportMan;

        public Guid Id
        {
            get { return m_mId; }
        }

        protected Office(Guid p_mId, IWarehouse<IJobable> p_warehouse)
        {
            m_mId = p_mId;
            Warehouse = p_warehouse;
            m_mMyLock = new object();
            m_secuenceNumber = 0;
            m_packects = new List<T>();
            m_subscriptors = new Dictionary<Guid, Subscriptor>();
        }

        public void Add(T p_packet)
        {
            try
            {
                lock (m_mMyLock)
                {
                    p_packet.Secuence = m_secuenceNumber;
                    m_secuenceNumber++;
                    m_packects.Add(p_packet);
                    AfterAdd(p_packet);
                }
                m_transportMan = new Task(SendPacketsToWarehouse);
                m_transportMan.Start();
            }
            catch (Exception ex)
            {
                var lh = new LoggerHelper();
                lh.LogError("Office.Add: " + ex.Message + ex.StackTrace);
            }
        }

        protected virtual void AfterAdd(T p_packet)
        {
        }

        public void AddSubscriptor(Subscriptor p_subscriptor)
        {
            try
            {
                lock (m_mMyLock)
                {
                    if (m_subscriptors.ContainsKey(p_subscriptor.SessionId))
                    {
                        m_subscriptors[p_subscriptor.SessionId].Secuence = p_subscriptor.Secuence;
                    }
                    else
                    {
                        m_subscriptors.Add(p_subscriptor.SessionId, p_subscriptor);
                    }
                }
                SendPacketToWarehoseAfterSubscription(p_subscriptor);
            }
            catch(Exception ex)
            {
                var lh = new LoggerHelper();
                lh.LogError("AddSubscription: " + ex.Message + ex.StackTrace);
            }

        }

        public void RemoveSubscriptor(Guid p_subscriptorId)
        {
            lock (m_mMyLock)
            {
                m_subscriptors.Remove(p_subscriptorId);
            }
        }

        private void SendPacketsToWarehouse()
        {
            IList<IJobable> myClonePackets;
            int myCloneSecuence;
            lock (m_mMyLock)
            {
                myClonePackets = m_packects.Select(p_item => (IJobable)p_item.Clone()).ToList();
                myCloneSecuence = m_secuenceNumber;
            }

            foreach (var mSubscriptor in m_subscriptors)
            {
                SendPacketsToWarehouseBySubscriptor(myClonePackets, myCloneSecuence, mSubscriptor.Value);
            }
        }

        private void SendPacketToWarehoseAfterSubscription(Subscriptor p_subscriptor)
        {
            IList<IJobable> myClonePackets;
            int myCloneSecuence;
            lock (m_mMyLock)
            {
                myClonePackets = m_packects.Select(p_item => (IJobable)p_item.Clone()).ToList();
                myCloneSecuence = m_secuenceNumber;
            }

            SendPacketsToWarehouseBySubscriptor(myClonePackets, myCloneSecuence, p_subscriptor);
        }

        private void SendPacketsToWarehouseBySubscriptor(IEnumerable<IJobable> p_myClonePackets, int p_myCloneSecuence,Subscriptor p_mSubscriptor)
        {
            try
            {
                lock (p_mSubscriptor)
                {
                    var subSecuence = p_mSubscriptor.Secuence;
                    if (subSecuence < p_myCloneSecuence)
                    {
                        var list = p_myClonePackets.Where(p_x => p_x.Secuence >= subSecuence).ToList();
                        if (list.Count == 0)
                        {
                            Debugger.Break();
                        }
                        SendListToWarehouse(p_mSubscriptor.SessionId,
                                            list, m_mId);
                        p_mSubscriptor.Secuence = p_myCloneSecuence;
                    }
                }
            }catch(Exception ex)
            {
                var lh = new LoggerHelper();
                lh.LogError("SendPacketsToWarehouseBySubscriptor: " + ex.Message + ex.StackTrace);
            }
        }

        private void SendListToWarehouse(Guid p_key, List<IJobable> p_toList, Guid p_officeId)
        {
            Warehouse.AddAitem(p_key, p_toList, p_officeId);
        }
    }

    public class Subscriptor
    {
        private readonly Guid m_sessionId;

        public Subscriptor(Guid p_sessionId, int p_secuence)
        {
            m_sessionId = p_sessionId;
            Secuence = p_secuence;
        }

        public int Secuence { get; set; }

        public Guid SessionId
        {
            get { return m_sessionId; }
        }
    }

    public interface IOffice<T>
    {
    }
}