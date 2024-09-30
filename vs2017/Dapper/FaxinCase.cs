using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapper
{
    public class FaxinCase
    {
        [Key]
        public string FaxInSeqNo { get; set; }
        public int MsgIdInUms { get; set; }
        public string FaxInTelNo { get; set; }
        public DateTime FaxInTime { get; set; }
        public string TifName { get; set; }
        public int TifPage { get; set; }
        public int TransStatus { get; set; }
        public int ToEfsStatus { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public string FunctionCd { get; set; }
        public string CompanyTaxId { get; set; }
        public string FileNames { get; set; }
    }   // FaxinCase

}   // MyDapper

