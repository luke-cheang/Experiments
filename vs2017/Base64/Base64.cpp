#include <string.h>
#include "Base64.h"

/// <summary>
/// 字元轉換對應表。
/// </summary>
/// <remark>
/// Base64是用64個可列印文數字來代表所有的binary data。
/// 使用的文數字包括A~Z, a~z, 0~9, + 和 / 共64個。
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
/// 判斷是否為合法的Base64字元。
/// </summary>
/// <param name="c">要判斷的字元。</param>
/// <returns>true代表是Base64字元。</returns>
/// <remarks>
/// 補空字元(=)不算是合法的Base64字元。
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
/// 把傳入的3個位元組轉換成4個Base64文字。
/// </summary>
/// <param name="srcBytes">指向要轉換的3個位元組。</param>
/// <returns>轉換後的Base64字串。</returns>
/// <remarks>
/// 輸出固定長度為4的字串。
/// </remarks>
char* Base64::Encode3Bytes(unsigned char *srcBytes)
{
	static char	Output[4 + 1];	// 每3個bytes會轉換成4個文字。
	
	Output[0] = MappingTable[(int)((srcBytes[0] & 0xFC) >> 2)];
	Output[1] = MappingTable[(int)(((srcBytes[0] & 0x03) << 4) + ((srcBytes[1] & 0xF0) >> 4))];
	Output[2] = MappingTable[(int)(((srcBytes[1] & 0x0F) << 2) + ((srcBytes[2] & 0xC0) >> 6))];
	Output[3] = MappingTable[(int)(srcBytes[2] & 0x3F)];
	Output[4] = '\0';

	return Output;
}	// Encode3Bytes();

/// <summary>
/// 把傳入的最後的2個位元組轉換成4個Base64文字。
/// </summary>
/// <param name="srcBytes">指向要轉換的2個位元組。</param>
/// <returns>轉換後的Base64字串。</returns>
/// <remarks>
/// 輸出固定長度為4的字串。
/// </remarks>
char* Base64::Encode2Bytes(unsigned char *srcBytes)
{
	static char	Output[4 + 1];	// 末尾的最後2個bytes也會轉換成4個文字。

	// 前2個字元照樣用相同方法產生。
	Output[0] = MappingTable[(int)((srcBytes[0] & 0xFC) >> 2)];
	Output[1] = MappingTable[(int)(((srcBytes[0] & 0x03) << 4) + ((srcBytes[1] & 0xF0) >> 4))];
	// 第3個字元只會用到最後1個byte。
	Output[2] = MappingTable[(int)((srcBytes[1] & 0x0F) << 2)];
	// 第4個字元用等號來做padding。
	Output[3] = '=';
	Output[4] = '\0';

	return Output;
}	// Encode2Bytes();

/// <summary>
/// 把傳入的最後的1個位元組轉換成4個Base64文字。
/// </summary>
/// <param name="srcBytes">指向要轉換的1個位元組。</param>
/// <returns>轉換後的Base64字串。</returns>
/// <remarks>
/// 輸出固定長度為4的字串。
/// </remarks>
char* Base64::Encode1Byte(unsigned char *srcBytes)
{
	static char	Output[4 + 1];	// 末尾的最後1個byte也會轉換成4個文字。

	// 第1個字元照樣用相同方法產生。
	Output[0] = MappingTable[(int)((srcBytes[0] & 0xFC) >> 2)];
	// 第2個字元只會用到最後1個byte。	
	Output[1] = MappingTable[(int)((srcBytes[0] & 0x03) << 4)];
	// 第3,4個字元用等號來做padding。
	Output[2] = '=';
	Output[3] = '=';
	Output[4] = '\0';

	return Output;

}	// Encode1Byte();
	
