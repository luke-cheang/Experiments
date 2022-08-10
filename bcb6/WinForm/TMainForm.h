//---------------------------------------------------------------------------

#ifndef TMainFormH
#define TMainFormH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Dialogs.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
    TButton *btnLoadIni;
    TLabel *lbConnStr;
    TEdit *txtConnStr;
    TLabel *lbB64Pswd;
    TEdit *txtB64Pswd;
    TButton *btnDecodePswd;
    TLabel *lbPlainPswd;
    TEdit *txtPlainPswd;
    TButton *btnTestConnection;
    TOpenDialog *OpenDialog1;
    TCheckBox *chkQuotePswd;
    void __fastcall btnLoadIniClick(TObject *Sender);
    void __fastcall txtB64PswdChange(TObject *Sender);
    void __fastcall txtConnStrChange(TObject *Sender);
    void __fastcall btnDecodePswdClick(TObject *Sender);
    void __fastcall btnTestConnectionClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
    __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
