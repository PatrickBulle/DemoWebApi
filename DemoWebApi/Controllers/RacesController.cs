﻿using System;
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

        /// <summary>
        /// Retourne toutes les races actives
        /// </summary>
        /// <returns>Liste de races</returns>
        // GET: api/Races
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetDbRaces()
        {
            // Ne retourne que les races ayant le COSU à 0
            return await _context.DbRaces.Where(r => r.CodeSupression.Equals("0")).ToListAsync();
        }

        /// <summary>
        /// Retourne toutes les races actives et désactivées
        /// </summary>
        /// <returns>Liste de race</returns>
        // GET: api/GetAllRaces
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetDbAllRaces()
        {
            // Ne retourne que les races ayant le COSU à 0
            return await _context.DbRaces.ToListAsync();
        }

        /// <summary>
        /// Retourne le détail d'une race dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La race demandée si elle existe</returns>
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

        /// <summary>
        /// Met à jour une race dont l'id est passé en paramètre avec les données contenues dans le paramètre race
        /// </summary>
        /// <param name="id"></param>
        /// <param name="race"></param>
        /// <returns>Aucun retour</returns>
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

        /// <summary>
        /// Ajout d'une race dans la base de données
        /// </summary>
        /// <param name="race"></param>
        /// <returns>La race créée</returns>
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

        /// <summary>
        /// Suppression logique (cosu mis à 1) de la race identifiée par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Le détail e la race supprimée</returns>
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
