using System.IO;
using System.Text;
using System.Xml;

namespace HTMLWriterPackage
{

    public class ElementBuilder
    {
        //Properties
        protected XmlWriterSettings xmlSettings = new XmlWriterSettings() { Indent = true, 
                                                                            IndentChars = "\t",
                                                                            OmitXmlDeclaration = true };

        protected XmlReaderSettings xmlReadSettings = new XmlReaderSettings() {  ConformanceLevel = ConformanceLevel.Fragment, 
                                                                          IgnoreWhitespace = true,
                                                                          IgnoreComments = true};



        //Methods
        protected void AddElement(XmlWriter xmlBody, string element, string content)
        {
            xmlBody.WriteStartElement(element);
            xmlBody.WriteString(content);
            xmlBody.WriteEndElement();
        }

        protected void AddElement(XmlWriter xmlBody, string element, string content, HTMLAttribute[] attributes)
        {
            xmlBody.WriteStartElement(element);
            HTMLAttribute.AttributeWriter(xmlBody, attributes);
            xmlBody.WriteString(content);
            xmlBody.WriteEndElement();
        }
        protected void AddElement(XmlWriter xmlBody, string element, HTMLAttribute[] attributes)
        {
            xmlBody.WriteStartElement(element);
            HTMLAttribute.AttributeWriter(xmlBody, attributes);
            xmlBody.WriteEndElement();
        }

        protected static string XmlToString(XmlReader xmlBody)
        {
            var stringReader = new StringBuilder();
            while (xmlBody.Read())
            {
                stringReader.AppendLine(xmlBody.ReadOuterXml());
            }
            return stringReader.ToString();
        }
    }
}
