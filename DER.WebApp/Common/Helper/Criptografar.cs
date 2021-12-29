using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DER.WebApp.Common.Helper
{
    public static class Criptografar
    {

        public static string Encrypt(string texto, string key = "G4WedT")
        {
            try
            {
                if (string.IsNullOrEmpty(texto))
                    return null;
                else
                {
                    byte[] keyArray;
                    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(texto);


                    //System.Windows.Forms.MessageBox.Show(key);
                    //If hashing use get hashcode regards to your key
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                    //Always release the resources and flush data
                    // of the Cryptographic service provide. Best Practice
                    hashmd5.Clear();

                    var tdes = new TripleDESCryptoServiceProvider();

                    //set the secret key for the tripleDES algorithm
                    tdes.Key = keyArray;

                    //mode of operation. there are other 4 modes.
                    //We choose ECB(Electronic code Book)
                    tdes.Mode = CipherMode.ECB;

                    //padding mode(if any extra byte added)
                    tdes.Padding = PaddingMode.PKCS7;

                    var cTransform = tdes.CreateEncryptor();

                    //transform the specified region of bytes array to resultArray
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                    //Release resources held by TripleDes Encryptor
                    tdes.Clear();

                    //Return the encrypted data into unreadable string format
                    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                }
            }
            catch (System.Exception)
            {
                throw new System.Exception("Ocorreu um erro ao encriptografar. Entre em contato com o suporte.");
            }
        }

        public static string Decrypt(string texto, string key = "G4WedT")
        {
            try
            {
                if (string.IsNullOrEmpty(texto))
                    return null;
                else
                {
                    byte[] keyArray;

                    //get the byte code of the string
                    byte[] toEncryptArray = Convert.FromBase64String(texto);

                    //if hashing was used get the hash code with regards to your key
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                    //release any resource held by the MD5CryptoServiceProvider
                    hashmd5.Clear();

                    var tdes = new TripleDESCryptoServiceProvider();

                    //set the secret key for the tripleDES algorithm
                    tdes.Key = keyArray;

                    //mode of operation. there are other 4 modes. 
                    //We choose ECB(Electronic code Book)
                    tdes.Mode = CipherMode.ECB;

                    //padding mode(if any extra byte added)
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                    //Release resources held by TripleDes Encryptor                
                    tdes.Clear();

                    //return the Clear decrypted TEXT
                    return UTF8Encoding.UTF8.GetString(resultArray);
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Ocorreu um erro ao descriptografar. Entre em contato com o suporte.");
            }
        }
    }
}