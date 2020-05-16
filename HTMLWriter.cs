using System;
using System.IO;
using System.Xml;

namespace HTMLWriterPackage
{
    public class HTMLWriter : ElementBuilder
    {
        //Properties
        private XmlWriter Body { get; set; }

        private XmlWriter Head { get; set; }

        //Constructor
        public HTMLWriter()
        {
            
            System.IO.Directory.CreateDirectory(@"D:/HTMLWriter/XML");
            Head = XmlWriter.Create(@"D:/HTMLWriter/XML/HTMLHeadConfig.xml", xmlSettings);
            Head.WriteStartDocument();
            Head.WriteStartElement("head");

            
            Body = XmlWriter.Create(@"D:/HTMLWriter/XML/HTMLBodyConfig.xml", xmlSettings);
            Body.WriteStartDocument();
            Body.WriteStartElement("body");
        }

        //Destructor
        ~HTMLWriter()
        {
            Directory.Delete(@"D:/HTMLWriter/XML");
        }
        
        //Methods
        public string GetHTMLString()
        {
            while (true)
            {
                try
                {
                    using (XmlReader xmlHead = XmlReader.Create(@"D:/HTMLWriter/XML/HTMLHeadConfig.xml", xmlReadSettings))
                    using (XmlReader xmlBody = XmlReader.Create(@"D:/HTMLWriter/XML/HTMLBodyConfig.xml", xmlReadSettings))
                    using (var html = XmlWriter.Create(@"D:/HTMLWriter/XML/HTMLStringConfig.xml", xmlSettings))
                    {
                        html.WriteStartDocument();
                        html.WriteStartElement("html");
                        html.WriteNode(xmlHead, false);
                        html.WriteNode(xmlBody, false);
                        html.WriteEndElement();
                        html.WriteEndDocument();
                        html.Flush();
                        html.Close();
                    }
                    break;
                }
                catch (System.IO.IOException)
                {
                    Head.Close();
                    Body.Close();
                    continue;
                }
            }
            return System.IO.File.ReadAllText(@"D:/HTMLWriter/XML/HTMLStringConfig.xml");
        }

        public void SaveAsHTML(string filepath)
        {
            while (true)
            {
                try
                {
                    using (XmlReader xmlHead = XmlReader.Create(@"D:/HTMLWriter/XML/HTMLHeadConfig.xml", xmlReadSettings))
                    using (XmlReader xmlBody = XmlReader.Create(@"D:/HTMLWriter/XML/HTMLBodyConfig.xml", xmlReadSettings))
                    using (var html = XmlWriter.Create(@"D:/HTMLWriter/XML/HTMLTemplateConfig.xml", xmlSettings))
                    {
                        html.WriteStartDocument();
                        html.WriteStartElement("html");
                        html.WriteNode(xmlHead, false);
                        html.WriteNode(xmlBody, false);
                        html.WriteEndElement();
                        html.WriteEndDocument();
                        html.Flush();
                        html.Close();
                        var htmlRead = XmlReader.Create(@"D:/HTMLWriter/XML/HTMLTemplateConfig.xml", xmlReadSettings);
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(XmlToString(htmlRead));
                        xmlDoc.Save(filepath);
                    }
                    break;
                }
                catch (System.IO.IOException)
                {

                    Head.Close();
                    Body.Close();
                    continue;

                }
            }
               
        }

        public void AssignCSS(string cssPath)
        {
            Head.WriteStartElement("link");
            Head.WriteAttributeString("rel", "stylesheet");
            Head.WriteAttributeString("type", "text/css");
            Head.WriteAttributeString("href", cssPath);
            Head.WriteEndElement();
        }

        //Tag specific methods
        public void AddLineBreak()
        {
            Body.WriteStartElement("br");
            Body.WriteEndElement();
        }
        public void AddParagraph(string content)
        {
            AddElement(Body, "p", content);
        }

        public void AddParagraph(string content, HTMLAttribute[] attributes)
        {
            AddElement(Body, "p", content, attributes);
        }

        public void AddHeading(int rank, string content)
        {
            AddElement(Body, "h" + Convert.ToString(rank), content);
        }

        public void AddHeading(int rank, string content, HTMLAttribute[] attributes)
        {
            AddElement(Body, "h" + Convert.ToString(rank), content, attributes);
        }

        public void AddDivision(string content)
        {
            AddElement(Body, "div", content);
        }

        public void AddDivision(string content, HTMLAttribute[] attributes)
        {
            AddElement(Body, "div", content, attributes);
        }

        public void AddSpan(string content)
        {
            AddElement(Body, "span", content);
        }

        public void AddSpan(string content, HTMLAttribute[] attributes)
        {
            AddElement(Body, "span", content, attributes);
        }
        public void AddBold(string content)
        {
            AddElement(Body, "b", content);
        }

        public void AddBold(string content, HTMLAttribute[] attributes)
        {
            AddElement(Body, "b", content, attributes);
        }

        public void AddItalic(string content)
        {
            AddElement(Body, "i", content);
        }

        public void AddItalic(string content, HTMLAttribute[] attributes)
        {
            AddElement(Body, "i", content, attributes);
        }

        public void AddUnderline(string content)
        {
            AddElement(Body, "u", content);
        }

        public void AddUnderline(string content, HTMLAttribute[] attributes)
        {
            AddElement(Body, "u", content, attributes);
        }

        public void AddTitle(string content)
        {
            AddElement(Head, "title", content);
        }

        public void AddCustomElement(XmlWriter xmlBody, string elementName, string content)
        {
            AddElement(xmlBody, elementName, content);
        }

        public void AddCustomElement(XmlWriter xmlBody, string elementName, string content, HTMLAttribute[] attributes)
        {
            AddElement(xmlBody, elementName, content, attributes);
        }

        public void AddList(ListElement listBody)
        {
            Body.WriteRaw(listBody.ToString());
        }

        public void AddTable(TableElement tableBody)
        {
            Body.WriteRaw(tableBody.ToString());
        }
    }
}
