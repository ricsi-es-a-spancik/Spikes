import argparse
import numpy as np
from os import listdir
from os.path import isfile, join
from skimage.color import rgb2lab, deltaE_cie76, deltaE_ciede2000, deltaE_ciede94, deltaE_cmc
from skimage.io import imread
from skimage.transform import resize

'''
Analyzing the changes in averages of color channels between an original size image and it's resized version.

Python 2.7.10 |Anaconda 2.3.0 (64-bit)| (default, May 28 2015, 16:44:52) [MSC v.1500 64 bit (AMD64)] on win32

python shrinkcolorchange.py ../ColourLib 0.2
'''

def set_up_and_parse_arguments():
	parser = argparse.ArgumentParser(description = 'Detect changings in average colors when shrinking an RGB image.')
	parser.add_argument('dir', type = str, help = 'Path of a directory containing an image library.')
	parser.add_argument('ration', type = float, help = 'Shrinking ratio.')
	return parser.parse_args() 

def get_files_from_image_library(directory):
	dir_list = [join(directory, f) for f in listdir(directory)]
	files_in_dir = [path for path in dir_list if isfile(path)]
	return files_in_dir

def get_averages_of_channels(image):
	return np.array([np.round(np.average(image[:,:,ch])) for ch in range(0, image.shape[2])])

def compute_distances_between_colors(rgb1, rgb2):
	lab1 = rgb2lab(np.reshape(rgb1, (1, 1, 3)))
	lab2 = rgb2lab(np.reshape(rgb2, (1, 1, 3)))
	distances = np.array([
		deltaE_cie76(lab1, lab2),
		deltaE_ciede2000(lab1, lab2),
		deltaE_ciede94(lab1, lab2),
		deltaE_cmc(lab1, lab2)])
	return np.reshape(distances, (4))

def analyze_images_at_shrinking(image_paths, ratio):
	for path in image_paths:
		image = imread(path)
		assert len(image.shape) == 3, 'Shape of input image must have 3 dimensions.'

		avg_original = get_averages_of_channels(image)
		shape_to_resize = np.round(np.asarray(image.shape)[:2] * ratio)
		shrinked_image = resize(image, shape_to_resize, preserve_range = True)
		avg_resized = get_averages_of_channels(shrinked_image)
		are_averages_the_same = np.all(avg_original == avg_resized)
		distance = compute_distances_between_colors(avg_original, avg_resized)

		print('{0}\t{1}\t{2}\t{3}\t{4}'.format(path, avg_original, avg_resized, are_averages_the_same, distance))

if __name__ == '__main__':
	args = set_up_and_parse_arguments()
	image_paths = get_files_from_image_library(args.dir)
	analyze_images_at_shrinking(image_paths, args.ration)
