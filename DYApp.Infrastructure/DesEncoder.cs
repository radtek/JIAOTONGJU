using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Infrastructure
{
    public class DesEncoder
    {
        private static string PublicKey = "<RSAKeyValue><Modulus>sS7OM6KA91omEsw8BpHtyB67am4susGFrjwaXCo4S9XBkp7TBr7a86xxAVHdgT3isGn+8vt7Y12wZfSKIRNV5NX5V5cfux6xNw7DVLqSlxQa7DJz4irWU6VdihoAn8dedLo4eK2o3lW74BVpYrjl33IMmePhz8V7rF+DB97/GVs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private static string PrivateKey = "<RSAKeyValue><Modulus>sS7OM6KA91omEsw8BpHtyB67am4susGFrjwaXCo4S9XBkp7TBr7a86xxAVHdgT3isGn+8vt7Y12wZfSKIRNV5NX5V5cfux6xNw7DVLqSlxQa7DJz4irWU6VdihoAn8dedLo4eK2o3lW74BVpYrjl33IMmePhz8V7rF+DB97/GVs=</Modulus><Exponent>AQAB</Exponent><P>0fdGtCp/yF6UT+rxbXYwTZIh0fXk7Us0eKLgCwykirvpkE6UxxZTPgjJSPFfiZEbMJdTW8zZ1Z+M2IerSdZv5w==</P><Q>2AeEomJ+a2oHqixepMpJFlrsM3gRNAfEqGusGE6/ZY3wG6HolCwd0wFVugQeIsbh1UVtzz748Q60A59vjSRsbQ==</Q><DP>UXWQFsIORVx8Se0qsX8TCmVRfbXalT2CI/N83IyRIcn5uaTjD8JXlU+vV/9dQ2/qjpWHH6yALuLxr+giykjJrQ==</DP><DQ>nXh9elEJjgrwI1/MbZr2w9DrNGllQOQYuhwiimV8pu5cBAh1nOy7oL/sWXf+76LBo9DERrnEhRMOrUVe7yeJ0Q==</DQ><InverseQ>d5LpwsVaFfwcb7+L4+XU0aX1qbG6E4riEeqMm9SCy6gdUas93pVMi93y6P7nZthxMe0NgEeKYwfMiG9MExN/XA==</InverseQ><D>ICJrB3ZbiYDyEsqzwEVLKNZaC018E0rx4c3IwhpuJ2LXPq5Le5e1wifuPt0IHV6J9JDkylDN6hGd4n/dZW5KT280e6didZztHuM654VXj0baqsbjohF/nzUL1oebJCU3+X83kt848GxbCLc+CbajLQOOEfJD7SSRQQSL8YtYqXE=</D></RSAKeyValue>";
        public static string Encrypt(string str)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(PublicKey);
            byte[] buf = Encoding.UTF8.GetBytes(str);
            int keySize = rsa.KeySize / 8;
            int bufferSize = keySize - 11;
            byte[] buffer = new byte[bufferSize];
            MemoryStream msInput = new MemoryStream(buf);
            MemoryStream msOutput = new MemoryStream();

            int readLen = msInput.Read(buffer, 0, bufferSize);
            while (readLen > 0)
            {
                byte[] dataToEnc = new byte[readLen];
                Array.Copy(buffer, 0, dataToEnc, 0, readLen);
                byte[] encData = rsa.Encrypt(dataToEnc, false);
                msOutput.Write(encData, 0, encData.Length);
                readLen = msInput.Read(buffer, 0, bufferSize);
            }
            msInput.Close();

            byte[] encryptArray = msOutput.ToArray();
            msOutput.Close();
            return Convert.ToBase64String(encryptArray);
        }
        public static string Decrypt(string str)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(PrivateKey);
            byte[] buf = Convert.FromBase64String(str);
            int keySize = rsa.KeySize / 8;
            byte[] buffer = new byte[keySize];
            MemoryStream msInput = new MemoryStream(buf);
            MemoryStream msOutput = new MemoryStream();
            int readLen = msInput.Read(buffer, 0, keySize);
            while (readLen > 0)
            {
                byte[] dataToDec = new byte[readLen];
                Array.Copy(buffer, 0, dataToDec, 0, readLen);
                byte[] decData = rsa.Decrypt(dataToDec, false);
                msOutput.Write(decData, 0, decData.Length);
                readLen = msInput.Read(buffer, 0, keySize);
            }
            msInput.Close();
            byte[] decryteArray = msOutput.ToArray();
            return Encoding.UTF8.GetString(decryteArray);
        }
    }
}
