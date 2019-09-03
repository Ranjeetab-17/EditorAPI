using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EditorAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EditorAPI.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        [HttpGet,Route("")]
        public ActionResult GetContent()
        {
            Log.Verbose("Editor API called");

            try
            {
                var text = System.IO.File.ReadAllText(@"DITAs/template.dita");
                text.ToHtml(@"XMLs/input.xml", @"XMLs/output.xml");

                var result = System.IO.File.ReadAllText("XMLs/output.xml");
                throw new Exception("Error occured");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return Ok();
        }
    }
}