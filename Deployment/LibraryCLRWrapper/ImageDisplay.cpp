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
		std::string standardImagePath = context.marshal_as<std::string>(imagePath);
		
		_imageDisplay->Display(standardImagePath);
	}

	array<byte>^ ImageDisplay::GetByteArray()
	{
		array<byte>^ ret = gcnew array<byte>(5);
		
		for (int i = 0; i < 5; ++i)
		{
			ret[i] = i * 11;
		}
		
		return ret;
	}

	ImageDisplay::~ImageDisplay()
	{
		delete _imageDisplay;
		_imageDisplay = 0;
	}
}

