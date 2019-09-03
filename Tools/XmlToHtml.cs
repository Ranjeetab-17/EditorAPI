using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace EditorAPI.Tools
{
    public static class XmlToHtml
    {
        public static void ToHtml(this string dita, string saveTo, string outputpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(dita);
            doc.Save(saveTo);
            XslTransform myXslTransform;
            myXslTransform = new XslTransform();
            myXslTransform.Load("XSLTs/tool.xsl");
            myXslTransform.Transform(saveTo, outputpath);
        }

        public static void ToXml()
        {

        }
    }
}
