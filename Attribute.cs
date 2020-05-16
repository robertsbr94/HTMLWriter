using System.Xml;

namespace HTMLWriterPackage
{
    public class HTMLAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public HTMLAttribute(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public static void AttributeWriter(XmlWriter XMLBody, HTMLAttribute[] attributes)
        {
            foreach (var a in attributes)
            {
                XMLBody.WriteAttributeString(a.Name, a.Value);
            }
        }

    }
}
