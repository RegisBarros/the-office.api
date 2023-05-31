﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using the_office.api.application.Characters.Messaging.Requests;
using the_office.api.ModelExamples;
using the_office.domain.Response;
using the_office.domain.Shared;

namespace the_office.api.Controllers;

[ApiController]
[Route("character")]
public class CharactersController : ApiController
{
    public CharactersController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet]
    [Route("GetAll")]
    public ActionResult Index()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("add")]
    [ProducesResponseType(typeof(ObjectResponse), StatusCodes.Status422UnprocessableEntity)]
    [SwaggerResponseExample(StatusCodes.Status422UnprocessableEntity, typeof(ValidationResponseModelExamples))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(NotFoundErrorModelExample))]
    [ProducesResponseType(typeof(ObjectResponse), StatusCodes.Status201Created)]
    [SwaggerResponseExample(StatusCodes.Status201Created, typeof(CharacterModelExample))]
    public async Task<IActionResult> PostCharacterAsync([FromBody] InsertCharacterRequest request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }
}