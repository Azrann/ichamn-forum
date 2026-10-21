using System;
using System.Web.Mvc;

namespace Ichamn.Models
{
    public class OMessage : ICloneable, IJobable
    {
        private readonly Guid m_pOfficeId;
        private int m_secuence;
        public readonly string Username;
        public readonly string Message;
        private readonly DateTime m_createDate;
        private Guid m_messageId;

        public OMessage(Guid p_officeId, int p_secuence, string p_username, string p_message, DateTime p_cdate)
        {
            m_pOfficeId = p_officeId;
            m_secuence = p_secuence;
            Username = p_username;
            Message = p_message;
            m_createDate = p_cdate;
            m_messageId= new Guid();
        }

        public OMessage(Guid p_officeId, string p_username, string p_message)
        {
            m_pOfficeId = p_officeId;
            m_secuence = 0;
            Username = p_username;
            Message = p_message;
            m_createDate = DateTime.UtcNow;
            m_messageId = new Guid();
        }

        public object Clone()
        {
            return new OMessage(m_pOfficeId, m_secuence, Username, Message,m_createDate);
        }

        public int CompareTo(object p_obj)
        {
            var obj1 = (OMessage) p_obj;
            int result = m_secuence.CompareTo(obj1.Secuence);
            if (result == 0)
            {
                if (m_pOfficeId == obj1.OfficeId())
                {
                    return 0;
                }
                return 1;
            }
            return result;
        }


        public int Secuence
        {
            get { return m_secuence; }
            set { m_secuence = value; }
        }

        public Guid Id
        {
            get { return m_messageId; }
            set { m_messageId = value; }
        }

        public string Cdate
        {
            get { return m_createDate.ToUniversalTime().ToString(); }
        }

        public string Type()
        {
            return "om";
        }

        public Guid OfficeId()
        {
            return m_pOfficeId;
        }

    /*    public string ToJson()
        {
            return string.Format("{{\"secuence\": {0}, \"username\": {1}, \"message\": {2}, \"cdate\": {3}  }}", m_secuence, Username, Message,m_createDate);
        }*/
    }
}