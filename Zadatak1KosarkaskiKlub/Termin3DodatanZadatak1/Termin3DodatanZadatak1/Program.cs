﻿using System;
using System.Collections.Generic;
using System.Linq;
using Termin3DodatanZadatak1.Models;

namespace Termin3DodatanZadatak1
{
    class Program
    {
        public static List<Klub> ListaKlubova = new List<Klub>();
        public static List<Sudija> ListaSudija = new List<Sudija>();
        public static List<Utakmica> ListaUtakmica = new List<Utakmica>();

        static void Main(string[] args)
        {
            Meni opcije;
            LoadData();

            do
            {
                MeniTekst();

                Enum.TryParse(Console.ReadLine(), out opcije);

                switch (opcije)
                {
                    case Meni.ispisiKlubove:
                        IspisiKlubove();
                        break;

                    case Meni.dodajKlub:
                        DodajKlub();
                        break;

                    case Meni.obrisiKlub:
                        ObrisiKlub();
                        break;

                    case Meni.izmeniKlub:
                        IzmeniKlub();
                        break;

                    case Meni.ispisiIgraceIzKluba:
                        IspisIgracaIzKluba();
                        break;

                    case Meni.izmeniIgraceIzKluba:
                        IzmeniIgraceIzKluba();
                        break;

                    case Meni.obrisiIgraceIzKluba:
                        ObrisiIgraca();
                        break;

                    case Meni.sudije:
                        MeniSudije();
                        break;

                    case Meni.utakmice:
                        Utakmice();
                        break;

                    case Meni.izlaz:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Uneta opcija ne postoji!");
                        break;
                }

            } while (opcije != Meni.izlaz);

            Console.ReadLine();
        }

        public static void MeniTekst()
        {
            Console.WriteLine("1.Ispisi klubove");
            Console.WriteLine("2.Dodaj klub");
            Console.WriteLine("3.Obrisi klub");
            Console.WriteLine("4.Izmeni klub");
            Console.WriteLine("5.Ispisi igrace iz kluba");
            Console.WriteLine("6.Izmeni igrace iz kluba");
            Console.WriteLine("7.Obrisi igraca iz kluba");
            Console.WriteLine("8.Meni za sudije");
            Console.WriteLine("9.Utakmice");
            Console.WriteLine("0.Izlaz");
            Console.Write("Unos:");
        }

        public static void IspisiKlubove()
        {
            Console.Clear();
            foreach (Klub klub in ListaKlubova)
            {
                Console.WriteLine(klub.SifraKluba + " " + klub.NazivKluba);
            }
        }

        public static void SudijeTekst()
        {
            Console.WriteLine("1.Ispisi sve sudije!");
            Console.WriteLine("2.Izmeni sudije");
            Console.WriteLine("3.Obrisi sudije");
            Console.Write("Unos:");
        }

        public static void DodajKlub()
        {
            Console.Clear();
            int sifraKluba = 0;
            string nazivKluba;

            Console.Write("Unesite sifru kluba:");
            sifraKluba = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite naziv kluba:");
            nazivKluba = Console.ReadLine();

            int doMeni = 1;
            do
            {
                int sifraIgracaAdd;
                string imeIgracaAdd;
                string prezimeIgracaAdd;

                Console.WriteLine("Sada mozete unosite igrace u klub,a kada zavrsite upise 0");

                Console.Write("Unesite sifru igraca:");
                sifraIgracaAdd = Convert.ToInt32(Console.ReadLine());
                Console.Write("Unesite ime igraca:");
                imeIgracaAdd = Console.ReadLine();
                Console.Write("Unesite prezime igraca:");
                prezimeIgracaAdd = Console.ReadLine();

                Igrac igrTempAdd = new Igrac { SifraIgraca = sifraIgracaAdd, ImeIgraca = imeIgracaAdd, PrezimeIgraca = prezimeIgracaAdd };

                Klub addKlub = new Klub();
                addKlub.SifraKluba = sifraKluba;
                addKlub.NazivKluba = nazivKluba;
                addKlub.ListaIgraca.Add(igrTempAdd);
                ListaKlubova.Add(addKlub);

                Console.Write("Upisite 0 ukoliko ste zavrsili dodavanje,a 1 da nastavite:");
                doMeni = Convert.ToInt32(Console.ReadLine());

            } while (doMeni != 0);

            Console.WriteLine("Uspesno ste dodali klub!");
        }

