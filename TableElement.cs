using System;
using System.IO;
using System.Xml;


namespace HTMLWriterPackage
{
    public class TableElement : ElementBuilder
    {

        private static int tableCount = 0;
        private XmlWriter tableBody;

        public TableElement()
        {
            tableCount++;
            tableBody = XmlWriter.Create(@"D:/HTMLWriter/XML/TableConfig" + tableCount + ".xml", xmlSettings);
            tableBody.WriteStartDocument();
            tableBody.WriteStartElement("table");
        }

        public TableElement(HTMLAttribute[] attributes)
        {
            tableBody = XmlWriter.Create(@"D:/HTMLWriter/XML/TableConfig" + tableCount + ".xml", xmlSettings);
            tableBody.WriteStartDocument();
            tableBody.WriteStartElement("table");
            HTMLAttribute.AttributeWriter(tableBody, attributes);
        }

        public void DeclareTableHead()
        {
            tableBody.WriteStartElement("thead");
        }

        public void DeclareTableHead(HTMLAttribute[] attributes)
        {
            tableBody.WriteStartElement("thead");
            HTMLAttribute.AttributeWriter(tableBody, attributes);
        }

        public void DeclareTableBody()
        {
            tableBody.WriteStartElement("tbody");
        }

        public void DeclareTableBody(HTMLAttribute[] attributes)
        {
            tableBody.WriteStartElement("tbody");
            HTMLAttribute.AttributeWriter(tableBody, attributes);
        }

        public void DeclareTableFooter()
        {
            tableBody.WriteStartElement("tfoot");
        }

        public void DeclareTableFooter(HTMLAttribute[] attributes)
        {
            tableBody.WriteStartElement("tfoot");
            HTMLAttribute.AttributeWriter(tableBody, attributes);
        }

        public void DeclareTableRow()
        {
            tableBody.WriteStartElement("tr");
        }

        public void DeclareTableRow(HTMLAttribute[] attributes)
        {
            tableBody.WriteStartElement("tr");
            HTMLAttribute.AttributeWriter(tableBody, attributes);
        }

        public void DeclareTableHeadingCell(string content)
        {
            tableBody.WriteStartElement("th");
            tableBody.WriteString(content);
        }

        public void DeclareTableHeadingCell(string content, HTMLAttribute[] attributes)
        {
            tableBody.WriteStartElement("th");
            tableBody.WriteString(content);
            HTMLAttribute.AttributeWriter(tableBody, attributes);
        }

        public void DeclareTableBodyCell(string content)
        {
            tableBody.WriteStartElement("td");
            tableBody.WriteString(content);
        }

        public void DeclareTableBodyCell(string content, HTMLAttribute[] attributes)
        {
            tableBody.WriteStartElement("td");
            tableBody.WriteString(content);
            HTMLAttribute.AttributeWriter(tableBody, attributes);
        }

        public void DeclareElementEnd()
        {
            tableBody.WriteEndElement();
        }

        public override string ToString()
        {
            tableBody.WriteEndElement();
            tableBody.WriteEndDocument();
            tableBody.Flush();
            tableBody.Close();

            var output = XmlReader.Create(@"D:/HTMLWriter/XML/TableConfig" + tableCount + ".xml", xmlReadSettings);
            return XmlToString(output);
        }
    }
}
