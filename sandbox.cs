using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using Terminal.Gui;
using Terminal.Gui.Trees;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

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



      var dt = new DataTable();
      var lines = File.ReadAllLines("stock_data.csv");

      foreach (var h in lines[0].Split(','))
      {
        dt.Columns.Add(h);
      }

      foreach (var line in lines.Skip(1))
      {
        dt.Rows.Add(line.Split(','));
      }

      var tableView = new TableView()
      {
        X = 0,
        Y = 0,
        Width = Dim.Fill(),
        Height = Dim.Fill(),
      };

      tableView.Table = dt; 
      window1.Add(tableView);

      var tree = new TreeView()
      {
        X = 0,
        Y = 0,
        Width = 40,
        Height = 20
      };

      var root1 = new TreeNode("Root1");
      root1.Children.Add(new TreeNode("Child1.1"));
      root1.Children.Add(new TreeNode("Child1.2"));

      var root2 = new TreeNode("Root2");
      root2.Children.Add(new TreeNode("Child2.1"));
      root2.Children.Add(new TreeNode("Child2.2"));

      tree.AddObject(root1);
      tree.AddObject(root2);

      window2.Add(tree);

      // top.Add(window);
      top.Add(window1);
      top.Add(window2);
      Application.Run();
      Application.Shutdown();
    }
  }
}

