using System;
using System.Collections.Generic;

namespace Ichamn.Models
{
    public class OForum : Office<OTopicLight>
    {
        private static OForum m_instance ;
        public static OForum GetInstance()
        {
            return m_instance ?? (m_instance = new OForum(new Guid(), new Warehouse<IJobable>(), "General"));
        }

        public static IWarehouse<IJobable> GetWarehouseInstance()
        {
            return GetInstance().Warehouse;
        }

        private readonly string m_title;

        public OForum(Guid p_mId, IWarehouse<IJobable> p_warehouse, string p_title) : base(p_mId, p_warehouse)
        {
            m_title = p_title;
        }

        public string Title
        {
            get { return m_title; }
        }

        protected override void AfterAdd(OTopicLight p_packet)
        {
            base.AfterAdd(p_packet);
            ForumIndex.Add(new OTopic(p_packet.Id, Warehouse, p_packet.Author, p_packet.Title));
        }
    }

    public class ForumIndex
    {
        private static Dictionary<Guid, OTopic> m_topics;

        public static Dictionary<Guid, OTopic> Topics
        {
            get { return m_topics ?? (m_topics = new Dictionary<Guid, OTopic>()); }
        }

        public static void Add(OTopic p_oTopic)
        {
            Topics.Add(p_oTopic.Id, p_oTopic);
        }

        public static OTopic GetTopic(Guid p_officeId)
        {
            if (!Topics.ContainsKey(p_officeId))
            {
                return null;
            }
            return Topics[p_officeId];
        }

        public static void Delete(Guid p_officeId)
        {
            /* Cuando se cree este metodo controlar concurrencia con GetTopic intentando afectar lo minimo al rendimiento
             como un semaforo, cuando alguien borra nadie usa el GetTopic*/
        }

        public static void DeleteSubscriptor(Guid p_sessionId)
        {
            foreach (var oTopic in Topics.Values)
            {
                oTopic.RemoveSubscriptor(p_sessionId);
            }
        }
    }
}