using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using Terminal.Gui;
using Scraper;
public partial class Program
{
  public static void Main()
  {
    Sandbox();
  }


  private static void Run()
  {
    Application.Init();
    var window = new StockWindow();
    Application.Run(window);
    Application.Shutdown();
  }


  private static void Sandbox()
  {
    Application.Init();
    var top = Application.Top;
    var window = new Window("NZX Stock Sandbox")
    {
      X = 0,
      Y = 0,
      Width = Dim.Fill(),
      Height = Dim.Fill()
    };


    var quitButton = new Button("Quit")
    {
      X = Pos.Center(),
      Y = Pos.Center() + 1
    };

    var tickerField = new TextField
    {
      X = 1,
      Y = 1,
      Width = 20,
      Height = 1
    };
    tickerField.Text = "Ticker Symbol";

    var getTickerButton = new Button("Get Ticker")
    {
      X = 1,
      Y = 3,
      ColorScheme = new ColorScheme
      {
        Normal = Application.Driver.MakeAttribute(Color.Red, Color.Black),
        Focus = Application.Driver.MakeAttribute(Color.Red, Color.Black),
        HotNormal = Application.Driver.MakeAttribute(Color.Red, Color.Black),
        HotFocus = Application.Driver.MakeAttribute(Color.Red, Color.Black)
      }
    };

    getTickerButton.Clicked += () =>
    {
      var ticker = tickerField.Text;
      Console.WriteLine($"Ticker: {ticker}");
    };

    // quite button
    quitButton.Clicked += () => Application.RequestStop();

    window.Add(quitButton);
    window.Add(tickerField);
    window.Add(getTickerButton);
    top.Add(window);
    Application.Run();
    Application.Shutdown();
  }

}