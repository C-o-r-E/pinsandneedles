// dLib.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "dLib.h"


// This is an example of an exported variable
DLIB_API int ndLib=0;

int dNum = 0;
wchar_t dStr[32] = L"Test\0";

CbFunc managedCBA;
CbFunc managedCBB;
//void (*managedCBA)();
//void (*managedCBB)();


// This is an example of an exported function.
DLIB_API int getNum()
{
	return dNum;
}

DLIB_API int setNum(int num)
{
	dNum = num;
	return 0;
}

DLIB_API int getStr(wchar_t * outStr)
{
	//wchar_t fake[] = L"this is a test.\0";
	lstrcpyW(outStr, dStr);
	//strcpy_s(outStr, 32, fake);
	return 32;
}

DLIB_API int setStr(wchar_t * s)
{
	lstrcpyW(dStr, s);
	//strcpy_s(dStr, 32, s);
	return 0;
}

DLIB_API void regCbA(CbFunc cb)
{
	managedCBA = cb;
}

DLIB_API void regCbB(CbFunc cb)
{
	managedCBB = cb;
}

DLIB_API void cbEvent(int num)
{
	if(num == 42)
	{
		managedCBA();
	}
	else
	{
		managedCBB();
	}
}