        public static void LoadData()
        {
            Klub klb1 = new Klub { SifraKluba = 63624, NazivKluba = "Zvezda" };
            Igrac igr1 = new Igrac { SifraIgraca = 19, ImeIgraca = "Bogdan", PrezimeIgraca = "Bogdanovic" };
            klb1.ListaIgraca.Add(igr1);

            Klub klb2 = new Klub { SifraKluba = 33212, NazivKluba = "Partizan" };
            Igrac igr2 = new Igrac { SifraIgraca = 42, ImeIgraca = "Marjan", PrezimeIgraca = "Marjanovic" };
            klb2.ListaIgraca.Add(igr2);

            Sudija sudj1 = new Sudija { SifraSudije = 5462, ImeSudije = "Boban", PrezimeSudije = "Jovanovic" };
            Sudija sudj2 = new Sudija { SifraSudije = 7487, ImeSudije = "Djordje", PrezimeSudije = "Simic" };

            ListaSudija.Add(sudj1);

            Utakmica utkm1 = new Utakmica { SifraUtakmice = 5735, VremeUtakmice = new DateTime(2019, 05, 30, 19, 38, 40), BrojKosevaGostiju = 5, BrojKosevaDomacina = 5, ListaSudija = ListaSudija, DomaciKlub = klb1, GostujuciKlub = klb2 };

            ListaSudija.Add(sudj2);

            Utakmica utkm2 = new Utakmica { SifraUtakmice = 3337, VremeUtakmice = new DateTime(2019, 10, 31, 12, 55, 00), BrojKosevaGostiju = 60, BrojKosevaDomacina = 10, ListaSudija = ListaSudija, DomaciKlub = klb2, GostujuciKlub = klb1 };

            //Dodavanje utakmica
            ListaUtakmica.Add(utkm1);
            ListaUtakmica.Add(utkm2);

            //Dodovanje klubova i igraca
            ListaKlubova.Add(klb1);
            ListaKlubova.Add(klb2);
        }

