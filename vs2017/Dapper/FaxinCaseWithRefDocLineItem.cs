using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapper
{
    public class FaxinCaseWithRefDocLineItem
    {
        public FaxinCase faxinCase { get; set; }
        public List<FaxInRefDocLineItem> faxInRefDocs { get; set; }
    }   // FaxinCaseWithRefDocLineItem

}   // MyDapper
