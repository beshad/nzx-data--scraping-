using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;

namespace Scraper
{

  public partial class Scraper
  {
    public static List<StockData> Init()
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

      }

      var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
      File.WriteAllText("stock_data.json", json);

      return data;
    }

    public static string GetStockDetails(string ticker)
    {
      var url = $"https://www.nzx.com/instruments/{ticker}";
      var web = new HtmlWeb();
      var doc = web.Load(url);

      // Extract trading metrics
      var tradingStatusNode = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'MetricTable')]//tbody/tr[th='Trading status']/td");
      var tradesNode = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'MetricTable')]//tbody/tr[th='Trades']/td");
      var valueNode = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'MetricTable')]//tbody/tr[th='Value']/td");
      var volumeNode = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'MetricTable')]//tbody/tr[th='Volume']/td");
      var capitalisationNode = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'MetricTable')]//tbody/tr[th='Capitalisation (000s)']/td");

      // Extract performance metrics
      var openNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'Panel') and h3[@id='P']]//table[contains(@class, 'MetricTable')]//tr[th='Open']/td");
      var highNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'Panel') and h3[@id='P']]//table[contains(@class, 'MetricTable')]//tr[th='High']/td");
      var lowNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'Panel') and h3[@id='P']]//table[contains(@class, 'MetricTable')]//tr[th='Low']/td");
      var highBidNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'Panel') and h3[@id='P']]//table[contains(@class, 'MetricTable')]//tr[th='High Bid']/td");
      var lowOfferNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'Panel') and h3[@id='P']]//table[contains(@class, 'MetricTable')]//tr[th='Low Offer']/td");

      // Extract fundamental metrics
      var peNode = doc.DocumentNode.SelectSingleNode(".//tbody/tr[th='P/E']/td");
      var epsNode = doc.DocumentNode.SelectSingleNode(".//tbody/tr[th='EPS']/td");
      var ntaNode = doc.DocumentNode.SelectSingleNode(".//tbody/tr[th='NTA']/td");
      var grossDivYieldNode = doc.DocumentNode.SelectSingleNode(".//tbody/tr[th='Gross Div Yield']/td");
      var securitiesIssuedNode = doc.DocumentNode.SelectSingleNode(".//tbody/tr[th='Securities Issued']/td");

      return $@"
            Trading Status: {tradingStatusNode?.InnerText ?? "Not found"}
            Trades: {tradesNode?.InnerText ?? "Not found"}
            Value: {valueNode?.InnerText ?? "Not found"}
            Volume: {volumeNode?.InnerText ?? "Not found"}
            Capitalisation: {capitalisationNode?.InnerText ?? "Not found"}
            Open: {openNode?.InnerText ?? "Not found"}
            High: {highNode?.InnerText ?? "Not found"}
            Low: {lowNode?.InnerText ?? "Not found"}
            High Bid: {highBidNode?.InnerText ?? "Not found"}
            Low Offer: {lowOfferNode?.InnerText ?? "Not found"}
            P/E: {peNode?.InnerText.Trim() ?? "Not found"}
            EPS: {epsNode?.InnerText.Trim() ?? "Not found"}
            NTA: {ntaNode?.InnerText.Trim() ?? "Not found"}
            Gross Div Yield: {grossDivYieldNode?.InnerText.Trim() ?? "Not found"}
            Securities Issued: {securitiesIssuedNode?.InnerText.Trim() ?? "Not found"}
        ";
    }
  }


  public class StockData
  {
    public string? Ticker { get; set; }
    public string? Name { get; set; }
    public string? Price { get; set; }
  }



}