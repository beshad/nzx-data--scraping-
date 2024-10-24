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
    var url = "https://www.nzx.com/markets/NZSX";
    var web = new HtmlWeb();
    var doc = web.Load(url);

    var tableRows = doc.DocumentNode
      .SelectNodes("//table[contains(@class, 'TableStyled')]/tbody/tr");

    var data = new List<StockData>();
    foreach (var row in tableRows)
    {
      var cells = row.SelectNodes("td");
      var ticker = cells[0].SelectSingleNode("a/strong").InnerText;
      var name = cells[1].SelectSingleNode("a").InnerText;
      var price = cells[2].InnerText.Trim();

      data.Add(new StockData
      {
        Ticker = ticker,
        Name = name,
        Price = price
      });

      Console.WriteLine($"Ticker: {ticker}, Name: {name}, Price: {price}");
    }

    var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText("stock_data.json", json);
  }
}

public class StockData
{
  public string? Ticker { get; set; }
  public string? Name { get; set; }
  public string? Price { get; set; }
}