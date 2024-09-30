using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapper
{
    public class FaxInRefDocLineItem
    {
        [Key]
        public string FaxInSeqNo { get; set; }
        public string JpgSeqNo { get; set; }
        public byte[] JpgContent { get; set; }
        public string FileName { get; set; }
        public int QrStatus { get; set; }
        public string QrInf1 { get; set; }
        public string QrInf2 { get; set; }
        public string QrInf3 { get; set; }
        public string QrInf4 { get; set; }
    }   // FaxInRefDocLineItem

}   // MyDapper
