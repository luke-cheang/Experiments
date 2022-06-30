#include <string.h>
#include "Base64.h"

/// <summary>
/// �r���ഫ������C
/// </summary>
/// <remark>
/// Base64�O��64�ӥi�C�L��Ʀr�ӥN��Ҧ���binary data�C
/// �ϥΪ���Ʀr�]�AA~Z, a~z, 0~9, + �M / �@64�ӡC
/// </remark>
static char MappingTable[] =
{
	'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
	'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
	'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd',
	'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
	'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
	'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7',
	'8', '9', '+', '/'
};	// MappingTable

/// <summary>
/// Default constructor of Base64.
/// </summary>
Base64::Base64()
{

}	// Base64();

/// <summary>
/// Default destructor of Base64.
/// </summary>
Base64::~Base64()
{

}	// ~Base();

/// <summary>
/// �P�_�O�_���X�k��Base64�r���C
/// </summary>
/// <param name="c">�n�P�_���r���C</param>
/// <returns>true�N��OBase64�r���C</returns>
/// <remarks>
/// �ɪŦr��(=)����O�X�k��Base64�r���C
/// </remarks>
bool Base64::IsValidBase64Char(char c)
{
	if (((c >= 'A') && (c <= 'Z')) ||
		((c >= 'a') && (c <= 'z')) ||
		((c >= '0') && (c <= '9')) ||
		((c == '+') || (c == '/')))
	{
		return true;
	}
	else
		return false;
}	// IsValidBase64Char();

/// <summary>
/// ��ǤJ��3�Ӧ줸���ഫ��4��Base64��r�C
/// </summary>
/// <param name="srcBytes">���V�n�ഫ��3�Ӧ줸�աC</param>
/// <returns>�ഫ�᪺Base64�r��C</returns>
/// <remarks>
/// ��X�T�w���׬�4���r��C
/// </remarks>
char* Base64::Encode3Bytes(unsigned char *srcBytes)
{
	static char	Output[4 + 1];	// �C3��bytes�|�ഫ��4�Ӥ�r�C
	
	Output[0] = MappingTable[(int)((srcBytes[0] & 0xFC) >> 2)];
	Output[1] = MappingTable[(int)(((srcBytes[0] & 0x03) << 4) + ((srcBytes[1] & 0xF0) >> 4))];
	Output[2] = MappingTable[(int)(((srcBytes[1] & 0x0F) << 2) + ((srcBytes[2] & 0xC0) >> 6))];
	Output[3] = MappingTable[(int)(srcBytes[2] & 0x3F)];
	Output[4] = '\0';

	return Output;
}	// Encode3Bytes();

/// <summary>
/// ��ǤJ���̫᪺2�Ӧ줸���ഫ��4��Base64��r�C
/// </summary>
/// <param name="srcBytes">���V�n�ഫ��2�Ӧ줸�աC</param>
/// <returns>�ഫ�᪺Base64�r��C</returns>
/// <remarks>
/// ��X�T�w���׬�4���r��C
/// </remarks>
char* Base64::Encode2Bytes(unsigned char *srcBytes)
{
	static char	Output[4 + 1];	// �������̫�2��bytes�]�|�ഫ��4�Ӥ�r�C

	// �e2�Ӧr���Ӽ˥άۦP��k���͡C
	Output[0] = MappingTable[(int)((srcBytes[0] & 0xFC) >> 2)];
	Output[1] = MappingTable[(int)(((srcBytes[0] & 0x03) << 4) + ((srcBytes[1] & 0xF0) >> 4))];
	// ��3�Ӧr���u�|�Ψ�̫�1��byte�C
	Output[2] = MappingTable[(int)((srcBytes[1] & 0x0F) << 2)];
	// ��4�Ӧr���ε����Ӱ�padding�C
	Output[3] = '=';
	Output[4] = '\0';

	return Output;
}	// Encode2Bytes();

