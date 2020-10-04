using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocApi.Models;
using DocApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public DocumentsController(DocumentService documentService)
        {
            _documentService = documentService;
        }
        [HttpGet]
        public ActionResult<List<Document>> Get() =>
                _documentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetDocument")]
        public ActionResult<Document> Get(string id)
        {
            var book = _documentService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Document> Create(Document document)
        {
            _documentService.Create(document);

            return CreatedAtRoute("GetDocument", new { id = document.DocumentId.ToString() }, document);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Document bookIn)
        {
            var book = _documentService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _documentService.Update(id, bookIn);

            return NoContent();
        }
    }
}
