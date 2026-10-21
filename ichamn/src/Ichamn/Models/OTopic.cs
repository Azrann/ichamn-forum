using System;

namespace Ichamn.Models
{
    public class OTopic : Office<OMessage>
    {
        private readonly string m_autor;
        private readonly string m_title;

        public OTopic(Guid p_id, IWarehouse<IJobable> p_warehouse, string p_autor, string p_title)
            : base(p_id, p_warehouse)
        {
            m_autor = p_autor;
            m_title = p_title;
        }

        public string Title
        {
            get { return m_title; }
        }

        public string Autor
        {
            get { return m_autor; }
        }
    }
}