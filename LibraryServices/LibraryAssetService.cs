using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryContext _context;

        public LibraryAssetService(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
               .Include(asset => asset.Status)
               .Include(asset => asset.Location);

        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>()
                 .Where(asset => asset.Id == id).Any();

            var isVideo = _context.LibraryAssets.OfType<Video>()
                .Where(asset => asset.Id == id).Any();

            return isBook ?
                _context.Books.FirstOrDefault(book => book.Id == id).Author :
                _context.Videos.FirstOrDefault(video => video.Id == id).Director
                ?? "Unknown";


        }

        public LibraryAsset GetById(int id)
        {
            return _context.LibraryAssets
               .Include(asset => asset.Status)
               .Include(asset => asset.Location)
               .FirstOrDefault(asset => asset.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            // return GetById(id).Location;
            return _context.LibraryAssets
                  .Include(asset => asset.Status)
                  .Include(asset => asset.Location)
                  .FirstOrDefault(asset => asset.Id == id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books.FirstOrDefault(book => book.Id == id).DeweyIndex;
            }
            
            else return "";
        }

        public string GetISBN(int id)
        {
            if (_context.Books.Any(a => a.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(a => a.Id == id).ISBN;
            }
            else return "";
                      
        }

        public string GetTitle(int id)
        {
           return _context.LibraryAssets
                .FirstOrDefault(b => b.Id == id).Title;
        }

        public string GetType(int id)
        {
           var  book = _context.LibraryAssets.OfType<Book>()
                 .Where(b => b.Id == id);
            return book.Any() ? "Book" : "Video";
        }

    }
}
