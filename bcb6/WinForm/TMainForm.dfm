object MainForm: TMainForm
  Left = 215
  Top = 128
  Width = 648
  Height = 224
  Caption = 'MainForm'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object lbConnStr: TLabel
    Left = 11
    Top = 41
    Width = 90
    Height = 13
    Alignment = taRightJustify
    AutoSize = False
    Caption = 'Connection String:'
  end
  object lbB64Pswd: TLabel
    Left = 11
    Top = 71
    Width = 90
    Height = 13
    Alignment = taRightJustify
    AutoSize = False
    Caption = 'Base64 Password:'
  end
  object lbPlainPswd: TLabel
    Left = 11
    Top = 101
    Width = 90
    Height = 13
    Alignment = taRightJustify
    AutoSize = False
    Caption = 'Plain Password:'
  end
  object btnLoadIni: TButton
    Left = 11
    Top = 7
    Width = 100
    Height = 25
    Hint = 'Load connection string from INI file.'
    Caption = 'Load INI'
    TabOrder = 0
    OnClick = btnLoadIniClick
  end
  object txtConnStr: TEdit
    Left = 105
    Top = 37
    Width = 520
    Height = 21
    TabOrder = 1
    OnChange = txtConnStrChange
  end
  object txtB64Pswd: TEdit
    Left = 105
    Top = 67
    Width = 520
    Height = 21
    TabOrder = 2
    OnChange = txtB64PswdChange
  end
  object btnDecodePswd: TButton
    Left = 11
    Top = 131
    Width = 100
    Height = 25
    Hint = 'Decode the password from Base64.'
    Caption = 'Decode Password'
    TabOrder = 3
    OnClick = btnDecodePswdClick
  end
  object txtPlainPswd: TEdit
    Left = 105
    Top = 97
    Width = 520
    Height = 21
    TabOrder = 4
  end
  object btnTestConnection: TButton
    Left = 241
    Top = 131
    Width = 100
    Height = 25
    Hint = 'Form a connection string and test the connection.'
    Caption = 'Test Connection'
    TabOrder = 5
    OnClick = btnTestConnectionClick
  end
  object chkQuotePswd: TCheckBox
    Left = 121
    Top = 131
    Width = 113
    Height = 25
    Caption = 'Quote Password'
    Checked = True
    State = cbChecked
    TabOrder = 6
  end
  object OpenDialog1: TOpenDialog
    Left = 584
  end
end
