using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using Terminal.Gui;

namespace Sandbox
{
  public class Sandbox
  {
    public static void Start()
    {
      Application.Init();
      var top = Application.Top;
      // var window = new Window("NZX Stock Sandbox")
      // {
      //   X = 0,
      //   Y = 0,
      //   Width = Dim.Fill(),
      //   Height = Dim.Fill(),
      // };


      // var quitButton = new Button("Quit")
      // {
      //   X = Pos.Center(),
      //   Y = Pos.Center() + 1
      // };

      var tickerField = new TextField
      {
        X = 1,
        Y = 1,
        Width = 20,
        Height = 1
      };
      tickerField.Text = "Ticker Symbol";

      // var getTickerButton = new Button("Get Ticker")
      // {
      //   X = 1,
      //   Y = 3,
      //   ColorScheme = new ColorScheme
      //   {
      //     Normal = Application.Driver.MakeAttribute(Color.Red, Color.Black),
      //     Focus = Application.Driver.MakeAttribute(Color.Red, Color.Black),
      //     HotNormal = Application.Driver.MakeAttribute(Color.Red, Color.Black),
      //     HotFocus = Application.Driver.MakeAttribute(Color.Red, Color.Black)
      //   }
      // };

      // getTickerButton.Clicked += () =>
      // {
      //   var ticker = tickerField.Text;
      //   Console.WriteLine($"Ticker: {ticker}");
      // };

      // quite button
      // quitButton.Clicked += () => Application.RequestStop();

      // window.Add(quitButton);
      // window.Add(tickerField);
      // window.Add(getTickerButton);

      var window1 = new Window("NZX Stock Sandbox 1")
      {
        X = 0,
        Y = 0,
        Width = Dim.Percent(50),
        Height = Dim.Fill(),
      };

      var window2 = new Window()
      {
        X = Pos.Percent(50),
        Y = 0,
        Width = Dim.Percent(50),
        Height = Dim.Fill(),
        CanFocus = true,
        ColorScheme = new ColorScheme
        {
          Normal = Application.Driver.MakeAttribute(Color.Red, Color.Black),
          Focus = Application.Driver.MakeAttribute(Color.Red, Color.Black),
          HotNormal = Application.Driver.MakeAttribute(Color.Red, Color.Black),
          HotFocus = Application.Driver.MakeAttribute(Color.Red, Color.Black)
        },
        Title = "NZX Stock Sandbox 2"
      };

      // add a button to windows 2  which when i clicked open a new message box
      Button btn = new Button("Open Message Box")
      {
        X = 1,
        Y = 1,
      };

      btn.Clicked += () =>
      {
        MessageBox.Query("Message Box", "This is a message box", "OK");
      };


      window2.Add(btn);

      // top.Add(window);
      top.Add(window1);
      top.Add(window2);
      Application.Run();
      Application.Shutdown();
    }
  }
}

