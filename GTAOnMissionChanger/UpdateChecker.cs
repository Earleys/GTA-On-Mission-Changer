using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GTAOnMissionChanger
{
    public class UpdateChecker
    {

        //bool disabled = true;

        public static Update CheckUpdate()
        {
            Update update = new Update();

            string xmlUrl = "http://earleys.be/downloads/GTAOnMissionChanger/update.xml";
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(xmlUrl);
                reader.MoveToContent();
                string elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "appinfo"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            elementName = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                                switch (elementName)
                                {
                                    case "version":
                                        update.Version = new Version(reader.Value);
                                        break;
                                    case "url":
                                        update.Url = reader.Value;
                                        break;
                                    case "about":
                                        update.About = reader.Value;
                                        break;
                                    case "mandatoryversion":
                                        update.Mandatory = new Version(reader.Value);
                                        break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return update;

        }


    }
}
