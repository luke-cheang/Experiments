// Main.cpp : This file contains the 'main' function. Program execution begins and ends there.
// 這是用來測試Base64的程式。

#include <iostream>
#include <string.h>
#include "Base64.h"

using namespace std;

int		main(int argc, char *argv[])
{
	int cmd;
	char inbuf[1000 + 1];
	char outbuf[1336 + 1];
	char temp[1024 + 1];
	int size;
	int rc;
	bool done;
	int cnt1, cnt2;
	Base64 *b64 = new Base64();

  #if 0
	// 產生2個位元組的組合，去產生Base64。
	// 再用C#程式去驗證是否相同。
	for (int i = 1; i <= 0xFF; i++)
	{
		for (int j = 1; j <= 0xFF; j++)
		{
			for (int l = 0; l < sizeof(inbuf); l++) inbuf[l] = 0x00;
			for (int l = 0; l < sizeof(outbuf); l++) outbuf[l] = 0x00;
			for (int l = 0; l < sizeof(temp); l++) temp[l] = 0x00;
			inbuf[0] = i;
			inbuf[1] = j;
			rc = b64->Encode((unsigned char *)inbuf, strlen(inbuf), outbuf);
			rc = b64->Decode(outbuf, (unsigned char *)temp);
			cout << outbuf << endl;
		}	// for(j)
	}	// for(i)
	return 0;
  #endif

  #if 0
	// 產生3個位元組的組合，去產生Base64。
	// 再用C#程式去驗證是否相同。
	for (int i = 1; i <= 0xFF; i++)
	{
		for (int j = 1; j <= 0xFF; j++)
		{
			for (int k = 1; k <= 0xFF; k++)
			{
				for (int l = 0; l < sizeof(inbuf); l++) inbuf[l] = 0x00;
				for (int l = 0; l < sizeof(outbuf); l++) outbuf[l] = 0x00;
				for (int l = 0; l < sizeof(temp); l++) temp[l] = 0x00;
				inbuf[0] = i;
				inbuf[1] = j;
				inbuf[2] = k;
				rc = b64->Encode((unsigned char *)inbuf, strlen(inbuf), outbuf);
				rc = b64->Decode(outbuf, (unsigned char *)temp);
				cout << outbuf << endl;
			}	// for(k)
		}	// for(j)
	}	// for(i)
	return 0;
  #endif

	do
	{
		cout << "Base64" << endl;
		cout << "1. Encode" << endl;
		cout << "2. Decode" << endl;
		cout << "3. Encode and decode all 1 byte"  << endl;
		cout << "4. Encode and decode all 2 bytes" << endl;
		cout << "5. Encode and decode all 3 bytes" << endl;
		cout << "0. Quit" << endl;
		cout << "Enter:";
		cin >> cmd;

		switch (cmd)
		{
			case 0:	// 0. Quit
				cout << "Bye." << endl;
				break;

			case 1:	// 1. Encode
				cout << "Input:";
				cin.get();
				cin.getline(inbuf, sizeof(inbuf) - 1);
				cout << endl;
				size = b64->GetEncodeSize(strlen(inbuf));
				cout << "Encoded size = " << size << endl;
				rc = b64->Encode((unsigned char *)inbuf, strlen(inbuf), outbuf);
				cout << "rc =" << rc << endl;
				cout << "Encoded string = " << outbuf << endl;
				cout << "Output size = " << strlen(outbuf) << endl;
				break;

			case 2:	// 2. Decode
				cout << "Input:";
				cin.get();
				cin.getline(inbuf, sizeof(inbuf) - 1);
				cout << endl;
				size = b64->GetDecodeSize(inbuf);
				cout << "Decoded size = " << size << endl;
				for (int i = 0; i < sizeof(outbuf); i++) outbuf[i] = 0x00;
				rc = b64->Decode(inbuf, (unsigned char *)outbuf);
				cout << "rc =" << rc << endl;
				cout << "Decoded string = " << outbuf << endl;
				cout << "Output size = " << strlen(outbuf) << endl;
				break;

			case 3: // 3. Encode and decode all 1 byte.
				cnt1 = 0;
				cnt2 = 0;
				for (int i = 1; i <= 0xFF; i++)
				{
					for (int l = 0; l < sizeof(inbuf);  l++) inbuf[l]  = 0x00;
					for (int l = 0; l < sizeof(outbuf); l++) outbuf[l] = 0x00;
					for (int l = 0; l < sizeof(temp);   l++) temp[l]   = 0x00;
					inbuf[0] = i;
					rc = b64->Encode((unsigned char *)inbuf, strlen(inbuf), outbuf);
					rc = b64->Decode(outbuf, (unsigned char *)temp);
					cnt1++;
					if (strcmp(inbuf, temp) != 0)
					{
						cnt2++;
						cout << outbuf << endl;
					}
				}	// for(i)
				cout << "Total:" << cnt1 << endl;
				cout << "Mismatched:" << cnt2 << endl;
				break;

			case 4: // 4. Encode and decode all 2 bytes.
				cnt1 = 0;
				cnt2 = 0;
				for (int i = 1; i <= 0xFF; i++)
				{
					for (int j = 1; j <= 0xFF; j++)
					{
						for (int l = 0; l < sizeof(inbuf);  l++) inbuf[l]  = 0x00;
						for (int l = 0; l < sizeof(outbuf); l++) outbuf[l] = 0x00;
						for (int l = 0; l < sizeof(temp);   l++) temp[l]   = 0x00;
						inbuf[0] = i;
						inbuf[1] = j;
						rc = b64->Encode((unsigned char *)inbuf, strlen(inbuf), outbuf);
						rc = b64->Decode(outbuf, (unsigned char *)temp);
						cnt1++;
						if (strcmp(inbuf, temp) != 0)
						{
							cnt2++;
							cout << outbuf << endl;
						}
					}	// for(j)
				}	// for(i)
				cout << "Total:" << cnt1 << endl;
				cout << "Mismatched:" << cnt2 << endl;
				break;

			case 5: // 5. Encode and decode all 3 bytes.
				cnt1 = 0;
				cnt2 = 0;
				for (int i = 1; i <= 0xFF; i++)
				{
					for (int j = 1; j <= 0xFF; j++)
					{
						for (int k = 1; k <= 0xFF; k++)
						{
							for (int l = 0; l < sizeof(inbuf); l++) inbuf[l] = 0x00;
							for (int l = 0; l < sizeof(outbuf); l++) outbuf[l] = 0x00;
							for (int l = 0; l < sizeof(temp); l++) temp[l] = 0x00;
							inbuf[0] = i;
							inbuf[1] = j;
							inbuf[2] = k;
							rc = b64->Encode((unsigned char *)inbuf, strlen(inbuf), outbuf);
							rc = b64->Decode(outbuf, (unsigned char *)temp);
							cnt1++;
							if (strcmp(inbuf, temp) != 0)
							{
								cnt2++;
								cout << outbuf << endl;
							}
						}	// for(k)
					}	// for(j)
				}	// for(i)
				cout << "Total:" << cnt1 << endl;
				cout << "Mismatched:" << cnt2 << endl;
				break;

			default:
				break;
		}	// switch
		cout << endl;
	} while (0 != cmd);

	return 0;
}	// main();
