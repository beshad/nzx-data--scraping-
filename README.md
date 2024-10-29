# NZX Scraper Sandbox

This project is a sandbox application written in C# that scrapes the NZX (New Zealand Stock Exchange) website to extract stock data.

## Features

- Scrapes stock information from the NZX website
- Displays detailed stock data, including trading status, value, volume, and more
- Simple and easy-to-use console interface for viewing stock information


![Screenshot](screenshot.png)


### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version X.X or later)

### Dependencies

This project uses the following NuGet packages:

- **HtmlAgilityPack**: Version 1.11.68 - for parsing HTML documents.
- **Terminal.Gui**: Version 1.17.1 - for creating terminal-based user interfaces.

### Setting Up the Project After Cloning

After cloning this repository, follow these steps to restore and rebuild the project:

1. **Open the terminal** and navigate to the project’s root directory.

2. **Restore dependencies** by running:
   ```bash
   dotnet restore

3. This will download any required NuGet packages that are needed for the project, and then run
   ```bash
   dotnet build

4. Run the program
   ```bash
   dotnet run

