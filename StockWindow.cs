
using System;
using Terminal.Gui;
using Scraper;
using System.IO;
using System.Collections.Generic;


public class StockWindow : Window
{
  public StockWindow()
  {
    Title = $"NZX Stock Sandbox ({Application.QuitKey} to quit)";

    var data = Scraper.Scraper.Init();

    var listView = new ListView
    {
      Width = Dim.Fill(),
      Height = Dim.Fill()
    };

    listView.SetSource(data.Select(item => $"{item.Ticker} - {item.Name} - {item.Price}").ToList());

    Add(listView);
  }
}