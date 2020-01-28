using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDCharacterTracker.Data;
using DnDCharacterTracker.Models;
using DnDCharacterTracker.Services;

namespace DnDCharacterTracker.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ICharacterServices _characterServices;
        private IChoiceServices _choiceServices;
        private IClassServices _classServies;
        public CharactersController(ApplicationDbContext context, ICharacterServices characterServices, IChoiceServices choiceServices, IClassServices classServices)
        {
            _context = context;
            _characterServices = characterServices;
            _choiceServices = choiceServices;
            _classServies = classServices;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Character.Include(c => c.Race);
            foreach (var character in applicationDbContext)
            {
                _characterServices.RetrieveClassIntermediaries(character);
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character character = _characterServices.GetCharacterFromId(id.Value);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            ViewData["FK_Race"] = new SelectList(_context.Races, "Id", "Name");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Strenght,Dexterity,Constitution,Wisdom,Intelligence,Charisma,FK_Race")] Character character)
        {
            //Update the validation during refactoring. Right now there is very little validation in place and this can be harmful in the long run. 
            if (ModelState.IsValid)
            {
                _context.Add(character);

                await _context.SaveChangesAsync();

                ViewData["FK_Race"] = new SelectList(_context.Races, "Id", "Name");

                return View("Details", character);
            }
            ViewData["FK_Race"] = new SelectList(_context.Races, "Id", "Id", character.FK_Race);

            return View(character);
        }

        //Generic controller for all choices actions. Takes several objects right now; can this be combined in a single class? ASP.NET doesn't seem to like sending larger objects between classes; study this. 
        public IActionResult Choice (int Id, ChoicesCollection choicesCollection, List<List<bool>> optionsChosen, List<List<string>> optionsNames, List<List<string>> optionsDescriptions, List<List<int>> OptionIds)
        {
            //Restored the choicecollection from all the loose lists that were send here. 
            for (int i = 0; i < choicesCollection.Choices.Count; i++)
            {
                choicesCollection.Choices[i].OptionNames = optionsNames[i];
                if (optionsDescriptions.Count - 1 > i)
                {
                    choicesCollection.Choices[i].OptionDescriptions = optionsDescriptions[i];
                }
                choicesCollection.Choices[i].OptionsChosen = optionsChosen[i];
                choicesCollection.Choices[i].OptionIds = OptionIds[i];
            }

            _choiceServices.ResolveChoice(Id, choicesCollection);

            //Is this needed? The character get's reconstructed a lot, which might be redundant.
            Character character = _characterServices.GetCharacterFromId(Id);

            return View("Details", character);
        }

        public IActionResult ChooseRace(int Id, int FK_Race)
        {
            Character character = _characterServices.GetCharacterFromId(Id);
            _characterServices.SetCharacterRace(FK_Race, character);

            bool hasChoices = _choiceServices.IsChoiceInRace(character.Race);

            if (hasChoices)
            {
                List<RaceFeature> raceFeatures = _context.RaceRacefeatures.Where(r => r.FK_Race == FK_Race).Select(r => r.RaceFeature).ToList();

                ChoicesCollection choicesCollection = _choiceServices.CreateChoiceCollection(raceFeatures, character);

                return View("ChoiceView", choicesCollection);
            }

            return View("Details", character);
        }

        public async Task<IActionResult> ChooseRaceSetup(int Id)
        {
            Character character = _characterServices.GetCharacterFromId(Id);
            ViewData["FK_Race"] = new SelectList(_context.Races, "Id", "Name", character.FK_Race);

            return View("ChooseRace", character);
        }

        //For both leveling and applying classes. 
        public async Task<IActionResult> ChooseClass(int Id, int ClassId)
        {
            Character character = _characterServices.GetCharacterFromId(Id);

            Class _class = _context.Classes.Where(c => c.Id == ClassId).FirstOrDefault();

            int levelGained = _characterServices.GetClassLevel(character, _class);

            bool hasChoice = _choiceServices.IsChoicesInClass(_class, (levelGained + 1));

            _characterServices.AddCharacterClass(ClassId, character);

            //If a choice is present, reconstruct the different features needed for the choicecollection. 
            if (hasChoice)
                {
                List<Feature> classFeatures = _context.ClassFeatures
                    .Where(f => f.FK_Class == ClassId && f.Level == (levelGained + 1))
                    .Select(f => f.Feature)
                    .ToList();

                classFeatures.AddRange(_context.SubClassFeatures.Where(f => f.SubClass.FK_Class == ClassId && f.Level == (levelGained + 1))
                    .Select(f => f.Feature)
                    .ToList());

                ChoicesCollection choicesCollection = _choiceServices.CreateChoiceCollection(classFeatures, character);

                return View("ChoiceView", choicesCollection);
                }

            return View("Details", character);
        }

        public async Task<IActionResult> ChooseClassSetup(int Id)
        {
            Character character = _characterServices.GetCharacterFromId(Id);
            ViewData["Classes"] = new SelectList(_context.Classes, "Id", "Name", character.Classes);

            ClassSelectionModel classSelectionModel = new ClassSelectionModel { Id = character.Id, ClassId = 0 };

            return View("ChooseClass", classSelectionModel);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["FK_Race"] = new SelectList(_context.Races, "Id", "Id", character.FK_Race);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Strenght,Dexterity,Constitution,Wisdom,Intelligence,Charisma,FK_Race")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_Race"] = new SelectList(_context.Races, "Id", "Id", character.FK_Race);
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .Include(c => c.Race)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Character.FindAsync(id);
            _context.Character.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.Id == id);
        }
    }
}
