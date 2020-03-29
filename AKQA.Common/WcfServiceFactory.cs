using System;
using System.Net.Security;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;

namespace AKQA.Common
{
    public class WcfServiceFactory<T> : IServiceFactory<T>
    {
        private string endpointName;
        private string username;
        private string password;
        private Lazy<ChannelFactory<T>> factory;

        /// <summary>
        /// 
        /// </summary>
        public WcfServiceFactory(string endpointName)
        {
            this.endpointName = endpointName;
            this.username = "";
            this.password = "";
            this.factory = new Lazy<ChannelFactory<T>>(CreateFactory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ChannelFactory<T> CreateFactory()
        {
            ChannelFactory<T> factory = new ChannelFactory<T>(endpointName);
            factory.Credentials.UserName.UserName = username;
            factory.Credentials.UserName.Password = password;
            System.Net.ServicePointManager.ServerCertificateValidationCallback += CustomXertificateValidation;
            return factory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslpolicyerrors"></param>
        /// <returns></returns>
        private static bool CustomXertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T CreateInstance()
        {
            return factory.Value.CreateChannel();
        }
    }
}
