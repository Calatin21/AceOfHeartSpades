namespace AceOfHeartSpades {
    internal class Hand {
        public List<Karte> karten { get; set; } = new List<Karte>();
        public String PrintHand () {
            string ergebnis = "";
            foreach (Karte item in karten) {
                ergebnis += item.PrintKarte();
                ergebnis += " ";
            }
            return ergebnis;
        }
        public int AsZaehlen() {
            int ergebnis = 0;
            foreach (Karte item in karten) {
                if (item.Wert == "As") {
                    ergebnis++;
                }
            }
            return ergebnis;
        }
        public int Wert() {
            int ergebnis = 0;
            foreach (Karte item in karten) {
                ergebnis += item.Wertigkeit();
            }
            if (AsZaehlen() > 0) {
                int x = AsZaehlen();
                for (int i = 0; i < x; i++) {
                    if (ergebnis > 21) {
                        ergebnis = ergebnis - 10;
                    }
                }
            }
            return ergebnis;
        }
    }
}
