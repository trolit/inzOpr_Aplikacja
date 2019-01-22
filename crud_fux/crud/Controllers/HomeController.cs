using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud.Models;

/* 
    Kontroler obsługujący aplikację dla firmy GGKI
    ZMIANA KODU NA WLASNA ODPOWIEDZIALNOSC!
*/

namespace crud.Controllers
{
    public class HomeController : Controller
    {
        // definiowanie powiązań
        private PozwoleniaEntities _db = new PozwoleniaEntities();
        private UczestnicyImprezEntities _db_Uczestnicy = new UczestnicyImprezEntities();
        private ZgloszeniaEntities _db_Zgloszenia = new ZgloszeniaEntities();
        private ImprezyEntities _db_Imprezy = new ImprezyEntities();
        private DokumentacjaEntities _db_Dokumentacja = new DokumentacjaEntities();

        public ActionResult Index()
        {
            return View();
        }

        #region Pracownik

        // widok główny pracownika a zarazem wyświetlenie listy zgłoszeń
        public ActionResult Pracownik()
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(_db_Zgloszenia.Zgloszenia.Where(x => x.stanZgloszenia == "akceptowany").ToList());
        }

        // szczegóły projektu dla pracownika
        public ActionResult Details_Pracownik(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var zgloszenieToDetails = (from Zgloszenia in _db_Zgloszenia.Zgloszenia
                                       where Zgloszenia.idOferty == id
                                       select Zgloszenia).First();
            return View(zgloszenieToDetails);
        }

        #endregion
        #region Uczestnik imprez 

        // widok po zapisaniu na impreze
        public ActionResult Uczestnik_imprezy_Sukces()
        {
            return View();
        }

        // widok z dostępnymi imprezami 
        public ActionResult Imprezy_Dostepne()
        {
            return View(_db_Imprezy.Imprezy.ToList());
        }

        // widok ze szczegółami imprezy
        public ActionResult Imprezy_Details(int id)
        {
            var imprezaToDetails = (from Imprezy in _db_Imprezy.Imprezy
                                    where Imprezy.idImpreza == id
                                    select Imprezy).First();
            return View(imprezaToDetails);
        }

        #region  zapisywanie - uczestnik imprezy [CREATE]
        // GET: Home/Create
        public ActionResult Uczestnik_imprezy_Create()
        {
            return View();
        }

        // POST: /Home/Create
        [HttpPost]
        public ActionResult Uczestnik_imprezy_Create(Uczestnik newUczestnik)
        {
            if (ModelState.IsValid)
            {
                _db_Uczestnicy.Uczestnik.Add(newUczestnik);
                _db_Uczestnicy.SaveChanges();
                return RedirectToAction("Uczestnik_imprezy_Sukces");
            }
            else
            {
                return View(newUczestnik);
            }
        }
        #endregion

        #endregion
        #region Przelozony

