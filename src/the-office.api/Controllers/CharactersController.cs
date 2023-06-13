﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using the_office.api.application.Characters.Messaging.Requests;
using the_office.api.application.Characters.Messaging.Response;
using the_office.api.application.Episodes.Messaging.Requests;
using the_office.api.application.Episodes.Messaging.Responses;
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

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CharacterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<Result<CharacterResponse>> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetCharacterByIdRequest(id);
        return await Sender.Send(request, cancellationToken);
    }

    [HttpGet]
    [Route("GetAll")]
    public ActionResult Index()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ObjectResponse), StatusCodes.Status201Created)]
    [SwaggerResponseExample(StatusCodes.Status422UnprocessableEntity, typeof(ValidationResponseModelExamples))]
    [SwaggerResponseExample(StatusCodes.Status201Created, typeof(CharacterModelExample))]
    public async Task<Result<CharacterResponse>> RegisterAsync([FromBody] RegisterCharacterRequest request)
    {
        return await Sender.Send(request);
    }
}