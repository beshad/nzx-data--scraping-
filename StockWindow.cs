
using System;
using Terminal.Gui;
using Scraper;
using System.IO;
using System.Collections.Generic;
using System.Text;

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

    listView.OpenSelectedItem += OnStockSelected;

    Add(listView);
  }

  private void OnStockSelected(ListViewItemEventArgs args)
  {
    var selectedStock = Scraper.Scraper.Init()[args.Item];
    var stockDetails = Scraper.Scraper.GetStockDetails(selectedStock.Ticker);

    // var tableHeader = "Stock Details";
    // var tableSeparator = new string('=', tableHeader.Length);

    // var tableContent = new StringBuilder();
    // tableContent.AppendLine(tableHeader);
    // tableContent.AppendLine(tableSeparator);
    // tableContent.AppendLine($"{"Ticker:",-20} {selectedStock.Ticker}");
    // tableContent.AppendLine($"{"Trading Status:",-20} {stockDetails["Trading Status"]}");
    // tableContent.AppendLine($"{"Trades:",-20} {stockDetails["Trades"]}");
    // tableContent.AppendLine($"{"Value:",-20} {stockDetails["Value"]}");
    // tableContent.AppendLine($"{"Volume:",-20} {stockDetails["Volume"]}");
    // tableContent.AppendLine($"{"Capitalisation:",-20} {stockDetails["Capitalisation"]}");
    // tableContent.AppendLine($"{"Open:",-20} {stockDetails["Open"]}");
    // tableContent.AppendLine($"{"High:",-20} {stockDetails["High"]}");
    // tableContent.AppendLine($"{"Low:",-20} {stockDetails["Low"]}");
    // tableContent.AppendLine($"{"High Bid:",-20} {stockDetails["High Bid"]}");
    // tableContent.AppendLine($"{"Low Offer:",-20} {stockDetails["Low Offer"]}");

    // MessageBox.Query("Stock Details", tableContent.ToString(), "Ok");

    MessageBox.Query("Stock Details", stockDetails, "Ok");
  }
}