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
		~ImageDisplay();
	private:
		Library::ImageDisplay* _imageDisplay;
	};
}