/// <summary>
/// ��ǤJ���̫᪺1�Ӧ줸���ഫ��4��Base64��r�C
/// </summary>
/// <param name="srcBytes">���V�n�ഫ��1�Ӧ줸�աC</param>
/// <returns>�ഫ�᪺Base64�r��C</returns>
/// <remarks>
/// ��X�T�w���׬�4���r��C
/// </remarks>
char* Base64::Encode1Byte(unsigned char *srcBytes)
{
	static char	Output[4 + 1];	// �������̫�1��byte�]�|�ഫ��4�Ӥ�r�C

	// ��1�Ӧr���Ӽ˥άۦP��k���͡C
	Output[0] = MappingTable[(int)((srcBytes[0] & 0xFC) >> 2)];
	// ��2�Ӧr���u�|�Ψ�̫�1��byte�C	
	Output[1] = MappingTable[(int)((srcBytes[0] & 0x03) << 4)];
	// ��3,4�Ӧr���ε����Ӱ�padding�C
	Output[2] = '=';
	Output[3] = '=';
	Output[4] = '\0';

	return Output;

}	// Encode1Byte();
	
/// <summary>
/// ��ǤJ��4��Base64��r�ഫ�^�������줸�աC
/// </summary>
/// <param name="srcChars">���V�n�ഫ��Base64�r��C</param>
/// <param name="trgBytes">���V�n��m�ഫ���G���Ŷ��C</param>
/// <returns>���G�줸�ժ��ƶq�A�|1�B2��3�C</returns>
int Base64::Decode4Chars(char *srcChars, unsigned char *trgBytes)
{
	static unsigned char outBytes[3];
	int outLen;
	unsigned char idx[4];

	// ����4��Base64�r���ഫ�^4��0~63���Ʀr�C
	for (int i = 0; i < 4; i++)
	{
		idx[i] = 0x00;
		for (int j = 0; j < 64; j++)
		{
			if (MappingTable[j] == srcChars[i])
				idx[i] = j;
		}
	}
	// �A��o���O6�Ӧ줸�զ����Ʀr����^3�Ӧ줸�աC
	outBytes[0] = (idx[0] << 2) + (idx[1] >> 4);
	outBytes[1] = (idx[1] << 4) + (idx[2] >> 2);
	outBytes[2] = (idx[2] << 6) + (idx[3] & 0x3F);
	// �A�ھڭ쥻��4�Ӧr�����ݬO�_���ɦ�r��(=)�A�M�w��ڤW�O1�B2��3�Ӧ줸�աC
	outLen = 3;
	if ('=' == srcChars[3])
	{
		outLen--;
		if ('=' == srcChars[2])
			outLen--;
	}

	for (int i = 0; i < outLen; i++)
		trgBytes[i] = outBytes[i];

	return outLen;
}	// Decode4Chars();

/// <summary>
/// �p��s�X��Base64�᪺�r����סC
/// </summary>
/// <param name="srcLen">��lbinary��ƪ����סC</param>
/// <returns></returns>
int Base64::GetEncodeSize(int srcLen)
{
	int trgLen;

	trgLen = srcLen / 3;		// �C3�Ӧ줸�է@��1�ը��ഫ�A
	if (srcLen > (trgLen * 3))	// �̫�p�G���ѤU1��2�Ӧ줸�աA���|�@��1�աC
		trgLen++;

	return (trgLen * 4);	// �C1���ഫ��4�Ӧr���C
}	// GetEncodeSize();

/// <summary>
/// �p��qBase64�r��ѽX�^�Ӫ���ƪ��סC
/// </summary>
/// <param name="srcLen">��lBase64�r��C</param>
/// <returns></returns>
int Base64::GetDecodeSize(char *srcStr)
{
	int srcLen = strlen(srcStr);
	int trgLen = 0;
	int padLen = 0;

	if (srcLen >= 4)
	{
		trgLen = srcLen / 4;	// �C4�Ӧr���N��1�աC
		// Base64�r�꥽�ݪ�1��2�ӵ����Opadding(�ɨ�3�Ӧ줸�եΪ�)�C
		if ('=' == srcStr[srcLen - 1])
		{
			padLen++;
			if ('=' == srcStr[srcLen - 2])
				padLen++;
		}
	}

	return (trgLen * 3) - padLen;
}	// GetDecodeSize();

