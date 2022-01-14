using TestDrivenFindGenePairs.interfaces;
using TestDrivenFindGenePairs.Classes;
using System.Collections.Generic;
using System.Text;
using System;
namespace TestDrivenFindGenePairs.Classes.Util
{

    public class FlatFileHandler : IFileLoadersInMemory
    {
        public Genetics LoadGenetics(List<Line> lines)
        {
            var genetics = new Genetics();
            try
            {

                var line0 = lines[0];
                // get the numbers of genes in strands
                int n = 0;
                if (Int32.TryParse(line0.LineContent, out n))
                {
                    Console.WriteLine($"Number of Genes {n}");
                }

                var line1 = lines[1];
                // load all genes srings
                string[] genes = line1.LineContent.Split(" ".ToCharArray(), StringSplitOptions.
                RemoveEmptyEntries);
                var line2 = lines[2];
                string[] healths = line2.LineContent.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                // load genes 
                List<Gene> genesStructureData = new List<Gene>();

                for (int geneIndex = 0; geneIndex < genes.Length; geneIndex++)
                {
                    var gene = new Gene();
                    gene.AlphaString = genes[geneIndex];
                    gene.Health = Convert.ToInt32(healths[geneIndex]);
                    gene.Index = geneIndex;
                    genesStructureData.Add(gene);

                }
                // at this point you have loaded gene structures in memory 

                var line3 = lines[3];
                // the number of strand count
                int strandCount = Convert.ToInt32(line3.LineContent.Trim());
                string[] strandRanges = null;
                // strands starts all from line 4
                List<Strand> strands = new List<Strand>();
                for (int i = 4; i < lines.Count; i++)
                {
                    strandRanges = lines[i].LineContent.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    var strand = new Strand();
                    strand.startIndex = Convert.ToInt32(strandRanges[0]);
                    strand.endIndex = Convert.ToInt32(strandRanges[1]);
                    strand.geneCombination = strandRanges[2];
                    strands.Add(strand);
                }

                genetics.Genes = genesStructureData;
                genetics.Strands = strands;
         }
         catch(Exception ex)
         {
             Console.WriteLine($"{ex.Message}");

         }


         
        return genetics;





        }




    }



}
