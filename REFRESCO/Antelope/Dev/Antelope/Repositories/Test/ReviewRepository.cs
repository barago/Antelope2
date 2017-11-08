using Antelope.Models;
using Antelope.Models.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Antelope.Repositories.Test
{
    public class ReviewRepository : IReviewRepository
    {
        public TestContext _db { get; set; }

        public ReviewRepository() : this(new TestContext())
        {

        }

        public ReviewRepository(TestContext db)
        {
            _db = db;
        }

        public Review Get(int id)
        {
            return _db.Reviews.SingleOrDefault(r => r.Id == id);
        }

        public IQueryable<Review> GetAll()
        {
            return _db.Reviews;
        }

        public Review Add(Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return review;
        }

        public Review Update(Review review)
        {
            _db.Entry(review).State = EntityState.Modified;
            _db.SaveChanges();
            return review;
        }

        public void Delete(int reviewId)
        {
            var review = Get(reviewId);
            _db.Reviews.Remove(review);
        }

        public IEnumerable<Review> GetByCategory(Category category)
        {
            return _db.Reviews.Where(r => r.CategoryId == category.Id);
        }

        public IEnumerable<Comment> GetReviewComments(int id)
        {
            return _db.Comments.Where(c => c.ReviewId == id);
        }



    }
}