using TestDrivenFindGenePairs.interfaces;
using TestDrivenFindGenePairs.Classes;
using System.Collections.Generic;
using System.Text;
using System;

namespace TestDrivenFindGenePairs.Classes 
{
    
public class Strand
{
   public int startIndex
   {
       get;
       set;

   }

   public int endIndex
   {
       get;
       set;
   }

   public string geneCombination
   {
       get;
       set;

   } 
   
   public long healthCounter 
   {
       get;
       set;
   } 

    
}
}