        // strona główna - przełożony
        public ActionResult Przelozony()
        {
            if (!User.Identity.IsAuthenticated && !User.IsInRole("Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // lista imprez - widok przełożonego
        public ActionResult Przelozony_Listaimprez()
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(_db_Imprezy.Imprezy.ToList());
        }

        // lista uczestników do ktorej wglad ma przelozony
        public ActionResult Uczestnicy_Lista(int id = 0)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            // jezeli id jest 0 to przypomnij sobie
            if (id == 0)
            {
                id = Convert.ToInt32(Session["idUczestnika"]);
            }

            Session["idUczestnika"] = id;

            return View(_db_Uczestnicy.Uczestnik.Where(x => x.idPorownania == id).ToList());
        }

        // GET: /Home/Edit/5
        public ActionResult Imprezy_Edit(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var imprezaToEdit = (from Imprezy in _db_Imprezy.Imprezy
                                 where Imprezy.idImpreza == id
                                 select Imprezy).First();
            return View(imprezaToEdit);
        }
        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult Imprezy_Edit(int id, Imprezy imprezaToEdit)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                _db_Imprezy.Entry(imprezaToEdit).State = System.Data.Entity.EntityState.Modified;
                _db_Imprezy.SaveChanges();
                return RedirectToAction("Przelozony_Listaimprez");
            }
            return View(imprezaToEdit);
        }

        // widok z usunieciem imprezy (przelozony)
        public ActionResult Imprezy_Delete(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var imprezaToDelete = (from Imprezy in _db_Imprezy.Imprezy
                                   where Imprezy.idImpreza == id
                                   select Imprezy).First();
            return View(imprezaToDelete);
        }

        // POST: /Home/Delete/5
        [HttpPost]
        public ActionResult Imprezy_Delete(int id, Models.Imprezy imprezaToDelete)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var SelImpreza = (from Imprezy in _db_Imprezy.Imprezy
                              where Imprezy.idImpreza ==
                              id
                              select Imprezy).First();
            if (!ModelState.IsValid)
                return View(SelImpreza);
            _db_Imprezy.Imprezy.Remove(SelImpreza);
            _db_Imprezy.SaveChanges();
            return RedirectToAction("Przelozony_Listaimprez");
        }

        // (widok) strona listy zgloszen dla przelozonego
        public ActionResult Zgloszenia_Przelozony()
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(_db_Zgloszenia.Zgloszenia.ToList());
        }

        // ************************
        // EDIT ZGLOSZENIA
        // ************************

        // GET: /Home/Edit/5
        public ActionResult Edit_Przelozony(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var zgloszenieToEdit = (from Zgloszenia in _db_Zgloszenia.Zgloszenia
                                 where Zgloszenia.idOferty == id
                                 select Zgloszenia).First();
            return View(zgloszenieToEdit);
        }

        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult Edit_Przelozony(int id, Zgloszenia zgloszenieToEdit)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                _db_Zgloszenia.Entry(zgloszenieToEdit).State = System.Data.Entity.EntityState.Modified;
                _db_Zgloszenia.SaveChanges();
                return RedirectToAction("Zgloszenia_Przelozony");
            }
            return View(zgloszenieToEdit);
        }

        // ************************
        // DELETE ZGLOSZENIA
        // ************************

        public ActionResult Delete_Przelozony(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var zgloszenieToDelete = (from Zgloszenia in _db_Zgloszenia.Zgloszenia
                                   where Zgloszenia.idOferty == id
                                   select Zgloszenia).First();
            return View(zgloszenieToDelete);
        }

        // POST: /Home/Delete/5
        [HttpPost]
        public ActionResult Delete_Przelozony(int id, Models.Zgloszenia zgloszenieToDelete)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var SelZgloszenie = (from Zgloszenia in _db_Zgloszenia.Zgloszenia
                              where Zgloszenia.idOferty ==
                              id
                              select Zgloszenia).First();
            if (!ModelState.IsValid)
                return View(SelZgloszenie);
            _db_Zgloszenia.Zgloszenia.Remove(SelZgloszenie);
            _db_Zgloszenia.SaveChanges();
            return RedirectToAction("Zgloszenia_Przelozony");
        }


        // ************************
        // DETAILS ZGLOSZENIA
        // ************************

        public ActionResult Details_Przelozony(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var zgloszenieToDetails = (from Zgloszenia in _db_Zgloszenia.Zgloszenia
                                       where Zgloszenia.idOferty == id
                                       select Zgloszenia).First();
            return View(zgloszenieToDetails);
        }

        // SZCZEGÓŁY IMPREZY(JAKO PRZELOZONY)
        public ActionResult Przelozony_Imprezy_Details(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var imprezaToDetails = (from Imprezy in _db_Imprezy.Imprezy
                                    where Imprezy.idImpreza == id
                                    select Imprezy).First();
            return View(imprezaToDetails);
        }

        // ****************************************
        // PRZELOZONY ZARZADZANIE DANYMI UCZESTNIKOW
        // ****************************************

        // edycja
        // GET: /Home/Edit/5
        public ActionResult EditUczestnik(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var uczestnikToEdit = (from Uczestnik in _db_Uczestnicy.Uczestnik
                                 where Uczestnik.idUczestnika == id
                                 select Uczestnik).First();
            return View(uczestnikToEdit);
        }
        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult EditUczestnik(int id, Uczestnik uczestnikToEdit)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                _db_Uczestnicy.Entry(uczestnikToEdit).State = System.Data.Entity.EntityState.Modified;
                _db_Uczestnicy.SaveChanges();
                return RedirectToAction("Przelozony_Listaimprez");
            }
            return View(uczestnikToEdit);
        }

        // usuniecie
        public ActionResult DeleteUczestnik(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var uczestnikToDelete = (from Uczestnik in _db_Uczestnicy.Uczestnik
                                   where Uczestnik.idUczestnika == id
                                   select Uczestnik).First();
            return View(uczestnikToDelete);
        }

        // POST: /Home/Delete/5
        [HttpPost]
        public ActionResult DeleteUczestnik(int id, Models.Uczestnik uczestnikToDelete)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (User.Identity.IsAuthenticated && User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var SelUczestnik = (from Uczestnik in _db_Uczestnicy.Uczestnik
                              where Uczestnik.idUczestnika ==
                              id
                              select Uczestnik).First();
            if (!ModelState.IsValid)
                return View(SelUczestnik);
            _db_Uczestnicy.Uczestnik.Remove(SelUczestnik);
            _db_Uczestnicy.SaveChanges();
            return RedirectToAction("Przelozony_Listaimprez");
        }

        #endregion
        #region Klient

        public ActionResult Klienci()
        {
            return View();
        }

        // (widok) klienta po udanym wyslaniu zgloszenia
        public ActionResult Klient_Sukces()
        {
            return View();
        }
        
        // CREATE zgloszenie (klient)

        // GET: Home/Create
        public ActionResult Create_Zgloszenie()
        {
            return View();
        }

        // POST: /Home/Create
        [HttpPost]
        public ActionResult Create_Zgloszenie(Zgloszenia newZgloszenie)
        {
            if (ModelState.IsValid && !String.IsNullOrEmpty(newZgloszenie.imie_nazwisko) && !String.IsNullOrEmpty(newZgloszenie.nr_telefonu)
                && !String.IsNullOrEmpty(newZgloszenie.mail) && !String.IsNullOrEmpty(newZgloszenie.m_zamieszkania)
                && !String.IsNullOrEmpty(newZgloszenie.nazwa_imprezy) && !String.IsNullOrEmpty(newZgloszenie.rodzaj_tresc)
                && !String.IsNullOrEmpty(newZgloszenie.czas_trwania) && !String.IsNullOrEmpty(newZgloszenie.cyklicznosc)
                && !String.IsNullOrEmpty(newZgloszenie.charakter_uczestnictwa) && !String.IsNullOrEmpty(newZgloszenie.forma_organizacyjna)
                && !String.IsNullOrEmpty(newZgloszenie.cele))
            {
                _db_Zgloszenia.Zgloszenia.Add(newZgloszenie);
                _db_Zgloszenia.SaveChanges();
                return RedirectToAction("Klient_Sukces");
            }
            else
            {
                return View(newZgloszenie);
            }

        }

        #endregion
        #region CRUD [Pozwolenia]

        // (widok) strona pozwolenia(lista)
        public ActionResult Pozwolenia(int id = 0)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            // jezeli id jest 0 to przypomnij sobie
            if (id == 0)
            {
                id = Convert.ToInt32(Session["idOferty"]);
            }

            Session["idOferty"] = id;

            return View(_db.Pozwolenia.Where(x => x.idProjektu == id).ToList());
        }

        // ************************ //
        // DETAILS POZWOLENIA       //
        // ************************ //

        // szuka ID w adresie strony wg reguly:
        // "{controller}/{action}/{id}",

        public ActionResult DetailsPozwolenia(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var ksiazkaToDetails = (from Pozwolenie in _db.Pozwolenia
                                    where Pozwolenie.idPozwolenia == id
                                    select Pozwolenie).First();
            return View(ksiazkaToDetails);
        }


        // ************************ //
        // CREATE POZWOLENIA        //
        // ************************ //

        // GET: Home/Create
        public ActionResult CreatePozwolenie()
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: /Home/Create
        [HttpPost]
        public ActionResult CreatePozwolenie(Pozwolenie newPozwolenie)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid && (newPozwolenie.idProjektu != null) && !String.IsNullOrEmpty(newPozwolenie.nazwa))
            {
                _db.Pozwolenia.Add(newPozwolenie);
                _db.SaveChanges();
                return RedirectToAction("Pozwolenia");
            }
            else
            {
                return View(newPozwolenie);
            }

        }

        // ************************ //
        // EDIT POZWOLENIA          //
        // ************************ //

        // GET: /Home/Edit/5
        public ActionResult EditPozwolenie(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var pozwolenieToEdit = (from Pozwolenie in _db.Pozwolenia
                                    where Pozwolenie.idPozwolenia == id
                                    select Pozwolenie).First();
            return View(pozwolenieToEdit);
        }

        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult EditPozwolenie(int id, Pozwolenie pozwolenieToEdit)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                _db.Entry(pozwolenieToEdit).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Pozwolenia");
            }
            return View(pozwolenieToEdit);
        }


        // ************************ //
        // DELETE POZWOLENIA        //
        // ************************ //

        public ActionResult DeletePozwolenie(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var ksiazkaToDelete = (from Pozwolenie in _db.Pozwolenia
                                   where Pozwolenie.idPozwolenia == id
                                   select Pozwolenie).First();
            return View(ksiazkaToDelete);
        }

        // POST: /Home/DeletePozwolenie
        [HttpPost]
        public ActionResult DeletePozwolenie(int id, Models.Pozwolenie ksiazkaToDelete)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var SelKsiazka = (from Pozwolenie in _db.Pozwolenia
                              where Pozwolenie.idPozwolenia ==
                              id
                              select Pozwolenie).First();
            if (!ModelState.IsValid)
                return View(SelKsiazka);
            _db.Pozwolenia.Remove(SelKsiazka);
            _db.SaveChanges();
            return RedirectToAction("Pozwolenia");
        }
        #endregion
        #region CRUD [Personel]

        private PersonelEntities _db_Personel = new PersonelEntities();
        //
        // GET: /Home/

        public ActionResult Personel(int id = 0)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            // jezeli id jest 0 to przypomnij sobie
            if (id == 0)
            {
                id = Convert.ToInt32(Session["idOferty"]);
            }

            Session["idOferty"] = id;

            return View(_db_Personel.Personel.Where(x => x.idProjektu == id).ToList());
        }

        // *******************************
        // CREATE PERSONEL
        // *******************************

        // GET: Home/Create
        public ActionResult CreatePersonel()
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: /Home/Create
        [HttpPost]
        public ActionResult CreatePersonel(Personel newPersonel)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid && (newPersonel.idProjektu != null) && !String.IsNullOrEmpty(newPersonel.nazwaPersonelu))
            {
                _db_Personel.Personel.Add(newPersonel);
                _db_Personel.SaveChanges();
                return RedirectToAction("Personel");
            }
            else
            {
                return View(newPersonel);
            }

        }

        // *******************************
        // EDIT PERSONEL 
        // *******************************

        // GET: /Home/Edit/5
        public ActionResult EditPersonel(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var personelToEdit = (from Personel in _db_Personel.Personel
                                  where Personel.idPersonelu == id
                                  select Personel).First();
            return View(personelToEdit);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult EditPersonel(int id, Personel personelToEdit)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                _db_Personel.Entry(personelToEdit).State = System.Data.Entity.EntityState.Modified;
                _db_Personel.SaveChanges();
                return RedirectToAction("Personel");
            }
            return View(personelToEdit);
        }

        // *******************************
        // DELETE PERSONEL
        // *******************************

        public ActionResult DeletePersonel(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var personelToDelete = (from Personel in _db_Personel.Personel
                                    where Personel.idPersonelu == id
                                    select Personel).First();
            return View(personelToDelete);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult DeletePersonel(int id, Models.Personel personelToDelete)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var SelPersonel = (from Personel in _db_Personel.Personel
                               where Personel.idPersonelu ==
                               id
                               select Personel).First();
            if (!ModelState.IsValid)
                return View(SelPersonel);
            _db_Personel.Personel.Remove(SelPersonel);
            _db_Personel.SaveChanges();
            return RedirectToAction("Personel");
        }


        // *******************************
        // DETAILS PERSONEL
        // *******************************

        public ActionResult DetailsPersonel(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var personelToDetails = (from Personel in _db_Personel.Personel
                                     where Personel.idPersonelu == id
                                     select Personel).First();
            return View(personelToDetails);
        }
        #endregion
        #region CRUD [Dokumentacja]

        // wylistowanie dokumentacji dla danego projektu
        // GET: /Home/
        public ActionResult Dokumentacja(int id = 0)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            // jezeli id jest 0 to przypomnij sobie
            if (id == 0)
            {
                id = Convert.ToInt32(Session["idOferty"]);
            }

            Session["idOferty"] = id;
            return View(_db_Dokumentacja.Dokumentacja.Where(x => x.idProjektu == id).ToList());
        }

        // *******************************
        // CREATE DOKUMENTACJA
        // *******************************

        // GET: Home/CreateDokumentacja
        public ActionResult CreateDokumentacja()
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: /Home/Create/
        [HttpPost]
        public ActionResult CreateDokumentacja(Dokumentacja newDokumentacja)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid && (newDokumentacja.idProjektu != null) && !String.IsNullOrEmpty(newDokumentacja.nazwaDokumentu))
            {
                _db_Dokumentacja.Dokumentacja.Add(newDokumentacja);
                _db_Dokumentacja.SaveChanges();
                return RedirectToAction("Dokumentacja");
            }
            else
            {
                return View(newDokumentacja);
            }

        }

        // *******************************
        // EDIT DOKUMENTACJA 
        // *******************************


        // GET: /Home/Edit/5
        public ActionResult EditDokumentacja(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var dokumentacjaToEdit = (from Dokumentacja in _db_Dokumentacja.Dokumentacja
                                      where Dokumentacja.idDokumentu == id
                                      select Dokumentacja).First();
            return View(dokumentacjaToEdit);
        }

        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult EditDokumentacja(int id, Dokumentacja dokumentacjaToEdit)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                _db_Dokumentacja.Entry(dokumentacjaToEdit).State = System.Data.Entity.EntityState.Modified;
                _db_Dokumentacja.SaveChanges();
                return RedirectToAction("Dokumentacja");
            }
            return View(dokumentacjaToEdit);
        }


        // *******************************
        // DELETE DOKUMENTACJA
        // *******************************
        public ActionResult DeleteDokumentacja(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var dokumentacjaToDelete = (from Dokumentacja in _db_Dokumentacja.Dokumentacja
                                        where Dokumentacja.idDokumentu == id
                                        select Dokumentacja).First();
            return View(dokumentacjaToDelete);
        }

        // POST: /Home/Delete/5
        [HttpPost]
        public ActionResult DeleteDokumentacja(int id, Models.Dokumentacja dokumentacjaToDelete)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var SelDokumentacja = (from Dokumentacja in _db_Dokumentacja.Dokumentacja
                                   where Dokumentacja.idDokumentu ==
                                   id
                                   select Dokumentacja).First();
            if (!ModelState.IsValid)
                return View(SelDokumentacja);
            _db_Dokumentacja.Dokumentacja.Remove(SelDokumentacja);
            _db_Dokumentacja.SaveChanges();
            return RedirectToAction("Dokumentacja");
        }


        // *******************************
        // DETAILS DOKUMENTACJA
        // *******************************

        public ActionResult DetailsDokumentacja(int id)
        {
            if ((!User.Identity.IsAuthenticated && !User.IsInRole("Administrator")) || (!User.Identity.IsAuthenticated && !User.IsInRole("Pracownik")))
            {
                return RedirectToAction("Index", "Home");
            }

            var dokumentacjaToDetails = (from Dokumentacja in _db_Dokumentacja.Dokumentacja
                                    where Dokumentacja.idDokumentu == id
                                    select Dokumentacja).First();
            return View(dokumentacjaToDetails);
        }
        #endregion
    }
}
