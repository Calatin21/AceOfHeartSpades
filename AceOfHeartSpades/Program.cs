namespace AceOfHeartSpades {
    internal class Program {
        static void Main(string[] args) {
            String[] werte = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Bauer", "Dame", "Koenig", "As" };
            Stack<Karte> stapel1 = new();
            Stack<Karte> stapel2 = new();
            Stack<Karte> stapel3 = new();
            Stack<Karte> stapel4 = new();
            Stack<Karte> stapelA = new();

            foreach (string item in werte) {
                stapel1.Push(new() { Farbe = "Pik", Wert = item });
            }
            foreach (string item in werte) {
                stapel2.Push(new() { Farbe = "Herz", Wert = item });
            }
            Console.WriteLine("Stapel 1:");
            foreach (Karte item in stapel1) {
                Console.WriteLine($"Farbe: {item.Farbe} Wert: {item.Wert}");
            }
            Console.WriteLine("");
            Console.WriteLine("Stapel 2:");
            foreach (Karte item in stapel2) {
                Console.WriteLine($"Farbe: {item.Farbe} Wert: {item.Wert}");
            }
            Console.WriteLine("");
            for (int i= 0; i < 13; i++) {
                stapelA.Push(stapel1.Pop());
                stapelA.Push(stapel2.Pop());
            }
            Console.WriteLine("Stapel 3:");
            foreach (Karte item in stapelA) {
                Console.WriteLine($"Farbe: {item.Farbe} Wert: {item.Wert}");
            }

            for (int i = 0; i< stapelA.Count; i++) {
                stapel1.Push(stapelA.Pop());
                stapel2.Push(stapelA.Pop());
                stapel3.Push(stapelA.Pop());
                stapel4.Push(stapelA.Pop());
            }
            foreach (Karte item in stapel1) {
                stapel3.Push(item);
            }
            foreach (Karte item in stapel2) {
                stapel4.Push(item);
            }
            foreach (Karte item in stapel3) {
                stapel4.Push(item);
            }
            Console.WriteLine("Stapel gemischt:");
            foreach (Karte item in stapel4) {
                Console.WriteLine($"Farbe: {item.Farbe} Wert: {item.Wert}");
            }
        }
    }
}