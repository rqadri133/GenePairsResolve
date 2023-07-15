
// this copy right to syed qadri hacker rank problem solution 
﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using TestDrivenFindGenePairs.Classes.Util;
using TestDrivenFindGenePairs.Classes;
using TestDrivenFindGenePairs.interfaces;

public enum GeneFileStructure
{
    FlatFileLinear,
    XmlFileStructure
 

}

class Solution
{

    

    
    public static void Main(string[] args)
    {
           IEnumerable<string> files = Directory.EnumerateFiles(Environment.CurrentDirectory + "\\TestData" );
           List<Line> lines = new List<Line>();
           // Currently its just one structure 
           GeneFileStructure fileSystem = GeneFileStructure.FlatFileLinear;     
           IGeneHealthCalculator geneHealthCalculator ; 
           IFileLoadersInMemory fileHandler;
           Genetics genetics; 
           string health = String.Empty;    
           List<string> healthTestList = new List<string>();
           foreach(string filepath in files)
           {
                lines  = FileContextReader.ReadFile(filepath);
                health = String.Empty;
                switch(fileSystem)
                {
                    case GeneFileStructure.FlatFileLinear:
                    fileHandler = new FlatFileHandler();
                    genetics = fileHandler.LoadGenetics(lines);
                    geneHealthCalculator = new LinearStuctureGene();
                    health = geneHealthCalculator.CalculateGeneHealth(genetics.Strands,genetics.Genes);
                    healthTestList.Add(health); 
                    break;
                    case GeneFileStructure.XmlFileStructure:
                      throw new NotImplementedException("Xml Structure Genes not implemented waiting for Data Format"); 
                    

                }
           } 

           foreach(string str in healthTestList)
           {
               Console.WriteLine($"The {str}");



           }
           Console.ReadLine();


        
       
    }
}
