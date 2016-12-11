// This is the main DLL file.

#include "stdafx.h"
#include <msclr\marshal_cppstd.h>

#include "ImageDisplay.h"

namespace LibraryCLRWrapper {

	ImageDisplay::ImageDisplay()
	{
		_imageDisplay = new Library::ImageDisplay();
	}

	void ImageDisplay::Display(System::String^ imagePath)
	{
		msclr::interop::marshal_context context;
		std::string standardImagePart = context.marshal_as<std::string>(imagePath);

		_imageDisplay->Display(standardImagePart);
	}

	ImageDisplay::~ImageDisplay()
	{
		delete _imageDisplay;
		_imageDisplay = 0;
	}
}