        public static void Utakmice()
        {
            Console.Clear();

            int izabirMeniUtakmice;

            Console.WriteLine("1.Prikazi sve utakmice");
            Console.WriteLine("2.Prikazi utakmicu pomocu sifre");
            Console.WriteLine("3.Izmeni utakmicu");
            Console.WriteLine("4.Obrisi utakmicu");
            Console.WriteLine("5.Kreiraj utakmicu");
            Console.Write("Unos:");

            izabirMeniUtakmice = Convert.ToInt32(Console.ReadLine());

            switch (izabirMeniUtakmice)
            {
                case 1:
                    Console.Clear();
                    foreach (Utakmica ukmList in ListaUtakmica)
                    {
                        Console.Write("Sifra utakmice:" + ukmList.SifraUtakmice + "\n" + "Vreme utakmice:" + ukmList.VremeUtakmice + "\n" + "Broj koseva gostiju:" + ukmList.BrojKosevaGostiju + "\n" + "Broj koseva domacina:" + ukmList.BrojKosevaDomacina + "\n" + "Domaci klub:" + ukmList.DomaciKlub.NazivKluba + "\n" + "Gostujuci klub:" + ukmList.GostujuciKlub.NazivKluba + "\n" + "Sudija:" + ukmList.ListaSudija.FirstOrDefault().ImeSudije + " " + ukmList.ListaSudija.FirstOrDefault().PrezimeSudije + "\n");
                    }
                    break;

                case 2:
                    Console.Clear();

                    int sifraUtakmiceSelektovanje;
                    Console.Write("Unesite sifru utakmice koju zelite da ispisite:");
                    sifraUtakmiceSelektovanje = Convert.ToInt32(Console.ReadLine());

                    foreach (Utakmica ukmList in ListaUtakmica)
                    {
                        if (sifraUtakmiceSelektovanje == ukmList.SifraUtakmice)
                        {
                            Console.Write("Sifra utakmice:" + ukmList.SifraUtakmice + "\n" + "Vreme utakmice:" + ukmList.VremeUtakmice + "\n" + "Broj koseva gostiju:" + ukmList.BrojKosevaGostiju + "\n" + "Broj koseva domacina:" + ukmList.BrojKosevaDomacina + "\n" + "Domaci klub:" + ukmList.DomaciKlub.NazivKluba + "\n" + "Gostujuci klub:" + ukmList.GostujuciKlub.NazivKluba + "\n" + "Sudija:" + ukmList.ListaSudija.FirstOrDefault().ImeSudije + " " + ukmList.ListaSudija.FirstOrDefault().PrezimeSudije + "\n");
                            Console.WriteLine();
                        }
                    }
                    break;

                case 3:
                    Console.Clear();

                    int sifraUtakmiceZaIzmenu;
                    Console.Write("Unesite sifru utakmice koju zelite da izmenite:");
                    sifraUtakmiceZaIzmenu = Convert.ToInt32(Console.ReadLine());

                    //Promenjlive za izmenu
                    DateTime novoVremeUtakmice;
                    int noviBrojKosevaDomacina;
                    int noviBrojKosevaGostiju;
                    int novaSifraUtakmice;
                    //obj
                    Sudija noviSudija = new Sudija();

                    Console.Write("Unesite vreme utakmice:");
                    DateTime.TryParse(Console.ReadLine(), out novoVremeUtakmice);

                    Console.Write("Unesite novu sifru utakmice:");
                    novaSifraUtakmice = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Unesite novi broj koseva domacina:");
                    noviBrojKosevaDomacina = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Novi broj koseva gostiju:");
                    noviBrojKosevaGostiju = Convert.ToInt32(Console.ReadLine());

                    foreach (Sudija sudija in ListaSudija)
                    {
                        Console.WriteLine(sudija.SifraSudije + " " + sudija.ImeSudije + " " + sudija.PrezimeSudije);
                    }

                    int sifraSudije;

                    Console.Write("Sada unesite sifru sudije:");

                    sifraSudije = Convert.ToInt32(Console.ReadLine());

                    foreach (Sudija sudija in ListaSudija)
                    {
                        if (sudija.SifraSudije == sifraSudije)
                        {
                            noviSudija = sudija;
                        }
                    }

                    List<Sudija> novaListaSudija = new List<Sudija>();
                    novaListaSudija.Add(noviSudija);

                    Utakmica utakmicaEdit = new Utakmica { SifraUtakmice = novaSifraUtakmice, VremeUtakmice = novoVremeUtakmice, BrojKosevaDomacina = noviBrojKosevaDomacina, BrojKosevaGostiju = noviBrojKosevaGostiju, ListaSudija = novaListaSudija};

                    for (int i = 0; i < ListaUtakmica.Count; i++)
                    {
                        if (ListaUtakmica[i].SifraUtakmice == sifraUtakmiceZaIzmenu)
                        {
                            ListaUtakmica[i] = utakmicaEdit;
                        }
                    }
                    break;

                case 4:
                    int sifraUtakmiceZaBrisanje;
                    Console.Write("Unesite sifru utakmice koju zelite da obrisete:");
                    sifraUtakmiceZaBrisanje = Convert.ToInt32(Console.ReadLine());
                    bool success = FindAndDeleteUtakmicu(sifraUtakmiceZaBrisanje);

                    if (success)
                    {
                        Console.WriteLine("Uspesno ste obrisali utakmicu!");
                    }
                    else
                    {
                        Console.WriteLine("Greska prilikom brisanja!");
                    }

                    break;

                case 5:
                    //Promenjive
                    int addSifraUtakmice;
                    DateTime addVremeUtakmice;
                    int addBrojKosevaDomacina;
                    int addBrojKosevaGostiju;

                    int sifraDomacegKlubaSelektovanje;
                    int sifraGostujucegKlubaSelektovanje;
                    int sifraSudijeSelektovanje;
                    //obj
                    Klub domaciKlubAdd = new Klub();
                    Klub gostujuciKlubAdd = new Klub();
                    Sudija sudijaAdd = new Sudija();

                    Console.Write("Unesite sifru utakmice:");
                    addSifraUtakmice = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Unesite vreme utakmice:");
                    DateTime.TryParse(Console.ReadLine(), out addVremeUtakmice);

                    Console.Write("Unesite sifru domaceg kluba:");
                    foreach (Klub klub in ListaKlubova)
                    {
                        Console.WriteLine(klub.SifraKluba + " " + klub.NazivKluba);
                    }

                    Console.Write("Unos:");
                    sifraDomacegKlubaSelektovanje = Convert.ToInt32(Console.ReadLine());

                    foreach (Klub klub in ListaKlubova)
                    {
                        if (klub.SifraKluba == sifraDomacegKlubaSelektovanje)
                        {
                            domaciKlubAdd = klub;
                        }
                    }

                    Console.Write("Unesite broj koseva domaceg kluba,a ako nema upiste 0:");
                    addBrojKosevaDomacina = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Unesite sifru gostujuceg kluba:");

                    foreach (Klub klub in ListaKlubova)
                    {
                        Console.WriteLine(klub.SifraKluba + " " + klub.NazivKluba);
                    }

                    Console.Write("Unos:");
                    sifraGostujucegKlubaSelektovanje = Convert.ToInt32(Console.ReadLine());

                    foreach (Klub klub in ListaKlubova)
                    {
                        if (klub.SifraKluba == sifraGostujucegKlubaSelektovanje)
                        {
                            gostujuciKlubAdd = klub;
                        }
                    }

                    Console.Write("Unesite broj koseva gostucujeg kluba,a ako nema upiste 0:");
                    addBrojKosevaGostiju = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Unesite sifru sudije");

                    foreach (Sudija sudija in ListaSudija)
                    {
                        Console.WriteLine(sudija.SifraSudije + " " + sudija.ImeSudije + " " + sudija.PrezimeSudije);
                    }

                    sifraSudijeSelektovanje = Convert.ToInt32(Console.ReadLine());

                    foreach (Sudija sudija in ListaSudija)
                    {
                        if (sudija.SifraSudije == sifraSudijeSelektovanje)
                        {
                            sudijaAdd = sudija;
                        }
                    }

                    List<Sudija> novaListaSudija2 = new List<Sudija>();

                    novaListaSudija2.Add(sudijaAdd);

                    Utakmica utakmicaAdd = new Utakmica { SifraUtakmice = addSifraUtakmice, VremeUtakmice = addVremeUtakmice, DomaciKlub = domaciKlubAdd, BrojKosevaDomacina = addBrojKosevaDomacina, GostujuciKlub = gostujuciKlubAdd, BrojKosevaGostiju = addBrojKosevaGostiju, ListaSudija = novaListaSudija2 };

                    ListaUtakmica.Add(utakmicaAdd);

                    break;
                default:
                    break;
            }
        }

