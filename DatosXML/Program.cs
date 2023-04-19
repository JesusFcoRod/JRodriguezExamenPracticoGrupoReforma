using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DatosXML
{
    public class Program
    {
        static void Main(string[] args)
        {
            //obtener informacion del XMLBase
            XmlDocument XMLBase = new XmlDocument();
            XMLBase.Load("C:\\Users\\digis\\Desktop\\XML\\DatosXML.xml");

            XmlDocument XMLNew = new XmlDocument();//Nuevo documento XML

            //Colocar la declaracion inicial en este caso <?xml version="1.0" encoding="ISO-8859-1"?>
            XmlDeclaration xmlDeclaration = XMLNew.CreateXmlDeclaration("1.0", "ISO-8859-1", null);
            XMLNew.AppendChild(xmlDeclaration);
            XmlNode infoNone = XMLNew.CreateElement("info");
            XMLNew.AppendChild(infoNone);

            //seleccionamos noticias
            XmlNode noticiasNone = XMLBase.SelectSingleNode("/noticias");

            //obtener los datos mientras haya un registro o nodo noticia
            foreach (XmlNode noticiaNone in noticiasNone.ChildNodes)
            {
                XmlNode podcastNone = XMLNew.CreateElement("podcast");
                podcastNone.Attributes.Append(XMLNew.CreateAttribute("tipo")).Value = noticiaNone.Attributes["tipo"].Value;
                podcastNone.Attributes.Append(XMLNew.CreateAttribute("libre")).Value = noticiaNone.SelectSingleNode("libre").InnerText;
                podcastNone.Attributes.Append(XMLNew.CreateAttribute("id")).Value = noticiaNone.SelectSingleNode("id").InnerText;
                podcastNone.Attributes.Append(XMLNew.CreateAttribute("is3idfp")).Value = noticiaNone.SelectSingleNode("is3idfp").InnerText;
                podcastNone.Attributes.Append(XMLNew.CreateAttribute("idaudio")).Value = noticiaNone.SelectSingleNode("idaudio").InnerText;

              
                XmlNode categoriaNode = XMLNew.CreateElement("categoria");
                categoriaNode.InnerText = noticiaNone.SelectSingleNode("categoria").InnerText;
                podcastNone.AppendChild(categoriaNode);

                XmlNode tituloNode = XMLNew.CreateElement("titulo");
                tituloNode.InnerText = noticiaNone.SelectSingleNode("titulo").InnerText;
                podcastNone.AppendChild(tituloNode);

                XmlNode resumenNode = XMLNew.CreateElement("resumen");
                resumenNode.InnerText = noticiaNone.SelectSingleNode("resumen").InnerText;
                podcastNone.AppendChild(resumenNode);

                XmlNode prevurlNode = XMLNew.CreateElement("prevurl");
                prevurlNode.InnerText = noticiaNone.SelectSingleNode("prevurl").InnerText;
                podcastNone.AppendChild(prevurlNode);

                XmlNode urlNode = XMLNew.CreateElement("url");
                urlNode.InnerText = noticiaNone.SelectSingleNode("url").InnerText;
                podcastNone.AppendChild(urlNode);

                //Agregamos los campos al nuevo xml
                infoNone.AppendChild(podcastNone);
            }
            //Se muestra en consola el documento nuevo
            Console.WriteLine(XMLNew.OuterXml);
            XMLNew.Save("C:\\Users\\digis\\Desktop\\XML\\NewDatosXML.xml");//guardar nuevo xml
            Console.ReadKey();

            
            


        }
    }
}
