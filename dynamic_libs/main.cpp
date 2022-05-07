#include <Windows.h>
int main() {
  HINSTANCE load = LoadLibrary(L"DynamicLibrary.dll");
  typedef int (*sum) (int, int);
  sum Sum = (sum)GetProcAddress(load, "sum");
  // ... //
  FreeLibrary(load);
}
