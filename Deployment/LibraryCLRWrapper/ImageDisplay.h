// LibraryCLRWrapper.h

#pragma once

#include "../Library/ImageDisplay.h"

using namespace System;

namespace LibraryCLRWrapper {

	public ref class ImageDisplay
	{
	public:
		ImageDisplay();
		void Display(System::String^ imagePath);
		array<byte>^ GetByteArray();
		~ImageDisplay();
	private:
		Library::ImageDisplay* _imageDisplay;
	};
}
