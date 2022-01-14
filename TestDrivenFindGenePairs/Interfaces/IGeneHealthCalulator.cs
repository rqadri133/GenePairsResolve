using TestDrivenFindGenePairs.Classes;
using System.Collections.Generic;
using System.Text;
using System;

namespace TestDrivenFindGenePairs.interfaces 
{
    interface IGeneHealthCalculator
    {
         public string CalculateGeneHealth(List<Strand> strands , List<Gene> genes);  
         public Genetics ReplaceGeneticsOrder(List<Gene> currentStructure , List<Gene> PropsedStructure);
         // implement Prefix matches for a specified genetic pattern 

         public Genetics GetQualifiedGenePatterns(string structure);

   


    }
    
}

