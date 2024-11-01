using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using Terminal.Gui;
using Scraper;
using Sandbox;

public partial class Program
{
  public static void Main()
  {
    Sandbox.Sandbox.Start();
  }


  private static void Run()
  {
    Application.Init();
    var window = new StockWindow();
    Application.Run(window);
    Application.Shutdown();
  }


}