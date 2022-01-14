using TestDrivenFindGenePairs.Classes;
using System.Collections.Generic;
using System.Text;
using System;

namespace TestDrivenFindGenePairs.interfaces 
{
    interface IGeneManufacture<T>  where T: IProtien  
    {
        // EPIC
        // Finding all pattersn 
        // Finding Lab Result files Samples 
        // Finding Researched infected Pattern from Lab / disclosure Court Proceddings Required
        // Finding possible strands 
        // Call NIH ( National Isntitute of Health) , negotitaions required to get sample data 
         public string MergeReplaceGene(List<Gene> source , List<Gene> healthyGene);
         // We will find mutiple protien strcuture patterns  
         public string FindProtienVirusStructure(T t);
         public string ReplaceInfectedChromosome(List<Gene> source, StringBuilder genefile); 
         

    }
    
}

