
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

    var tableHeader = "Stock Details";
    var tableSeparator = new string('=', tableHeader.Length);

    var tableContent = new StringBuilder();
    tableContent.AppendLine(tableHeader);
    tableContent.AppendLine(tableSeparator);
    tableContent.AppendLine($"{"Ticker:",0} {stockDetails.Ticker}");
    tableContent.AppendLine($"{"Trading Status:",0} {stockDetails.TradingStatus}");
    tableContent.AppendLine($"{"Trades:",0} {stockDetails.Trades}");
    tableContent.AppendLine($"{"Value:",0} {stockDetails.Value}");
    tableContent.AppendLine($"{"Volume:",0} {stockDetails.Volume}");
    tableContent.AppendLine($"{"Capitalisation:",0} {stockDetails.Capitalisation}");
    tableContent.AppendLine($"{"Open:",0} {stockDetails.Open}");
    tableContent.AppendLine($"{"High:",0} {stockDetails.High}");
    tableContent.AppendLine($"{"Low:",0} {stockDetails.Low}");
    tableContent.AppendLine($"{"High Bid:",0} {stockDetails.HighBid}");
    tableContent.AppendLine($"{"Low Offer:",0} {stockDetails.LowOffer}");

    MessageBox.Query("Stock Details", tableContent.ToString(), "Ok");
  }
}