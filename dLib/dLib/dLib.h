// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the DLIB_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// DLIB_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef DLIB_EXPORTS
#define DLIB_API __declspec(dllexport)
#else
#define DLIB_API __declspec(dllimport)
#endif

extern DLIB_API int ndLib;

DLIB_API int getNum();

DLIB_API int setNum(int num);

DLIB_API int getStr(wchar_t* outStr);

DLIB_API int setStr(wchar_t* s);

typedef void (__stdcall* CbFunc) ();

DLIB_API void regCbA(CbFunc cb);
DLIB_API void regCbB(CbFunc cb);

DLIB_API void cbEvent(int num);