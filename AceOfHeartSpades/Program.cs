namespace AceOfHeartSpades {
    internal class Program {
        static Stack<Karte> Spiel (Stack<Karte> karten) {
            Random random = new Random();           
            for (int i = 0; i < 100; i++) {
                int x =random.Next(1,10);
                karten = Tiefstapler(Hochstapler(x, karten));
            }
            foreach (Karte karte in karten) {
                    Console.WriteLine($"Farbe: {karte.Farbe} Wert: {karte.Wert}");
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
        static void Main(string[] args) {
            String[] werte = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Bube", "Dame", "Koenig", "As" };
            Stack<Karte> stapelA = new();

            foreach (string item in werte) {
                stapelA.Push(new() { Farbe = "Pik", Wert = item });           
                stapelA.Push(new() { Farbe = "Herz", Wert = item });         
                stapelA.Push(new() { Farbe = "Kreuz", Wert = item });         
                stapelA.Push(new() { Farbe = "Karo", Wert = item });
            }
            bool running = true;
            string auswahl;
            Console.WriteLine("Willkommen zu Black Jack!");
            while (running) {
                Console.WriteLine("Bitte wählen Sie aus:\n1) Neues Spiel\nQ/q) Spiel Beenden");
                auswahl = Console.ReadLine();
                switch (auswahl) {
                    case "1":
                    stapelA = Spiel(stapelA);
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