using System;
using System.IO;
using System.Xml;

namespace HTMLWriterPackage
{
    public class ListElement : ElementBuilder
    {
        private static int listCount = 0;
        private XmlWriter listBody;

        public ListElement(bool isOrdered)
        {
            listCount++;
            listBody = XmlWriter.Create(@"D:/HTMLWriter/XML/ListConfig" + listCount + ".xml", xmlSettings);
            listBody.WriteStartDocument();
            if (isOrdered)
            {
                listBody.WriteStartElement("ol");
            }
            else
            {
                listBody.WriteStartElement("ul");
            }
            
        }

        public ListElement(bool isOrdered, HTMLAttribute[] attributes)
        {
            listBody = XmlWriter.Create(@"D:/HTMLWriter/XML/ListConfig" + listCount + ".xml", xmlSettings);
            listBody.WriteStartDocument();
            if (isOrdered)
            {
                listBody.WriteStartElement("ol");
            }
            else
            {
                listBody.WriteStartElement("ul");
            }
            HTMLAttribute.AttributeWriter(listBody, attributes);
        }

        public void AddListRow(string content)
        {
            listBody.WriteStartElement("li");
            listBody.WriteString(content);
            listBody.WriteEndElement();
        }

        public void AddListRow(string content, HTMLAttribute[] attributes)
        {
            listBody.WriteStartElement("li");
            HTMLAttribute.AttributeWriter(listBody, attributes);
            listBody.WriteString(content);
            listBody.WriteEndElement();
        }


        public override string ToString()
        {
            listBody.WriteEndElement();
            listBody.WriteEndDocument();
            listBody.Flush();
            listBody.Close();

            var output = XmlReader.Create(@"D:/HTMLWriter/XML/ListConfig" + listCount + ".xml", xmlReadSettings);
            return XmlToString(output);
        }
    }
}
