#pragma once

#include <string>

namespace Library {

	class ImageDisplay
	{
	public:
		ImageDisplay();
		void Display(std::string imagePath);
		~ImageDisplay();
	};
}