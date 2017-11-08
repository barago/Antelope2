using Antelope.Models.Test;
using Antelope.Repositories.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Antelope.Controllers.Test
{
    public class ReviewsController : ApiController
    {

        //private ICategoriesRepository _categoriesRepository { get; set; }
        public ReviewRepository _reviewRepository { get; set; }

        public ReviewsController(/*IReviewRepository reviewRepository/*, ICategoriesRepository categoriesRepository*/)
        {
           //_reviewRepository = reviewRepository;
           // _categoriesRepository = categoriesRepository;

            _reviewRepository = new ReviewRepository();
        }

        // GET api/review
        public IEnumerable<Review> Get()
        {
            //_reviewRepository = new ReviewRepository();
            var reviews = _reviewRepository.GetAll();
            return reviews;
        }

        // GET api/review/5
        public HttpResponseMessage Get(int id)
        {
            var category = _reviewRepository.Get(id);
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        // POST api/review
        public HttpResponseMessage Post(Review review)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, review);
            // Get the url to retrieve the newly created review.
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("reviews/{0}", review.Id));
            _reviewRepository.Add(review);
            return response;
        }

        // PUT api/review/5
        public void Put(Review review)
        {
            _reviewRepository.Update(review);
        }

        // DELETE api/review/5
        public HttpResponseMessage Delete(int id)
        {
            _reviewRepository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // GET api/reviews/categories/{category}
       /* public HttpResponseMessage GetByCategory(string category)
        {

            var findCategory = _categoriesRepository.GetByName(category);
            if (findCategory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, _reviewRepository.GetByCategory(findCategory));
        } */

        // GET api/reviews/comments/{id}
        //[HttpGet]
        //public HttpResponseMessage GetReviewComments(int id)
        //{

        //    var reviewComments = _reviewRepository.GetReviewComments(id);
        //    if (reviewComments == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, reviewComments);
        //}




    }
}




/*

        // GET api/reviews
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/reviews/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/reviews
        public void Post([FromBody]string value)
        {
        }

        // PUT api/reviews/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/reviews/5
        public void Delete(int id)
        {
        }

*/