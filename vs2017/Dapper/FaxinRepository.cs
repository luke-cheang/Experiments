using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

namespace MyDapper
{
    public class FaxinRepository
    {
        private readonly string _connectionString = @"Password=ab1234..;Persist Security Info=false;User ID=sa;Initial Catalog=ESun_UMSFTP;Data Source=10.1.5.102";

        public void GetFaxinCase(string faxinSeqNo, int? transStatus = null, int? efsStatus = null)
        {
            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                string sqlCase = 
                        @"SELECT" +
                        @" FAXIN_SEQ_NO as FaxInSeqNo," +
                        @" MSGID_IN_UMS as MsgIdInUms," +
                        @" FAXIN_TEL_NO as FaxInTelNo," +
                        @" FAXIN_TIME as FaxInTime," +
                        @" TIF_NAME as TifName," +
                        @" TIF_PAGE as TifPage," +
                        @" TRANS_STATUS as TransStatus," +
                        @" TO_EFS_STATUS as ToEfsStatus," +
                        @" SUBJECT as Subject," +
                        @" EMAIL_BODY as EmailBody," +
                        @" FUNCTION_CD as FunctionCd," +
                        @" COMPANY_TAX_ID as CompanyTaxId," +
                        @" FILE_NAMES as FileNames" +
                        @" FROM FAXIN_CASE" +
                        @" WHERE (FAXIN_SEQ_NO = @FaxinSeqNo)" +
                        @" AND (@TransStatus IS NULL OR TRANS_STATUS  = @TransStatus)" +
                        @" AND (@ToEfsStatus IS NULL OR TO_EFS_STATUS = @ToEfsStatus)" +
                        @"";
                string sqlItems = 
                        @"SELECT" +
                        @" FAXIN_SEQ_NO as FaxInSeqNo," +
                        @" JPG_SEQ_NO as JpgSeqNo," +
                        @" JPG_CONTENT as JpgContent," +
                        @" FileName as FileName," +
                        @" QR_Status as QrStatus," +
                        @" QR_INF1 as OrInf1," +
                        @" QR_INF2 as OrInf1," +
                        @" QR_INF3 as OrInf1," +
                        @" QR_INF4 as OrInf1" +
                        @" FROM FAXIN_REF_DOC_LINEITEM" +
                        @" WHERE FAXIN_SEQ_NO = @FaxinSeqNo " +
                        @" ORDER BY JPG_SEQ_NO";

                using 
                    (SqlMapper.GridReader grid = cnn.QueryMultiple(
                        sqlCase + ";" + sqlItems,
                        new
                        {
                            FaxinSeqNo = faxinSeqNo,
                            TransStatus = transStatus,
                            ToEfsStatus = efsStatus
                        }
                    ))
                {
                    FaxinCaseWithRefDocLineItem result = new FaxinCaseWithRefDocLineItem();

                    var summary = grid.Read<FaxinCase>();
                    var detail = grid.Read<FaxInRefDocLineItem>();

                    Console.WriteLine($"summary.Count={summary.Count()}");
                    Console.WriteLine($"detail.Count={detail.Count()}");

                    //result.faxInRefDocs = detail.ToList();
                    //result.faxinCase = summary;

                    Console.WriteLine($"result.faxInRefDocs.Count={result.faxInRefDocs.Count()}");
                }
            }   // using(cnn)

        }   // GetFaxinCase();

    }   // FaxinRepository

}   // MyDapper
