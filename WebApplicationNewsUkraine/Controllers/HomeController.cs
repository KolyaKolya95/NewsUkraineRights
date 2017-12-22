using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebApplicationNewsUkraine.Models;
using System.Diagnostics;
using System.Globalization;

namespace WebApplicationNewsUkraine.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            String URLString = "http://www.pravda.com.ua/rss/view_news/";

            XmlDocument doc = new XmlDocument();
            doc.Load(URLString);

            List<PravdaModel> pravda = new List<PravdaModel>();

            XmlNodeList xnList = doc.SelectNodes("/rss/channel/item");

            Debug.WriteLine(xnList);
            foreach (XmlNode node in xnList)
            {
                Debug.WriteLine(node["pubDate"].InnerText);
            }
            

            foreach (XmlNode node in xnList)
            {
                pravda.Add(new PravdaModel
                {
                    Title = node["title"].InnerText,
                    Link = node["link"].InnerText,
                    Category = node["category"].InnerText,
                    Date  = DateTime.Parse(node["pubDate"].InnerText),
                    Description = node["description"].InnerText,
                    Guid = node["guid"].InnerText
                }
                );
            }

            return View(pravda);
        }

        public ActionResult SortIndex()
        {
            String URLString = "http://www.pravda.com.ua/rss/view_news/";

            XmlDocument doc = new XmlDocument();
            doc.Load(URLString);

            List<PravdaModel> pravda = new List<PravdaModel>();

            XmlNodeList xnList = doc.SelectNodes("/rss/channel/item");

            Debug.WriteLine(xnList);

            foreach (XmlNode node in xnList)
            {
                pravda.Add(new PravdaModel
                {
                    Title = node["title"].InnerText,
                    Link = node["link"].InnerText,
                    Category = node["category"].InnerText,
                    Date = DateTime.Parse(node["pubDate"].InnerText),
                    Description = node["description"].InnerText,
                    Guid = node["guid"].InnerText
                }
                );
            }

            
            pravda.Sort(delegate(PravdaModel p1, PravdaModel p2)
                       {
                         return p1.Title.CompareTo(p2.Title);
                       });

            return View(pravda);
        }

        public ActionResult SortDataIndex()
        {
            String URLString = "http://www.pravda.com.ua/rss/view_news/";

            XmlDocument doc = new XmlDocument();
            doc.Load(URLString);

            List<PravdaModel> pravda = new List<PravdaModel>();

            XmlNodeList xnList = doc.SelectNodes("/rss/channel/item");

            Debug.WriteLine(xnList);

            foreach (XmlNode node in xnList)
            {
                pravda.Add(new PravdaModel
                {
                    Title = node["title"].InnerText,
                    Link = node["link"].InnerText,
                    Category = node["category"].InnerText,
                    Date = DateTime.Parse(node["pubDate"].InnerText),
                    Description = node["description"].InnerText,
                    Guid = node["guid"].InnerText
                }
                );
            }

            pravda.Sort(delegate (PravdaModel p1, PravdaModel p2)
            {
                return p1.Date.CompareTo(p2.Date);
            });

            return View(pravda);
        }
    }
}