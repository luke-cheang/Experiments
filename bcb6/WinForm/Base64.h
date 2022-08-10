//---------------------------------------------------------------------------

#ifndef Base64H
#define Base64H

class Base64
{
public:
    Base64();
    ~Base64();
    int GetEncodeSize(int srcLen);
    int GetDecodeSize(char * srcStr);
    int Encode(unsigned char * srcBytes, int srcLen, char * trgBuf);
    int Decode(char * srcStr, unsigned char * trgBuf);
private:
    bool IsValidBase64Char(char c);
    char* Encode3Bytes(unsigned char *srcBytes);
    char* Encode2Bytes(unsigned char * srcBytes);
    char* Encode1Byte(unsigned char * srcBytes);
    int Decode4Chars(char * srcChars, unsigned char * trgBytes);
};

//---------------------------------------------------------------------------
#endif
