#include "stdafx.h"

#include "ImageDisplay.h"

using namespace std;

int main(int argc, char** argv)
{
	LibraryCLRWrapper::ImageDisplay imageDisplay;
	imageDisplay.Display("C:\\Users\\Dave\\Pictures\\car1.png");

	return 0;
}