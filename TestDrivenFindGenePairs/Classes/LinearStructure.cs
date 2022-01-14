using TestDrivenFindGenePairs.interfaces;
using TestDrivenFindGenePairs.Classes;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
namespace TestDrivenFindGenePairs.Classes
{
    public class LinearStuctureGene : IGeneHealthCalculator
    {

        
        private static int FindStrandTimes(string geneSearchInStrand , string geneCombination , int health)
        {
            /*
            Match m = Regex.Match( geneCombination,geneSearchInStrand);
            int match_Count = 0; 
             while (m.Success) {
               match_Count++;
               m = m.NextMatch();


            }  
           */




            int startIndex = geneCombination.IndexOf(geneSearchInStrand);
            int lastIndex =  geneCombination.LastIndexOf(geneSearchInStrand);
            
            
            int counter = 0;
            
            
             if(startIndex >= 0 && lastIndex < geneCombination.Length)
             {
                for(int i = startIndex ; i <= lastIndex ; i++)
                {
                    
                 if(geneSearchInStrand == geneCombination.Substring(i, geneSearchInStrand.Length))
                 {
                    counter++;
                 }
             }
            
                
            
           }
            return counter * health;
            
            
        }
        
        private static int StrandsCalculate(int n , List<string> genes , List<int> health, int s , string geneCombination ,int first , int last)
        {
            int healthGene = 0;
            int strandhealth = 0;
            try 
            {  
                 

            for(int i=first ; i <= last ; i++ )
            {
                if(geneCombination.Contains(genes[i]))
                {
                    healthGene =  FindStrandTimes(genes[i], geneCombination, health[i]);
                    strandhealth = strandhealth + healthGene ;    
                }
             }
            }
            catch(Exception excp)
            {
                Console.WriteLine($"For {geneCombination}  Time Error { excp.Message}");
                
            }
            return strandhealth;
        }
        
       public string CalculateGeneHealth(List<Strand> strands , List<Gene> genes)
       {
          long healthcounter = 0; 
          long totalhealth = 0;
          string healthdescription = String.Empty;
          try
          {

              
                  
               Stopwatch stopWatch = new Stopwatch();
               stopWatch.Start();     
              Parallel.ForEach(strands, strand =>
              {
                  healthcounter = 0;
                  totalhealth = 0;
                   for(int i=strand.startIndex ; i <= strand.endIndex ; i++)
                   {
                         strand.healthCounter =  strand.healthCounter + FindStrandTimes( genes[i].AlphaString , strand.geneCombination,genes[i].Health);
                        
                   }
                   // update health counter for strand
                   
                  

              });

              long min = strands.Min(p=>p.healthCounter);
              long max = strands.Max(p=>p.healthCounter);
              healthdescription =  $"The minimum health of gene is {min} and the maximum health of gene {max}"; 
              stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine($"Strands Processed  {strands.Count}  with total genes is {genes.Count} in about  {elapsedTime} for health  {healthdescription}");

          }
          catch(Exception excp)
          {

          }  
        return healthdescription;    

       }

       public Genetics ReplaceGeneticsOrder(List<Gene> currentStructure , List<Gene> PropsedStructure)
       {

           throw new NotImplementedException("Not Implmenting this one now");

       }

        public Genetics GetQualifiedGenePatterns(string structure)
        {
            throw new NotImplementedException("Not Implmenting this one now");


        }


    } 



}