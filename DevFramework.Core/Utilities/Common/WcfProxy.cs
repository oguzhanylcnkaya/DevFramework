using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Common
{
   public class WcfProxy<T>
    {
        //http://localhost:35259/{0}.svc
        //ServiceAddress'i mvc de web config'in içine ekliyoruz.
        //Burada yapmak istediğimiz işlem yukarıdaki adresi dinamik olarak değiştirmektir. Yani {0} yazan yere hangi service gelirse o sayfayı açmak istemekteyiz.
        public static T CreateChannel()
        {
            string baseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            string address = string.Format(baseAddress, typeof(T).Name.Substring(1));

            var binding = new BasicHttpBinding();

            var channel = new ChannelFactory<T>(binding, address);

            return channel.CreateChannel();
        }
    }
}
