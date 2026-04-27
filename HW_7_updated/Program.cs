using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

string inputFile = "MilanoCortina2026.csv";
string mottoFile = "motto.txt";
string outputFile = "TopPerformers.csv";
string outputStreamFile = "SummaryReport.txt";

if (File.Exists(inputFile))
{
    if (File.Exists(mottoFile))
    {
        string motto = File.ReadAllText(mottoFile);

        string[] rows = File.ReadAllLines(inputFile).Skip(1).ToArray();

        List<string> updatedRows = new List<string>();
        updatedRows.Add("Group,Gold,Silver,Bronze,Total");

        using (StreamWriter writer = new StreamWriter(outputStreamFile))
        {
            writer.WriteLine(motto);
            writer.WriteLine();
            writer.WriteLine("Olympic Milano Cortina Leader Board");
            writer.WriteLine($"{"Group",-20}{"Gold",-5}{"Silver",-8}{"Bronze",-8}{"Total",-8}");
            writer.WriteLine(new string('-', 55));

            foreach (string row in rows)
            {
                string[] data = row.Split(",");
                string group = data[0];
                int gold = int.Parse(data[1]);
                int silver = int.Parse(data[2]);
                int bronze = int.Parse(data[3]);
                int total = gold + silver + bronze;

                writer.WriteLine($"{group,-20}{gold,-5}{silver,-8}{bronze,-8}{total,-8}");

                // filter requirement (gold >= 10)
                if (gold >= 10)
                {
                    updatedRows.Add($"{group},{gold},{silver},{bronze},{total}");
                }

            }

        }

        File.WriteAllLines(outputFile, updatedRows);
        Console.WriteLine("Processing complete!");
        Console.WriteLine("- Summary report saved to: SummaryReport.txt");
        Console.WriteLine("- CSV filtered data saved to: TopPerformers.csv");
    }

    else
    {
        Console.WriteLine("motto.txt not found.");
    }
}

else
{
    Console.WriteLine("MilanoCortina2026.csv not found.");
}