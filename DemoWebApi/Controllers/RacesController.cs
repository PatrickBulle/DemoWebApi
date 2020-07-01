using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoWebApi.ContextDB;
using DemoWebApi.Models;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly MonAppliDbContext _context;

        public RacesController(MonAppliDbContext context)
        {
            _context = context;
        }

        // GET: api/Races
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetDbRaces()
        {
            // Ne retourne que les races ayant le COSU à 0
            return await _context.DbRaces.Where(r => r.CodeSupression.Equals("0")).ToListAsync();
        }

        // GET: api/Races/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(string id)
        {
            
            var race = await _context.DbRaces.FirstOrDefaultAsync(r => r.CodeRaceBovin.Equals(id) && r.CodeSupression.Equals("0"));

            if (race == null)
            {
                return NotFound();
            }

            return race;
        }

        // PUT: api/Races/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(string id, Race race)
        {
            if (id != race.CodeRaceBovin)
            {
                return BadRequest();
            }

            _context.PrepareModification(race, true);
            _context.Entry(race).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Races
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Race>> PostRace(Race race)
        {
            _context.PrepareModification(race);
            _context.DbRaces.Add(race);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RaceExists(race.CodeRaceBovin))
                {
                    _context.Entry(race).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetRace", new { id = race.CodeRaceBovin }, race);
        }

        // DELETE: api/Races/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Race>> DeleteRace(string id)
        {
            var race = await _context.DbRaces.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }

            _context.PrepareSuppression(race);
            await _context.SaveChangesAsync();

            return race;
        }

        private bool RaceExists(string id)
        {
            return _context.DbRaces.Any(e => e.CodeRaceBovin == id);
        }
    }
}
