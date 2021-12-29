using DER.WebApp.Business;
using DER.WebApp.DAL;
using DER.WebApp.Models;
using DER.WebApp.Models.Enum;
using System;
using System.IO;

namespace DER.WebApp.DAO
{
    public class ArquivoDAO : BaseDAO<Arquivo>
    {
        PermissaoBLL permissaoBLL;

        public ArquivoDAO(DerContext derContext) : base(derContext)
        {
            permissaoBLL = new PermissaoBLL();
        }

        //Salvar no Banco de Dados
        public void SalvarArquivo(Usuario usuario)
        {  
            db.SaveChanges();            
        }
    }
}