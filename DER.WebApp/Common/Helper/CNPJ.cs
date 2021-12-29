using System;
using System.Text.RegularExpressions;

namespace DER.WebApp.Common.Helper
{
    public static class CNPJ
    {
        public static bool Validar(string cnpj)
        {
            return RegexCNPJ(cnpj);
        }

        private static bool RegexCNPJ(String cnpj)
        {
            return (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)")) ? ValidaCNPJ(cnpj) : false;
        }

        private static bool ValidaCNPJ(string cnpj)
        {
            Int32[] digitos, soma, resultado;
            Int32 nrDig;
            String ftmt;
            Boolean[] cnpjOk;
            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace("-", "");

            if (string.IsNullOrEmpty(cnpj) || cnpj == "00000000000000" || cnpj == "11111111111111" || cnpj == "22222222222222" || cnpj == "33333333333333" || cnpj == "44444444444444" || cnpj == "55555555555555" || cnpj == "66666666666666" || cnpj == "77777777777777" || cnpj == "88888888888888" || cnpj == "99999999999999")
            {
                return false;
            }

            ftmt = "6543298765432";
            digitos = new Int32[14];
            soma = new Int32[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new Int32[2];
            resultado[0] = 0;
            resultado[1] = 0;
            cnpjOk = new Boolean[2];
            cnpjOk[0] = false;
            cnpjOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));

                    if (nrDig <= 11)
                    {
                        soma[0] += (digitos[nrDig] *
                        int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    }

                    if (nrDig <= 12)
                    {
                        soma[1] += (digitos[nrDig] *
                        int.Parse(ftmt.Substring(nrDig, 1)));
                    }
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        cnpjOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        cnpjOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }
                return (cnpjOk[0] && cnpjOk[1]);
            }
            catch
            {
                return false;
            }
        }
    }
}