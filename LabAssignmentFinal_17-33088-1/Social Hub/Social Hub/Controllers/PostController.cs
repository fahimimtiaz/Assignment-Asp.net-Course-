using Social_Hub.Repository;
using Social_Hub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Social_Hub.Controllers
{
    [RoutePrefix("api/Posts")]
    public class PostController : ApiController
    {
        PostRepository postRepo = new PostRepository();

        [Route("")]

        //Get All Post
        public IHttpActionResult Get()
        {

            return Ok(postRepo.GetAll()); 
        }

        //Get a Specific Post
        [Route("{id}", Name = "GetPostById")]
        public IHttpActionResult Get(int id)
        {
            Post pst = postRepo.GetById(id);

            if (pst == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            pst.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:14006/api/Posts/" + pst.PostId, HttpMethod = "GET", Relation = "Self" });
            pst.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:14006/api/Posts", HttpMethod = "POST", Relation = "Create a new Post resource" });
            pst.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:14006/api/Posts/" + pst.PostId, HttpMethod = "PUT", Relation = "Edit a existing post resource" });
            pst.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:14006/api/Posts/" + pst.PostId, HttpMethod = "DELETE", Relation = "Delete a existing Post resource" });
            return Ok(pst);
        }


        //Create A Post
        [Route("")]
        public IHttpActionResult Post(Post pst)
        {
            postRepo.Insert(pst);
            string url = Url.Link("GetPostById", new { id = pst.PostId });
            return Created(url,pst);
        }

        //Edit a post
        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Post pst, [FromUri]int id)
        {
            pst.PostId = id;
            postRepo.Edit(pst);
            return Ok(pst);
        }

        //Delete a Post
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            postRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }     


    }
}
