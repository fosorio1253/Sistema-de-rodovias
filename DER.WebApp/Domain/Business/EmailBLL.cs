using DER.WebApp.DAO;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class EmailBLL
    {
        private DerContext _context;
        private EmailDAO emailDAO;

        public EmailBLL()
        {
            _context = new DerContext();
            emailDAO = new EmailDAO(_context);
        }

        public List<Emails> GetListEmails()
        {
            return emailDAO.GetListEmails();
        }

        public Emails GetEmail(int id)
        {
            return emailDAO.GetEmail(id);
        }

        public bool SaveEmail(Emails email)
        {
            return emailDAO.SaveEmail(email);
        }

        public bool UpdateEmail(Emails email)
        {
            return emailDAO.UpdateEmail(email);
        }
    }
}