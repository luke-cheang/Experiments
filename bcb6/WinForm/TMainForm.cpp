//---------------------------------------------------------------------------

#include <vcl.h>
#include <inifiles.hpp>
#include <ADODB.hpp>
#pragma hdrstop

#include "TMainForm.h"
#include "Base64.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TMainForm *MainForm;
//---------------------------------------------------------------------------
__fastcall TMainForm::TMainForm(TComponent* Owner)
    : TForm(Owner)
{
    txtConnStr->Text = "";
    txtB64Pswd->Text = "";
    txtPlainPswd->Text = "";
    btnDecodePswd->Enabled = false;
    btnTestConnection->Enabled = false;
}
//---------------------------------------------------------------------------
void __fastcall TMainForm::btnLoadIniClick(TObject *Sender)
{
    // 從INI檔載入連線字串設定。
    OpenDialog1->Filter = "Ini files (*.ini)|*.ini|Text files (*.txt)|*.txt|All files (*.*)|*.*";
    OpenDialog1->FilterIndex = 1;
    OpenDialog1->Title = "Load INI file";
    bool brc = OpenDialog1->Execute();
    if (brc)
    {
        TMemIniFile *ini = new TMemIniFile(OpenDialog1->FileName.c_str());
        txtConnStr->Text = ini->ReadString("DBInfo", "ConnStr", "");
        txtB64Pswd->Text = ini->ReadString("DBInfo", "EncodedPswd", "");
    }
}
//---------------------------------------------------------------------------
void __fastcall TMainForm::txtConnStrChange(TObject *Sender)
{
    if (txtConnStr->Text.Length() > 0)
    {
        // 只要有連線字串(不管有沒有密碼都可以)就可以測試連線。
        btnTestConnection->Enabled = true;
    }
    else
    {
        btnTestConnection->Enabled = false;
    }
}
//---------------------------------------------------------------------------
void __fastcall TMainForm::txtB64PswdChange(TObject *Sender)
{
    txtPlainPswd->Text = "";    // 固定都清除原本的密碼。
    if (txtB64Pswd->Text.Length() > 0)
    {
        // 有編碼過的密碼，就可以解碼。
        btnDecodePswd->Enabled = true;
    }
    else
    {
        btnDecodePswd->Enabled = false;
    }
}
//---------------------------------------------------------------------------
void __fastcall TMainForm::btnDecodePswdClick(TObject *Sender)
{
    Base64 *b64 = new Base64();
    int size = b64->GetDecodeSize(txtB64Pswd->Text.c_str());
    char *plainPswd = new char[size + 1];   // 要多一個字元空間來放\0。
    for (int i = 0; i <= size; i++)         // 包含結束字元空間在內，都先清掉。
        plainPswd[i] = 0x00;
    int rc = b64->Decode(txtB64Pswd->Text.c_str(), plainPswd);
    if (0 == rc)
    {
        txtPlainPswd->Text = plainPswd;
    }
    else
    {
        txtPlainPswd->Text = "";
    }
    delete plainPswd;
    delete b64;
}
//---------------------------------------------------------------------------


void __fastcall TMainForm::btnTestConnectionClick(TObject *Sender)
{
    TADOConnection *cnn = new TADOConnection(NULL);

    AnsiString cnnStr = txtConnStr->Text;
    AnsiString pswd;
    if (!txtPlainPswd->Text.IsEmpty())
    {
        if (chkQuotePswd->Checked)
        {
            // 密碼中若有任何一個雙引號，要替換成連續兩個雙引號。
            // 再用雙引號包起來，再加入至連線字串。
            pswd = StringReplace(txtPlainPswd->Text, "\"", "\"\"", TReplaceFlags()<<rfReplaceAll);
            cnnStr += ";Password=\"" + pswd + "\";";
            // 當解碼後的明碼密碼為 ~!@#$%^&*()_+`-={}|[]\:";'<>?,./
            // 當中的雙引號換成了連續兩個雙引號後，連線會失敗，
            // Exception為Format of the initialization string does not conform to the OLE DB specification
            // 如果密碼中不包含分號 ~!@#$%^&*()_+`-={}|[]\:"'<>?,./
            // 把密碼中的雙引號換成連續兩個雙引號，再把密碼整段用雙引號包起來，
            // 即 Password="~!@#$%^&*()_+`-={}|[]\:""'<>?,./";
            // 連線是會成功的。
            // 如果密碼當中有分號，但不含雙引號，像 ~!@#$%^&*()_+`-={}|[]\:;'<>?,./
            // 即 Password="~!@#$%^&*()_+`-={}|[]\:;'<>?,./";
            // 連線是會成功的。
        }
        else
        {
            // 直接把解碼後的明碼密碼，加入至連線字串中。
            pswd = txtPlainPswd->Text;
            cnnStr += ";Password=" + pswd + ";";
            // 當解碼後的明碼密碼為 ~!@#$%^&*()_+`-={}|[]\:";'<>?,./
            // 其中的單、雙引號不會產生問題，但分號及分號以後的會被忽略，只有分號前的會視為密碼。
            // 如果密碼中不包含分號 ~!@#$%^&*()_+`-={}|[]\:"'<>?,./
            // 就算當中有單引號及雙引號，
            // 即 Password=~!@#$%^&*()_+`-={}|[]\:"'<>?,./;
            // 連線是會成功的。
        }
    }
    cnn->ConnectionString = cnnStr;
    Application->MessageBoxA(cnnStr.c_str(), "Connection String", MB_OK);
    try
    {
        cnn->Open();
        if (cnn->Connected)
            Application->MessageBoxA("Success", "Test Connection", MB_OK);
        cnn->Close();
    }
    catch (Exception& ex)
    {
        AnsiString msg = "";
        msg += "Connection:\n";
        msg += cnn->ConnectionString;
        msg += "\n";
        msg += "Exception:\n";
        msg += ex.Message;
        Application->MessageBoxA(msg.c_str(), "Test Connection", MB_OK);
    }
}
//---------------------------------------------------------------------------