        public static bool FindAndDeleteUtakmicu(int idUtakmice)
        {
            foreach (Utakmica utakmica in ListaUtakmica)
            {
                if (utakmica.SifraUtakmice == idUtakmice)
                {
                    ListaUtakmica.Remove(utakmica);
                    return true;
                }
            }
            return false;
        }

        public static void ObrisiKlub()
        {
            Console.Clear();
            Console.Write("Unesite sifru kluba kojeg zelite da obrisete:");
            int sifraKlubaBrisanje;
            sifraKlubaBrisanje = Convert.ToInt32(Console.ReadLine());
            bool success = FindAndDeleteClub(sifraKlubaBrisanje);

            if (success)
            {
                Console.WriteLine("Klub je uspesno obrisan!");
            }
            else
            {
                Console.WriteLine("Klub nije obrisan!");
            }

        }

        public static void IzmeniKlub()
        {
            Console.Clear();

            int sifraIzmena;
            int sifraIzmena2;
            string imeIzmena;

            Console.Write("Unesite sifru kluba koji zelite da izmenite:");
            sifraIzmena = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite novu sifru kluba:");
            sifraIzmena2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite novo ime kluba:");
            imeIzmena = Console.ReadLine();

            foreach (Klub klbList in ListaKlubova)
            {
                if (klbList.SifraKluba == sifraIzmena)
                {
                    klbList.SifraKluba = sifraIzmena2;
                    klbList.NazivKluba = imeIzmena;
                }
            }
        }

        public static void IspisIgracaIzKluba()
        {
            Console.Clear();

            int sifraIspis;

            Console.WriteLine("Unesite sifru kluba u kojem zelite da ispisite igrace");
            Console.Write("Sifra:");

            sifraIspis = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Igraci:");

            foreach (Klub klub in ListaKlubova)
            {
                if (klub.SifraKluba == sifraIspis)
                {
                    foreach (Igrac igrac in klub.ListaIgraca)
                    {

                        Console.WriteLine(igrac.SifraIgraca + " " + igrac.ImeIgraca + " " + igrac.PrezimeIgraca);
                    }
                }
            }
        }

