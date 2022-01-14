using TestDrivenFindGenePairs.interfaces;
using TestDrivenFindGenePairs.Classes;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
namespace TestDrivenFindGenePairs.interfaces
{
  public interface IFileLoadersInMemory
  {
        public Genetics  LoadGenetics(List<Line> lines);
       

  }



}

