using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;

public class Program
{
  public static void Main()
  {

    var data = Scraper.Init();
    Console.WriteLine(data);
  }

}