        public static void IzmeniIgraceIzKluba()
        {
            Console.Clear();
            int sifraIgracaIzmena;
            int sifraKlubaIzmena;

            Console.Write("Unesite sifru kluba kojem zelite da izmenite igrace:");
            sifraKlubaIzmena = Convert.ToInt32(Console.ReadLine());

            Console.Write("Sada unesite sifru igraca:");
            sifraIgracaIzmena = Convert.ToInt32(Console.ReadLine());

            int novaSifraIgraca;
            string novoImeIgraca;
            string novoPrezimeIgraca;

            for (int i = 0; i < ListaKlubova.Count; i++)
            {
                if (sifraKlubaIzmena == ListaKlubova[i].SifraKluba)
                {
                    for (int j = 0; j < ListaKlubova[i].ListaIgraca.Count; j++)
                    {
                        if (ListaKlubova[i].ListaIgraca[j].SifraIgraca == sifraIgracaIzmena)
                        {
                            Console.Write("Unesite novu sifru igraca:");
                            novaSifraIgraca = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Unesite novo ime igraca:");
                            novoImeIgraca = Console.ReadLine();
                            Console.Write("Unesite novo prezime igraca:");
                            novoPrezimeIgraca = Console.ReadLine();

                            Igrac igrEdit = new Igrac { SifraIgraca = novaSifraIgraca, ImeIgraca = novoImeIgraca, PrezimeIgraca = novoPrezimeIgraca };

                            ListaKlubova[i].ListaIgraca[j] = igrEdit;
                        }
                    }
                }
            }
        }

        public static void ObrisiIgraca()
        {
            int sifraIgracaBrisanje;
            int sifraKlubaIgraca;

            Console.Write("Unesite sifru kluba u kojem igrac igra:");
            sifraKlubaIgraca = Convert.ToInt32(Console.ReadLine());

            Console.Write("Sada unesite sifru igraca koje zelite da obrisete:");
            sifraIgracaBrisanje = Convert.ToInt32(Console.ReadLine());

            FindAndDeletePlayer(sifraIgracaBrisanje, sifraKlubaIgraca);
        }

        public static bool FindAndDeletePlayer(int idIgraca, int idKluba)
        {
            foreach (Klub klub in ListaKlubova)
            {
                if (klub.SifraKluba == idKluba)
                {
                    foreach (Igrac igrac in klub.ListaIgraca)
                    {
                        if (igrac.SifraIgraca == idIgraca)
                        {
                            klub.ListaIgraca.Remove(igrac);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool FindAndDeleteClub(int clubId)
        {
            foreach (Klub klub in ListaKlubova)
            {
                if (klub.SifraKluba == clubId)
                {
                    ListaKlubova.Remove(klub);
                    return true;
                }
            }
            return false;
        }

        public static void MeniSudije()
        {
            Console.Clear();
            SudijeTekst();
            int sudijeMeni;
            sudijeMeni = Convert.ToInt32(Console.ReadLine());

            switch (sudijeMeni)
            {
                case 1:
                    foreach (Sudija sdjList in ListaSudija)
                    {
                        Console.WriteLine("Sifra:" + sdjList.SifraSudije + " Ime:" + sdjList.ImeSudije + " Prezime:" + sdjList.PrezimeSudije);
                    }
                    break;

                case 2:
                    int editSifraSudije;
                    string novoImeSudije;
                    string novoPrezimeSudije;

                    Console.Write("Unesite sifru sudije:");
                    editSifraSudije = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Unesite novo ime sudije:");
                    novoImeSudije = Console.ReadLine();

                    Console.Write("Unesite novo prezime sudije:");
                    novoPrezimeSudije = Console.ReadLine();

                    foreach (Sudija sdjList in ListaSudija)
                    {
                        if (editSifraSudije == sdjList.SifraSudije)
                        {
                            sdjList.ImeSudije = novoImeSudije;
                            sdjList.PrezimeSudije = novoPrezimeSudije;
                        }
                    }
                    break;

                case 3:
                    int sifraSudijeDelete;

                    Console.Write("Unesite sifru sudije kojeg zelite da obrisite:");
                    sifraSudijeDelete = Convert.ToInt32(Console.ReadLine());

                    bool success = FindAndDeleteClub(sifraSudijeDelete);

                    if (success)
                    {
                        Console.WriteLine("Sudija je uspesno obrisan!");
                    }
                    else
                    {
                        Console.WriteLine("Sudija nije obrisan!");
                    }

                    break;
                default:
                    break;
            }
        }

        public static bool FindAndDeleteSudije(int idSudije)
        {
            foreach (Sudija sudija in ListaSudija)
            {
                if (sudija.SifraSudije == idSudije)
                {
                    ListaSudija.Remove(sudija);
                    return true;
                }
            }
            return false;
        }

        public enum Meni
        {
            ispisiKlubove = 1,
            dodajKlub = 2,
            obrisiKlub = 3,
            izmeniKlub = 4,
            ispisiIgraceIzKluba = 5,
            izmeniIgraceIzKluba = 6,
            obrisiIgraceIzKluba = 7,
            sudije = 8,
            utakmice = 9,
            izlaz = 0
        };
    }
}
