using System;

namespace Ichamn.Models
{
    public class OTopicLight: IJobable, ICloneable
    {
        private readonly Guid m_forumId;
        private Guid m_topicId;
        private int m_secuence;
        private readonly string m_title;
        private readonly string m_author;
        private readonly DateTime m_createDate;

        public OTopicLight(Guid p_forumId, Guid p_topicId, int p_secuence, string p_title, string p_author,DateTime p_cdate)
        {
            m_forumId = p_forumId;
            m_topicId = p_topicId;
            m_secuence = p_secuence;
            m_title = p_title;
            m_author = p_author;
            m_createDate = p_cdate;
        }

        public OTopicLight(Guid p_forumId, Guid p_topicId, string p_title, string p_author)
        {
            m_forumId = p_forumId;
            m_topicId = p_topicId;
            m_secuence = 0;
            m_title = p_title;
            m_author = p_author;
            m_createDate = DateTime.UtcNow;
        }

        public string Title
        {
            get { return m_title; }
        }

        public string Author
        {
            get { return m_author; }
        }

        public string Cdate
        {
            get { return m_createDate.ToUniversalTime().ToString(); }
        }

        public int CompareTo(object p_obj)
        {
            var obj1 = (OTopicLight) p_obj;
            int result = Secuence.CompareTo(obj1.Secuence);
            if (result == 0)
            {
                if (OfficeId() == obj1.OfficeId())
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
            get { return m_topicId; }
            set { m_topicId = value; }
        }

        public string Type()
        {
            return "ot";
        }

        public Guid OfficeId()
        {
            return m_forumId;
        }

     /*   public string ToJson()
        {
            return string.Format("{{\"secuence\": {0}, \"title\": {1}, \"topicId\": \"{2}\",\"author\": {3} ,\"cdate\": {4}  }}", m_secuence, m_title, m_topicId, m_author, m_createDate);
        }*/

        public object Clone()
        {
            return new OTopicLight(m_forumId, m_topicId, m_secuence, m_title,m_author,m_createDate);
        }
    }
}