using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("api/camps/{moniker}/[controller]")]
    [ApiController]
    public class TalksController : ControllerBase
    {
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public TalksController(ICampRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<TalkModel[]>> Get(string moniker)
        {
            try
            {
                var talks = await _repository.GetTalksByMonikerAsync(moniker, true);
                return _mapper.Map<TalkModel[]>(talks);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get talks for the given moniker");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TalkModel>> Get(string moniker, int id)
        {
            try
            {
                var talk = await _repository.GetTalkByMonikerAsync(moniker, id, true);
                if (talk == null) return NotFound("The talk you're trying to reach was not found");

                return _mapper.Map<TalkModel>(talk);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get talks for the given moniker");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TalkModel>> Post(string moniker, TalkModel model) 
        {
            try
            {
                var camp = await _repository.GetCampAsync(moniker);
                if (camp == null) return BadRequest("Camp does not exist");

                var talk = _mapper.Map<Talk>(model);
                talk.Camp = camp;

                if (model.Speaker == null) return BadRequest("No speaker was given");
                var speaker = await _repository.GetSpeakerAsync(model.Speaker.SpeakerId);

                if (speaker == null) return BadRequest("Speaker could not be found");

                talk.Speaker = speaker;

                _repository.Add(talk);

                if (await _repository.SaveChangesAsync())
                {
                    var url = _linkGenerator.GetPathByAction(HttpContext, "Get", values: new { moniker, id = talk.TalkId });

                    return Created(url, _mapper.Map<TalkModel>(talk));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get talks for the given moniker");
            }

            return BadRequest("Something went wrong. Failed to save the user");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TalkModel>> Put(string moniker, int id, TalkModel model)
        {
            try
            {
                var talk = await _repository.GetTalkByMonikerAsync(moniker, id, true);
                if (talk == null) return NotFound("Couldn't find the talk");

                _mapper.Map(model, talk);

                if (model.Speaker != null)
                {
                    var speaker = await _repository.GetSpeakerAsync(model.Speaker.SpeakerId);
                    if (speaker != null)
                    {
                        talk.Speaker = speaker;
                    }
                }

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<TalkModel>(talk);
                }
                else
                {
                    return BadRequest("Something went wrong. Failed to update");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get talks for the given moniker");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(string moniker, int id)
        {
            try
            {
                var talk = await _repository.GetTalkByMonikerAsync(moniker, id);

                if (talk == null) return NotFound("Failed to find the talk to delete");

                _repository.Delete(talk);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Something went wrong when saving the changes");
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get talks for the given moniker");
            }
        }
    }
}
