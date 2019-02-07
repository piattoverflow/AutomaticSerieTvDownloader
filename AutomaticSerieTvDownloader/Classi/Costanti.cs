using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticSerieTvDownloader
{
    public class Costanti
    {
        public static string baseUrl = /*"https://x1337x.se"*/ "https://katcr.co";
        public static string sortSearch = /*baseUrl + "/sort-search/"*/"https://katcr.co/katsearch/page/1/";
        public static string name = "//td[@class='coll-1 name']";
        public static string href = "//td[@class='coll-1 name']";
        public static string seeds = "//td[@class='coll-2 seeds']";
        public static string date = "//td[@class='coll-date']";
        public static string magnet = "//ul[@class='download-links-dontblock btn-wrap-list']//li//a";

    }
}
