using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
namespace DER.WebApp.Domain.Business
{
    public class TemplateBLL
    {
        private DerContext _context;
        private TemplateDAO templateDAO;

        public TemplateBLL()
        {
            _context = new DerContext();
            templateDAO = new TemplateDAO(_context);
        }

        public List<Template> GetListTemplates()
        {
            return templateDAO.GetListTemplates();
        }

        public bool SaveTemplate(Template template)
        {
            return templateDAO.SaveTemplate(template);
        }

        public bool UpdateTemplate(Template template)
        {
            return templateDAO.UpdateTemplate(template);
        }

        internal bool DeleteTemplate(int id)
        {
            return templateDAO.DeleteTemplate(id);
        }
    }
}