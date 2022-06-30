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
	int size;
	int rc;
	Base64 *b64 = new Base64();

	do
	{
		cout << "Base64" << endl;
		cout << "1. Encode" << endl;
		cout << "2. Decode" << endl;
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

			default:
				break;
		}	// switch
		cout << endl;
	} while (0 != cmd);

	return 0;
}	// main();
