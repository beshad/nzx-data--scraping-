using System;
using Terminal.Gui;
using Scraper;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using HtmlAgilityPack;
using System.Text.Json;
using System.Xml;

namespace Database
{

  class Connect
  {
    public static void Run()
    {
      List<Stock> data = Init();
      Save(data);
    }

    public static List<Stock> Init()
    {
      var url = "https://www.nzx.com/markets/NZSX";
      var web = new HtmlWeb();
      var doc = web.Load(url);

      var tableRows = doc.DocumentNode
        .SelectNodes("//table[contains(@class, 'TableStyled')]/tbody/tr");

      var data = new List<Stock>();
      foreach (var row in tableRows)
      {
        var cells = row.SelectNodes("td");
        var ticker = cells[0].SelectSingleNode("a/strong").InnerText;
        var name = cells[1].SelectSingleNode("a").InnerText;
        var price = cells[2].InnerText.Trim();

        data.Add(new Stock
        {
          Ticker = ticker,
          Name = name,
          Price = price
        });

      }

      return data;
    }

    public static void Save(List<Stock> stocks)
    {
      // Replace with your own connection string
      string connectionString = "Host=localhost;Database=stock_db;Username=postgres;Password=mysecretpassword";

      using (var connection = new NpgsqlConnection(connectionString))
      {
        connection.Open();

        using (var command = new NpgsqlCommand("INSERT INTO stocks (ticker, name, price) VALUES (@ticker, @name, @price)", connection))
        {
          foreach (var stock in stocks)
          {
            command.Parameters.AddWithValue("@ticker", stock.Ticker);
            command.Parameters.AddWithValue("@name", stock.Name);
            command.Parameters.AddWithValue("@price", stock.Price);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
          }
        }
      }
    }
  }

  public class Stock
  {
    public string? Ticker { get; set; }
    public string? Name { get; set; }
    public string? Price { get; set; }
  }
}

