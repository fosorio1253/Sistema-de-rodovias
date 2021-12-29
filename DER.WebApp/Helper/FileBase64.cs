using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace DER.WebApp.Helper
{
    public class FileBase64
    {
        //convert string para base64
        static public string EncodeToBase64(string arquivo)
        {
            try
            {
                byte[] textoAsBytes = File.ReadAllBytes(arquivo);
                string resultado = System.Convert.ToBase64String(textoAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //converte de base64 para texto
        static public string DecodeFrom64(string dados)
        {
            try
            {
                byte[] dadosAsBytes = System.Convert.FromBase64String(dados);
                string resultado = System.Text.ASCIIEncoding.ASCII.GetString(dadosAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}