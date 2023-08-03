using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

//namespace Axon
//To Generate a Random Chart for a music with certain BPM and Length
class ChartGenerator
{
    static void Main(string[] s)
    {
        Console.WriteLine("Please give Chart Title");
        string chartTitle = Console.ReadLine();

        Console.WriteLine("Please give BPM");
        string bpm = Console.ReadLine();
        float bpmNumber = float.Parse(bpm);

        Console.WriteLine("Please give length in seconds");
        string seconds = Console.ReadLine();
        float secondsNumber = float.Parse(seconds);

        Console.WriteLine("Please give initial delay in seconds");
        string initialDelay = Console.ReadLine();
        float initialDelayNumber = float.Parse(initialDelay);

        Console.WriteLine("Please give number of cells");
        string numberCells = Console.ReadLine();
        int numberOfCells = int.Parse(numberCells);

        Console.WriteLine("Please give number of sheaths each cell");
        string numberSheaths = Console.ReadLine();
        int numberOfSheaths = int.Parse(numberSheaths);

        Console.WriteLine("Please give note density (1-6)");
        Console.WriteLine("1=1 note each measure");
        Console.WriteLine("2=2 notes double tap each measure");
        Console.WriteLine("3=1 note each beat");
        Console.WriteLine("4=1 note each beat, and a double tap each measure");
        Console.WriteLine("5=1 note each 1/8 note");
        Console.WriteLine("6=2 notes each 1/4 note");
        string noteDensity = Console.ReadLine();
        int noteDensityNumber = int.Parse(noteDensity);


        Console.WriteLine("Generating chart with difficulty " + noteDensity);
        StreamWriter output = new (chartTitle + ".txt");
        // To be read by chart reader
        // cell number||note number||note type||note judging time||special effect
        output.WriteLine(numberCells);
        output.WriteLine(numberSheaths);
        int measures = (int)(secondsNumber * bpmNumber / 60 / 4);
        float beatTime = 60.0f / bpmNumber * 4;
        var rand = new Random();
        float noteTime = initialDelayNumber;
        // output.WriteLine(rand.Next(numberOfCells)+","+rand.Next(numberOfSheaths+1)+","+"t"+","+"noteTime"+"n";
        switch (noteDensityNumber)
        {
            case (1):
                for (int i = 0; i < measures; i++)
                {
                    output.WriteLine(rand.Next(numberOfCells) + "," + rand.Next(numberOfSheaths + 1) + "," + "t" + "," + noteTime + "n");
                    noteTime += beatTime * 4;
                }
                break;
            case (2):
                for (int i = 0; i < measures; i++)
                {
                    output.WriteLine(rand.Next(numberOfCells) + "," + rand.Next(numberOfSheaths + 1) + "," + "t" + "," + noteTime + "n");
                    output.WriteLine(rand.Next(numberOfCells) + "," + rand.Next(numberOfSheaths + 1) + "," + "t" + "," + noteTime + "n");
                    noteTime += beatTime * 4;
                }
                break;
            case (3):
                for (int i = 0; i < measures * 4; i++)
                {
                    output.WriteLine(rand.Next(numberOfCells) + "," + rand.Next(numberOfSheaths + 1) + "," + "t" + "," + noteTime + "n");
                    noteTime += beatTime;
                }
                break;
            case (4):
                for (int i = 0; i < measures * 4; i++)
                {
                    output.WriteLine(rand.Next(numberOfCells) + "," + rand.Next(numberOfSheaths + 1) + "," + "t" + "," + noteTime + "n");
                    if (measures % 4 == 0)
                    {
                        output.WriteLine(rand.Next(numberOfCells) + "," + rand.Next(numberOfSheaths + 1) + "," + "t" + "," + noteTime + "n");
                    }
                    noteTime += beatTime;
                }
                break;
            case (5):
                for (int i = 0; i < measures * 8; i++)
                {
                    output.WriteLine(rand.Next(numberOfCells) + "," + rand.Next(numberOfSheaths + 1) + "," + "t" + "," + noteTime + "n");
                    noteTime += beatTime / 2;
                }
                break;
            case (6):
                for (int i = 0; i < measures * 4; i++)
                {
                    output.WriteLine(rand.Next(numberOfCells) + "," + rand.Next(numberOfSheaths + 1) + "," + "t" + "," + noteTime + "n");
                    output.WriteLine(rand.Next(numberOfCells) + "," + rand.Next(numberOfSheaths + 1) + "," + "t" + "," + noteTime + "n");
                    noteTime += beatTime;
                }
                break;

        }
        Console.WriteLine("Generated chart with difficulty ");
    }
}
