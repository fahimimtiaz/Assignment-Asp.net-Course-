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

    [RoutePrefix("api/Posts/{id}/Comments")]
    public class CommentController : ApiController
    {

        //CommentRepository commentRepo = new CommentRepository();

        CommentRepository cRepo = new CommentRepository(); 
        PostRepository pRepo = new PostRepository();

        //Get All Comment
        [Route("")]
        public IHttpActionResult Get(int id)
        {
            
            return Ok(pRepo.GetCommentsByPost(id));
        }

        //Get a Specific Comment
        [Route("{id2}", Name = "GetCommentById")]
        public IHttpActionResult Get(int id,int id2)
        {
            List<Comment> cmt = pRepo.GetCommentsByPost(id);
            Comment comment = cRepo.GetById(id2);
            bool check = false;
            foreach (var item in cmt)
            {
                if (item.CommentId == comment.CommentId)
                    check = true; 
            }

            if (comment == null || check==false)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(comment);
        }

        //Create a Comment for a Post
        [Route("")]
        public IHttpActionResult Post(Comment com)
        {
            cRepo.Insert(com);
            string url = Url.Link("GetCommentById", new { id = com.CommentId , id2 =com.PostId });
            return Created(url, com);
        }

        //Edit a Comment
        [Route("{id2}")]
        public IHttpActionResult Put([FromBody]Comment com,int id,int id2)
        {
            //List<Comment> cmt = pRepo.GetCommentsByPost(id);
            //Comment comment = cRepo.GetById(id2);
            //bool check = false;
            //foreach (var item in cmt)
            //{
            //    if (item.CommentId == comment.CommentId)
            //        check = true;
            //}

            //if(check == false)
            //{
            //    return StatusCode(HttpStatusCode.NoContent);
            //}

            com.CommentId = id2;
            cRepo.Edit(com);
            return Ok(com);
        }

        //Delete a Comment
        [Route("{id2}")]
        public IHttpActionResult Delete(int id,int id2)
        {
            List<Comment> cmt = pRepo.GetCommentsByPost(id);
            Comment comment = cRepo.GetById(id2);
            bool check = false;
            foreach (var item in cmt)
            {
                if (item.CommentId == comment.CommentId)
                    check = true;
            }

            if (check == false)
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }

            cRepo.Delete(id2);
            return StatusCode(HttpStatusCode.NoContent);
        }





    }
}
