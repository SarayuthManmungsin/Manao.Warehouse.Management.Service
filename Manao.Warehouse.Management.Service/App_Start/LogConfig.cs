using System.Configuration;
using System.Web;
using System.Xml;

namespace Manao.Warehouse.Management.Service
{
    public static class LogConfig
    {
        public static void Configure(HttpServerUtility server)
        {
            // in order to working as an alias site which is already using log4net as the log operation
            // aslias's log4net need to create a new sectiondynamically depends on named 'odataLog4net'(see. web.config)
            XmlElement element = (XmlElement)ConfigurationManager.GetSection("odataLog4net");
            XmlElement odataLog4net = element.OwnerDocument.CreateElement("log4net");

            // append to a new settings
            for (int i = 0; i < element.ChildNodes.Count; i++)
            {
                XmlNode child = element.ChildNodes[i];
                odataLog4net.AppendChild(child.CloneNode(true));
            }

            // use as configure
            log4net.Config.XmlConfigurator.Configure(odataLog4net);
        }
    }
}