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
    // �qINI�ɸ��J�s�u�r��]�w�C
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
        // �u�n���s�u�r��(���ަ��S���K�X���i�H)�N�i�H���ճs�u�C
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
    txtPlainPswd->Text = "";    // �T�w���M���쥻���K�X�C
    if (txtB64Pswd->Text.Length() > 0)
    {
        // ���s�X�L���K�X�A�N�i�H�ѽX�C
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
    char *plainPswd = new char[size + 1];   // �n�h�@�Ӧr���Ŷ��ө�\0�C
    for (int i = 0; i <= size; i++)         // �]�t�����r���Ŷ��b���A�����M���C
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
            // �K�X���Y������@�����޸��A�n�������s�������޸��C
            // �A�����޸��]�_�ӡA�A�[�J�ܳs�u�r��C
            pswd = StringReplace(txtPlainPswd->Text, "\"", "\"\"", TReplaceFlags()<<rfReplaceAll);
            cnnStr += ";Password=\"" + pswd + "\";";
            // ��ѽX�᪺���X�K�X�� ~!@#$%^&*()_+`-={}|[]\:";'<>?,./
            // �������޸������F�s�������޸���A�s�u�|���ѡA
            // Exception��Format of the initialization string does not conform to the OLE DB specification
            // �p�G�K�X�����]�t���� ~!@#$%^&*()_+`-={}|[]\:"'<>?,./
            // ��K�X�������޸������s�������޸��A�A��K�X��q�����޸��]�_�ӡA
            // �Y Password="~!@#$%^&*()_+`-={}|[]\:""'<>?,./";
            // �s�u�O�|���\���C
            // �p�G�K�X���������A�����t���޸��A�� ~!@#$%^&*()_+`-={}|[]\:;'<>?,./
            // �Y Password="~!@#$%^&*()_+`-={}|[]\:;'<>?,./";
            // �s�u�O�|���\���C
        }
        else
        {
            // ������ѽX�᪺���X�K�X�A�[�J�ܳs�u�r�ꤤ�C
            pswd = txtPlainPswd->Text;
            cnnStr += ";Password=" + pswd + ";";
            // ��ѽX�᪺���X�K�X�� ~!@#$%^&*()_+`-={}|[]\:";'<>?,./
            // �䤤����B���޸����|���Ͱ��D�A�������Τ����H�᪺�|�Q�����A�u�������e���|�����K�X�C
            // �p�G�K�X�����]�t���� ~!@#$%^&*()_+`-={}|[]\:"'<>?,./
            // �N�������޸������޸��A
            // �Y Password=~!@#$%^&*()_+`-={}|[]\:"'<>?,./;
            // �s�u�O�|���\���C
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


