using TestDrivenFindGenePairs.Classes;
using System.Collections.Generic;
using System.Text;
using System;

namespace TestDrivenFindGenePairs.interfaces 
{
    interface IGeneManufacture<T>  where T: ProteinContent  
    {
        // EPIC
        // Finding Lab Result files Samples 
        // Finding possible strands 
         public string MergeReplaceGene(List<Gene> source , List<Gene> healthyGene);
         // We will find mutiple protien strcuture patterns  
         public string FindProtienVirusStructure(T t);

         public string RemoveReplaceVirusStucture(T t);
         public string ReplaceInfectedChromosome(List<Gene> source, StringBuilder genefile); 
         

    }

    internal class ProteinContent
    {
    }
}

