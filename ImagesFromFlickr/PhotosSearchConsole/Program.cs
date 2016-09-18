using FlickrNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhotosSearchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // API Key and secret for Mozaic
            var flickr = new Flickr("86d7596ef5548c8a082e8f4c45b47614", "383a46399c655e00");

            // Searching
            var options = new PhotoSearchOptions {
                Text = "red",
                PerPage = 20,
                Page = 1,
                Extras = PhotoSearchExtras.OriginalUrl
            };

            PhotoCollection photos = flickr.PhotosSearch(options);

            foreach (var photo in photos)
            {
                Console.WriteLine($"Photo {photo.PhotoId} has title {photo.Title}.");
                Console.WriteLine($" {photo.WebUrl}");

                //if (photo.OriginalUrl != null)
                //{
                //    Console.WriteLine("  Downloading photo...");
                //    DownloadPhoto(photo);
                //}
            }

            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();
        }

        private static void DownloadPhoto(Photo photo)
        {
            var destinationDirectory = @"photos";
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            var destinationpath = $@"photos\{photo.PhotoId}.jpg";
            using (var client = new WebClient())
            {
                client.DownloadFile(photo.OriginalUrl, destinationpath);
            }

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(photo.ThumbnailUrl);
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //// Check that the remote file was found. The ContentType
            //// check is performed since a request for a non-existent
            //// image file might be redirected to a 404-page, which would
            //// yield the StatusCode "OK", even though the image was not
            //// found.
            //if ((response.StatusCode == HttpStatusCode.OK ||
            //    response.StatusCode == HttpStatusCode.Moved ||
            //    response.StatusCode == HttpStatusCode.Redirect) &&
            //    response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            //{

            //    // if the remote file was found, download oit
            //    using (Stream inputStream = response.GetResponseStream())
            //    using (Stream outputStream = File.OpenWrite(destinationpath))
            //    {
            //        byte[] buffer = new byte[4096];
            //        int bytesRead;
            //        do
            //        {
            //            bytesRead = inputStream.Read(buffer, 0, buffer.Length);
            //            outputStream.Write(buffer, 0, bytesRead);
            //        } while (bytesRead != 0);
            //    }
            //}
        }
    }
}
