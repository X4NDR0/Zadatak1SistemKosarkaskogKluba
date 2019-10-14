﻿using System;
using System.Collections.Generic;
using System.Linq;
using Termin3DodatanZadatak1.Models;

namespace Termin3DodatanZadatak1
{
    class Program
    {
        public static List<Klub> klbList = new List<Klub>();
        public static List<Sudija> sdjList = new List<Sudija>();
        public static List<Utakmica> ukmList = new List<Utakmica>();

        static void Main(string[] args)
        {
            Meni opcije;


            LoadData();


            do
            {
                do
                {
                    MeniTekst();
                } while (Enum.TryParse(Console.ReadLine(), out opcije) == false);


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
            foreach (Klub klub in klbList)
            {
                Console.WriteLine(klub.sifraKluba + " " + klub.nazivKluba);
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
                addKlub.sifraKluba = sifraKluba;
                addKlub.nazivKluba = nazivKluba;
                addKlub.igrList.Add(igrTempAdd);
                klbList.Add(addKlub);

                Console.Write("Upisite 0 ukoliko ste zavrsili dodavanje,a 1 da nastavite:");
                doMeni = Convert.ToInt32(Console.ReadLine());

            } while (doMeni != 0);



            Console.WriteLine("Uspesno ste dodali klub!");
        }


        public static void LoadData()
        {
            Klub klb1 = new Klub { sifraKluba = 63624, nazivKluba = "Zvezda" };
            Igrac igr1 = new Igrac { SifraIgraca = 19, ImeIgraca = "Bogdan", PrezimeIgraca = "Bogdanovic" };
            klb1.igrList.Add(igr1);


            Klub klb2 = new Klub { sifraKluba = 33212, nazivKluba = "Partizan" };
            Igrac igr2 = new Igrac { SifraIgraca = 42, ImeIgraca = "Marjan", PrezimeIgraca = "Marjanovic" };
            klb2.igrList.Add(igr2);


            Sudija sudj1 = new Sudija { SifraSudije = 5462, ImeSudije = "Boban", PrezimeSudije = "Jovanovic" };
            Sudija sudj2 = new Sudija { SifraSudije = 7487, ImeSudije = "Djordje", PrezimeSudije = "Simic" };

            Utakmica utkm1 = new Utakmica { SifraUtakmice = 5735, VremeUtakmice = new DateTime(2019, 5, 10, 19, 38, 40), BrojKosevaGostiju = 5, BrojKosevaDomacina = 5, sdj = sudj1 };
            Utakmica utkm2 = new Utakmica { SifraUtakmice = 3337, VremeUtakmice = new DateTime(2019, 1, 1, 12, 55, 00), BrojKosevaGostiju = 60, BrojKosevaDomacina = 10, sdj = sudj2 };

            //Dodavanje utakmica
            ukmList.Add(utkm1);
            ukmList.Add(utkm2);

            //Dodovanje klubova i igraca
            klbList.Add(klb1);
            klbList.Add(klb2);

            //Dodavanje sudija
            sdjList.Add(sudj1);
            sdjList.Add(sudj2);
        }

        public static void Utakmice()
        {
            Console.Clear();

            int izabirMeniUtakmice;

            Console.WriteLine("1.Prikazi sve utakmice");
            Console.WriteLine("2.Prikazi utakmicu pomocu sifre");
            Console.WriteLine("3.Izmeni utakmicu");
            Console.WriteLine("4.Obrisi utakmicu");
            Console.Write("Unos:");

            izabirMeniUtakmice = Convert.ToInt32(Console.ReadLine());

            switch (izabirMeniUtakmice)
            {
                case 1:
                    Console.Clear();
                    foreach (Utakmica ukmList in ukmList)
                    {
                        Console.Write("Sifra utakmice:" + ukmList.SifraUtakmice + "\n" + "Vreme utakmice:" + ukmList.VremeUtakmice + "\n" + "Broj koseva gostiju:" + ukmList.BrojKosevaGostiju + "\n" + "Broj koseva domacina:" + ukmList.BrojKosevaDomacina + "\n" + "Sudija:" + ukmList.sdj.ImeSudije + " " + ukmList.sdj.PrezimeSudije + "\n");
                    }
                    break;

                case 2:
                    Console.Clear();

                    int sifraUtakmiceSelektovanje;
                    Console.Write("Unesite sifru utakmice koju zelite da ispisite:");
                    sifraUtakmiceSelektovanje = Convert.ToInt32(Console.ReadLine());

                    foreach (Utakmica ukmList in ukmList)
                    {
                        if (sifraUtakmiceSelektovanje == ukmList.SifraUtakmice)
                        {
                            Console.Write("Sifra utakmice:" + ukmList.SifraUtakmice + "\n" + "Vreme utakmice:" + ukmList.VremeUtakmice + "\n" + "Broj koseva gostiju:" + ukmList.BrojKosevaGostiju + "\n" + "Broj koseva domacina:" + ukmList.BrojKosevaDomacina + "\n" + "Sudija:" + ukmList.sdj + " " + ukmList.sdj.PrezimeSudije + "\n");
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

                    foreach (Sudija sudija in sdjList)
                    {
                        Console.WriteLine(sudija.SifraSudije + " " + sudija.ImeSudije + " " + sudija.PrezimeSudije);
                    }

                    int sifraSudije;

                    Console.Write("Sada unesite sifru sudije:");

                    sifraSudije = Convert.ToInt32(Console.ReadLine());

                    foreach (Sudija sudija in sdjList)
                    {
                        if (sudija.SifraSudije == sifraSudije)
                        {
                            noviSudija = sudija;
                        }
                    }

                    Utakmica utakmicaEdit = new Utakmica { SifraUtakmice = novaSifraUtakmice, BrojKosevaDomacina = noviBrojKosevaDomacina, BrojKosevaGostiju = noviBrojKosevaGostiju, sdj = noviSudija };

                    for (int i = 0; i < ukmList.Count; i++)
                    {
                        if (ukmList[i].SifraUtakmice == sifraUtakmiceZaIzmenu)
                        {
                            ukmList[i] = utakmicaEdit;
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
                    }else
                    {
                        Console.WriteLine("Greska prilikom brisanja!");
                    }

                    break;


                default:
                    break;

            }
        }

        public static bool FindAndDeleteUtakmicu(int idUtakmice)
        {
            foreach  (Utakmica utakmica in ukmList)
            {
                if (utakmica.SifraUtakmice == idUtakmice)
                {
                    ukmList.Remove(utakmica);
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

            foreach (Klub klbList in klbList)
            {
                if (klbList.sifraKluba == sifraIzmena)
                {
                    klbList.sifraKluba = sifraIzmena2;
                    klbList.nazivKluba = imeIzmena;
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


            foreach (Klub klub in klbList)
            {
                if (klub.sifraKluba == sifraIspis)
                {
                    foreach (Igrac igrac in klub.igrList)
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

            for (int i = 0; i < klbList.Count; i++)
            {
                if (sifraKlubaIzmena == klbList[i].sifraKluba)
                {
                    for (int j = 0; j < klbList[i].igrList.Count; j++)
                    {
                        if (klbList[i].igrList[j].SifraIgraca == sifraIgracaIzmena)
                        {
                            Console.Write("Unesite novu sifru igraca:");
                            novaSifraIgraca = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Unesite novo ime igraca:");
                            novoImeIgraca = Console.ReadLine();
                            Console.Write("Unesite novo prezime igraca:");
                            novoPrezimeIgraca = Console.ReadLine();

                            Igrac igrEdit = new Igrac { SifraIgraca = novaSifraIgraca, ImeIgraca = novoImeIgraca, PrezimeIgraca = novoPrezimeIgraca };

                            klbList[i].igrList[j] = igrEdit;
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
            foreach (Klub klub in klbList)
            {
                if (klub.sifraKluba == idKluba)
                {
                    foreach (Igrac igrac in klub.igrList)
                    {
                        if (igrac.SifraIgraca == idIgraca)
                        {
                            klub.igrList.Remove(igrac);
                            return true;
                        }
                    }
                }
            }
            return false;
        }



        public static bool FindAndDeleteClub(int clubId)
        {
            foreach (Klub klub in klbList)
            {
                if (klub.sifraKluba == clubId)
                {
                    klbList.Remove(klub);
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
                    foreach (Sudija sdjList in sdjList)
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

                    foreach (Sudija sdjList in sdjList)
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

                    break;



                default:
                    break;
            }

        }


        public static bool FindAndDeleteSudije(int idSudije)
        {
            foreach (Sudija sudija in sdjList)
            {
                if (sudija.SifraSudije == idSudije)
                {
                    sdjList.Remove(sudija);
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