/// <summary>
/// ���ƽs�X��Base64�r��C
/// </summary>
/// <param name="srcBytes">���V�n�s�X���줸�աC</param>
/// <param name="srcLen">��l��Ʀ줸�ռơC</param>
/// <param name="trgBuf">���V�n��m�s�X���G���Ŷ��C</param>
/// <returns>
/// =0	: �s�X�����A
/// >0  : �s�X���~�A�Ѿl���s�X�줸�ơC
/// </returns>
int Base64::Encode(unsigned char *srcBytes, int srcLen, char *trgBuf)
{
	unsigned char* srcPos = srcBytes;
	char* trgPos = trgBuf;
	int leftBytes = srcLen;
	char* outChars;

	while (leftBytes > 0)
	{
		// ��C3�Ӧ줸��(�γѤU����3�Ӫ��줸��)�ഫ��4��Base64�r���C
		if (leftBytes >= 3)
		{
			outChars = Encode3Bytes(srcPos);
			srcPos += 3;
			leftBytes -= 3;
		}
		else if (leftBytes > 1)
		{
			// �ѤU�̫�2�Ӧ줸�աC
			outChars = Encode2Bytes(srcPos);
			srcPos += 2;
			leftBytes -= 2;
		}
		else
		{
			// �ѤU�̫�1�Ӧ줸�աC
			outChars = Encode1Byte(srcPos);
			srcPos += 1;
			leftBytes -= 1;
		}
		// ��o4��Base64�r�����쵲�G�����ݡC
		for (int i = 0; i < 4; i++)
		{
			*trgPos = outChars[i];
			trgPos++;
		}
	}
	*trgPos = '\0';

	return leftBytes;
}	// Encode();

/// <summary>
/// ��Base64�r��ѽX�^�쥻���줸�աC
/// </summary>
/// <param name="srcStr">���V�n�ѽX��Base64�r��C</param>
/// <param name="trgBuf">���V�n��m�ѽX���G���Ŷ��C</param>
/// <returns>
/// =0	: �ѽX�����A
/// =-1 : �r����פ��šA
/// =-2 : �r�ꤺ�e���šA
/// >0  : �ѽX���~�A�Ѿl���ѽX�r���ơC
/// </returns>
int Base64::Decode(char *srcStr, unsigned char *trgBuf)
{
	char* srcPos = srcStr;
	int leftBytes = strlen(srcStr);
	unsigned char* trgPos = trgBuf;
	int rc;

	// �ˬd���סA�̤�4�Ӧr���A�r���ƥ����O4�����ơC
	if ((leftBytes < 4) || ((leftBytes % 4) != 0))
		return -1;
	// ���F�̫᭱2�Ӧr���H�~�A�Ҧ��r���������O�X�k��Base64�r���C
	if ('=' == srcStr[leftBytes - 1])
	{
		// �̫�@�Ӧr���O�ɦ�A�˼ƲĤG�ӥi�H�OBase64�r���θɦ�C
		if (('=' != srcStr[leftBytes - 2]) &&
			!IsValidBase64Char(srcStr[leftBytes - 2]))
			return -2;
	}
	else
	{
		// �̫᪺�r�����O�ɦ�A�N����Ӧr�����OBase64�r���C
		if (!IsValidBase64Char(srcStr[leftBytes - 1]) ||
			!IsValidBase64Char(srcStr[leftBytes - 2]))
			return -2;
	}
	for (int i = 0; i < leftBytes - 2; i++)
		if (!IsValidBase64Char(srcStr[i]))
			return -2;

	// �q�Y�}�l�B�z�C�@�q(�C�@�q��4�Ӧr��)�r��C
	while (leftBytes > 0)
	{
		rc = Decode4Chars(srcPos, trgPos);
		leftBytes -= 4;	// �C�@�q��4�Ӧr���C
		srcPos += 4;
		trgPos += rc;	// �i��|���X1�B2��3�Ӧ줸�աC
	}

	return leftBytes;	// �����B�z�����ӷ|�^��0�C
}	// Decode();

