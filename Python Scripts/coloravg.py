import argparse
import numpy as np
from skimage.io import imread, imsave

'''
Tiling an image to given sized sqaure regions and replacing them with the average value of the color channels.

Python 2.7.10 |Anaconda 2.3.0 (64-bit)| (default, May 28 2015, 16:44:52) [MSC v.1500 64 bit (AMD64)] on win32

> python coloravg.py ../Images/portrait.jpg 10 ../Images/portrait_avg_mosaic.jpg
'''

def set_up_and_parse_arguments():
	parser = argparse.ArgumentParser(description = 'Tiling and RGB image.')
	parser.add_argument('inpath', type = str, help = 'Path of input image.')
	parser.add_argument('tile', type = int, help = 'Size of a tile.')
	parser.add_argument('outpath', type = str, help = 'Path of result image.')
	return parser.parse_args()

def compute_avg_mosaic(image, tile_size):
	assert len(image.shape) == 3, 'Shape of input image must have 3 dimensions.'

	avg_mosaic = np.zeros(image.shape, dtype = image.dtype)
	averages_of_channels = np.zeros(image.shape[2])

	for r in np.arange(0, image.shape[0], tile_size):
		for c in np.arange(0, image.shape[1], tile_size):
			current_tile_rows = np.min([tile_size, image.shape[0] - r])
			current_tile_columns = np.min([tile_size, image.shape[1] - c])
			
			for channel in np.arange(0, image.shape[2]):
				range_of_tile = [slice(r, r + current_tile_rows), slice(c, c + current_tile_columns), channel]
				avg_of_channel_inside_a_tile = np.average(image[range_of_tile])
				tile = np.zeros((current_tile_rows, current_tile_columns), dtype = image.dtype)
				tile.fill(int(np.round(avg_of_channel_inside_a_tile)))
				np.copyto(avg_mosaic[range_of_tile], tile)

	return avg_mosaic

if __name__ == '__main__':
	args = set_up_and_parse_arguments()
	
	rgb = imread(args.inpath)
	rgb_mosaic = compute_avg_mosaic(rgb, args.tile)
	imsave(args.outpath, rgb_mosaic)
