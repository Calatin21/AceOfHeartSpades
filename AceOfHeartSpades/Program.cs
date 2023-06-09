﻿namespace AceOfHeartSpades {
    internal class Program {
        static void Spiel(Stack<Karte> karten) {           
            Hand bank = new Hand();
            Hand spieler = new Hand();
            bool running = true;
            bool spielerZieht = true;
            string antwort;
            bank.karten.Add(karten.Pop());
            bank.karten.Add(karten.Pop());
            spieler.karten.Add(karten.Pop());
            spieler.karten.Add(karten.Pop());
            while (running) {
                Console.Clear();
                if (spieler.Wert() > 21) {
                    spielerZieht = false;
                    running = false;
                }
                else if (spieler.Wert() == 21) {
                    spielerZieht = false;
                }
                Console.WriteLine($"Die Bank hat: {bank.karten[0].PrintKarte()} + verdeckte Karte");
                Console.WriteLine($"{bank.karten[0].Wertigkeit()} Punkte + X");
                Console.WriteLine();
                Console.WriteLine($"Du hast: {spieler.PrintHand()} ");
                Console.WriteLine($"{spieler.Wert()} Punkte");
                Console.WriteLine("");
                if (spielerZieht) {
                    Console.WriteLine("Möchtest Du:\n1) Neue Karte\n2) Keine neue Karte");
                    antwort = Console.ReadLine();
                    if (antwort == "1") {
                        spieler.karten.Add(karten.Pop());
                    }
                    else if (antwort == "2") {
                        spielerZieht = false;
                    }
                    else {
                        Console.WriteLine("Bitte 1 oder 2 eingeben!!!");
                    }
                }
                if (spielerZieht == false) {
                    if (bank.Wert() < 16) {
                        bank.karten.Add(karten.Pop());
                        Console.WriteLine("Bank zieht eine Karte");
                        Console.Read();
                    }
                    else {
                        running = false;
                    }
                }
            }
            string winner = null;
            int sieger, verlierer;
            if (spieler.Wert() == bank.Wert() || spieler.Wert() > 21 && bank.Wert() > 21) {
                winner = "Niemand";
            }
            else if (spieler.Wert() > 21) {
                winner = "Bank";
            }
            else if (bank.Wert() > 21) {
                winner = "Spieler";
            }
            else if (spieler.Wert() == 21) {
                winner = "Spieler";
            }
            else if (spieler.Wert() > bank.Wert()) {
                winner = "Spieler";
            }
            else {
                winner = "Bank";
            }
            if (winner == "Bank") {
                sieger = bank.Wert();
                verlierer = spieler.Wert();
            }
            else {
                sieger = spieler.Wert();
                verlierer = bank.Wert();
            }
            Console.WriteLine($"Gewonnen hat {winner} mit {sieger} Punkten zu {verlierer}");
            Console.WriteLine($"Die Bank hatte folgende Karten: {bank.PrintHand()}");
        }
        static Stack<Karte> Mischen(Stack<Karte> karten) {
            Random random = new Random();
            for (int i = 0; i < 100; i++) {
                int x = random.Next(1, 10);
                karten = Tiefstapler(Hochstapler(x, karten));
            }
            return karten;
        }
        static List<Stack<Karte>> Hochstapler(int zahl, Stack<Karte> stapel) {
            List<Stack<Karte>> ergebnis = new();
            for (int i = 0; i < zahl; i++) {
                ergebnis.Add(new Stack<Karte>());
            }
            int karten = stapel.Count / zahl;
            int rest = stapel.Count % zahl;
            while (stapel.Count != 0) {
                for (int i = 0; i < zahl; i++) {
                    for (int j = 0; j < karten; j++) {
                        if (stapel.Count > 0) {
                            ergebnis[i].Push(stapel.Pop());
                        }
                    }
                    if (rest > 0) {
                        rest--;
                        ergebnis[i].Push(stapel.Pop());
                    }
                }
            }
            return ergebnis;
        }
        static Stack<Karte> Tiefstapler(List<Stack<Karte>> stapel) {
            Stack<Karte> ergebnis = new();
            foreach (Stack<Karte> item in stapel) {
                while (item.Count > 0) {
                    ergebnis.Push(item.Pop());
                }
            }
            return ergebnis;
        }
        static Karte KartenVergleich(Karte karte1, Karte karte2) {
            Karte ergebnis = null;
            if (karte1.Farbwert() == karte2.Farbwert()) {
                if (karte1.Wertigkeit() > karte2.Wertigkeit()) {
                    ergebnis = karte1;
                }
                else {
                    ergebnis = karte2;
                }
            }
            else {
                if (karte1.Farbwert() > karte2.Farbwert()) {
                    ergebnis = karte1;
                }
                else {
                    ergebnis = karte2;
                }
            }
            return ergebnis;
        }
        static Stack<Karte> gemischteKarten () {
            Stack<Karte> stapel = new Stack<Karte>();
            String[] werte = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Bube", "Dame", "Koenig", "As" };
            foreach (string item in werte) {
                stapel.Push(new() { Farbe = "Pik", Wert = item });
                stapel.Push(new() { Farbe = "Herz", Wert = item });
                stapel.Push(new() { Farbe = "Kreuz", Wert = item });
                stapel.Push(new() { Farbe = "Karo", Wert = item });
            }
            stapel = Mischen(stapel);
            return stapel;
        }
        static void Main(string[] args) {
            
            bool running = true;
            string auswahl;
            Stack<Karte> reserve;
            Console.WriteLine("Willkommen zu Black Jack!");
            while (running) {                
                Console.WriteLine("Bitte wählen Sie aus:\n1) Neues Spiel\nQ/q) Spiel Beenden");
                auswahl = Console.ReadLine();
                switch (auswahl) {
                    case "1":
                    Spiel(gemischteKarten());
                    break;
                    case "q":
                    case "Q":
                    running = false;
                    break;
                    default:
                    break;
                }
            }
            //for (int i = 0; i < 13; i++) {
            //    stapelA.Push(stapel1.Pop());
            //    stapelA.Push(stapel2.Pop());
            //    stapelA.Push(stapel3.Pop());
            //    stapelA.Push(stapel4.Pop());
            //}
            //stapelA = Tiefstapler(HochStapler(7,stapelA));
            //Karte k1, k2, winner;
            //while (stapel1.Count >= 2) {
            //    k1 = stapel1.Pop();
            //    k2 = stapel1.Pop();
            //    Console.WriteLine($"Vergleiche {k1.Farbe} {k1.Wert} mit {k2.Farbe} {k2.Wert}");
            //    winner = KartenVergleich(k1, k2);
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine($"gewonnen hat: {winner.Farbe} {winner.Wert}");
            //    Console.ForegroundColor = ConsoleColor.Gray;
            //    Console.WriteLine("");
            //}
            //Console.WriteLine("Stapel 1:");
            //foreach (Karte item in stapel1) {
            //    Console.WriteLine($"Farbe: {item.Farbe} Wert: {item.Wert}");
            //}
            //Console.WriteLine("");
            //Console.WriteLine("Stapel 2:");
            //foreach (Karte item in stapel2) {
            //    Console.WriteLine($"Farbe: {item.Farbe} Wert: {item.Wert}");
            //}
            //Console.WriteLine("");
            //for (int i= 0; i < 13; i++) {
            //    stapelA.Push(stapel1.Pop());
            //    stapelA.Push(stapel2.Pop());
            //}
            //Console.WriteLine("Stapel 3:");
            //foreach (Karte item in stapelA) {
            //    Console.WriteLine($"Farbe: {item.Farbe} Wert: {item.Wert}");
            //}
            //Console.WriteLine("");
            //for (int i = 0; i< stapelA.Count; i++) {
            //    stapel1.Push(stapelA.Pop());
            //    stapel2.Push(stapelA.Pop());
            //    stapel3.Push(stapelA.Pop());
            //    stapel4.Push(stapelA.Pop());
            //}
            //foreach (Karte item in stapel1) {
            //    stapel3.Push(item);
            //}
            //foreach (Karte item in stapel2) {
            //    stapel4.Push(item);
            //}
            //foreach (Karte item in stapel3) {
            //    stapel4.Push(item);
            //}
            //Console.WriteLine("Stapel gemischt:");
            //foreach (Karte item in stapel4) {
            //    Console.WriteLine($"Farbe: {item.Farbe} Wert: {item.Wert}");
            //}
            //Console.WriteLine("");
            //foreach (Karte item in stapelA) {
            //    Console.WriteLine($"Farbe: {item.Farbe} Wert: {item.Wert}");
            //}
            //Console.WriteLine("");
            //int x = 1;
            //foreach (Stack<Karte> item in HochStapler(11, stapelA)) {
            //    Console.WriteLine($"Neuer Stapel {x}: ");
            //    foreach (Karte karte in item) {
            //        Console.WriteLine($"Farbe: {karte.Farbe} Wert: {karte.Wert}");
            //    }
            //    Console.WriteLine("");
            //    x++;
            //}
        }
    }
}