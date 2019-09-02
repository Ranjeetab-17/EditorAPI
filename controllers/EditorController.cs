using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EditorAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EditorAPI.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetContent()
        {
            var text = System.IO.File.ReadAllText(@"DITAs/template.dita");
            text.ToHtml(@"",@"");
            return Ok("Editor Works...");
        }
    }
}