/// <summary>
/// 把傳入的4個Base64文字轉換回對應的位元組。
/// </summary>
/// <param name="srcChars">指向要轉換的Base64字串。</param>
/// <param name="trgBytes">指向要放置轉換結果的空間。</param>
/// <returns>結果位元組的數量，會1、2或3。</returns>
int Base64::Decode4Chars(char *srcChars, unsigned char *trgBytes)
{
	static unsigned char outBytes[3];
	int outLen;
	unsigned char idx[4];

	// 先把4個Base64字元轉換回4個0~63的數字。
	for (int i = 0; i < 4; i++)
	{
		idx[i] = 0x00;
		for (int j = 0; j < 64; j++)
		{
			if (MappingTable[j] == srcChars[i])
				idx[i] = j;
		}
	}
	// 再把這都是6個位元組成的數字換算回3個位元組。
	outBytes[0] = (idx[0] << 2) + (idx[1] >> 4);
	outBytes[1] = (idx[1] << 4) + (idx[2] >> 2);
	outBytes[2] = (idx[2] << 6) + (idx[3] & 0x3F);
	// 再根據原本的4個字元末端是否有補位字元(=)，決定實際上是1、2或3個位元組。
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
/// 計算編碼成Base64後的字串長度。
/// </summary>
/// <param name="srcLen">原始binary資料的長度。</param>
/// <returns></returns>
int Base64::GetEncodeSize(int srcLen)
{
	int trgLen;

	trgLen = srcLen / 3;		// 每3個位元組作為1組來轉換，
	if (srcLen > (trgLen * 3))	// 最後如果有剩下1或2個位元組，都會作為1組。
		trgLen++;

	return (trgLen * 4);	// 每1組轉換成4個字元。
}	// GetEncodeSize();

/// <summary>
/// 計算從Base64字串解碼回來的資料長度。
/// </summary>
/// <param name="srcLen">原始Base64字串。</param>
/// <returns></returns>
int Base64::GetDecodeSize(char *srcStr)
{
	int srcLen = strlen(srcStr);
	int trgLen = 0;
	int padLen = 0;

	if (srcLen >= 4)
	{
		trgLen = srcLen / 4;	// 每4個字元代表1組。
		// Base64字串末端的1或2個等號是padding(補足3個位元組用的)。
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
/// 把資料編碼成Base64字串。
/// </summary>
/// <param name="srcBytes">指向要編碼的位元組。</param>
/// <param name="srcLen">原始資料位元組數。</param>
/// <param name="trgBuf">指向要放置編碼結果的空間。</param>
/// <returns>
/// =0	: 編碼完成，
/// >0  : 編碼錯誤，剩餘未編碼位元數。
/// </returns>
int Base64::Encode(unsigned char *srcBytes, int srcLen, char *trgBuf)
{
	unsigned char* srcPos = srcBytes;
	char* trgPos = trgBuf;
	int leftBytes = srcLen;
	char* outChars;

	while (leftBytes > 0)
	{
		// 把每3個位元組(或剩下不足3個的位元組)轉換成4個Base64字元。
		if (leftBytes >= 3)
		{
			outChars = Encode3Bytes(srcPos);
			srcPos += 3;
			leftBytes -= 3;
		}
		else if (leftBytes > 1)
		{
			// 剩下最後2個位元組。
			outChars = Encode2Bytes(srcPos);
			srcPos += 2;
			leftBytes -= 2;
		}
		else
		{
			// 剩下最後1個位元組。
			outChars = Encode1Byte(srcPos);
			srcPos += 1;
			leftBytes -= 1;
		}
		// 把這4個Base64字元接到結果的末端。
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
/// 把Base64字串解碼回原本的位元組。
/// </summary>
/// <param name="srcStr">指向要解碼的Base64字串。</param>
/// <param name="trgBuf">指向要放置解碼結果的空間。</param>
/// <returns>
/// =0	: 解碼完成，
/// =-1 : 字串長度不符，
/// =-2 : 字串內容不符，
/// >0  : 解碼錯誤，剩餘未解碼字元數。
/// </returns>
int Base64::Decode(char *srcStr, unsigned char *trgBuf)
{
	char* srcPos = srcStr;
	int leftBytes = strlen(srcStr);
	unsigned char* trgPos = trgBuf;
	int rc;

	// 檢查長度，最少4個字元，字元數必須是4的倍數。
	if ((leftBytes < 4) || ((leftBytes % 4) != 0))
		return -1;
	// 除了最後面2個字元以外，所有字元都必須是合法的Base64字元。
	if ('=' == srcStr[leftBytes - 1])
	{
		// 最後一個字元是補位，倒數第二個可以是Base64字元或補位。
		if (('=' != srcStr[leftBytes - 2]) &&
			!IsValidBase64Char(srcStr[leftBytes - 2]))
			return -2;
	}
	else
	{
		// 最後的字元不是補位，代表末兩個字元都是Base64字元。
		if (!IsValidBase64Char(srcStr[leftBytes - 1]) ||
			!IsValidBase64Char(srcStr[leftBytes - 2]))
			return -2;
	}
	for (int i = 0; i < leftBytes - 2; i++)
		if (!IsValidBase64Char(srcStr[i]))
			return -2;

	// 從頭開始處理每一段(每一段為4個字元)字串。
	while (leftBytes > 0)
	{
		rc = Decode4Chars(srcPos, trgPos);
		leftBytes -= 4;	// 每一段為4個字元。
		srcPos += 4;
		trgPos += rc;	// 可能會產出1、2或3個位元組。
	}

	return leftBytes;	// 全部處理完應該會回傳0。
}	// Decode();

