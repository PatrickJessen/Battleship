#include <windows.h>

int main()
{
	while (1)
	{
		for (int i = 0; i < 255; i++)
			if (GetAsyncKeyState(i) & 0x8000)
				LockWorkStation();
	}
}