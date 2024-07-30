# CSV Discrepancy Finder

A web application built with C# and .NET Core to find differences between two CSV files. The application checks for discrepancies in rows and columns, identifying missing rows and columns between the two files.

## Features

- Upload two CSV files for comparison
- Identify and report missing rows between the files
- Identify and report missing columns between the files
- Easy-to-use web interface

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 3.1 or later)

## Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/CSVDiscrepancyFinder.git
    cd CSVDiscrepancyFinder
    ```

2. Build the project:
    ```bash
    dotnet build
    ```

3. Run the project:
    ```bash
    dotnet run
    ```

4. Open your browser and navigate to the localhost url that you can see in the output 

## Usage

1. On the homepage, upload two CSV files for comparison.
2. Click the "Compare" button.
3. View the discrepancy report that identifies missing rows and columns.

CsvComparator/
│
├── Controllers/
│   └── HomeController.cs
│
├── Models/
│   ├── CsvData.cs
│   └── DiscrepancyReport.cs
│
├── Views/
│   └── Home/
│       ├── Index.cshtml
│       └── Report.cshtml
│
└── CsvComparator.csproj

