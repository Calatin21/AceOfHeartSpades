namespace AceOfHeartSpades {
    internal class Karte {
        public string Farbe { get; set; }
        public string Wert { get; set; }
        public int Farbwert () {
            int ergebnis = 0;
            switch (this.Farbe) {
                case "Kreuz":
                ergebnis = 4;
                break;
                case "Pik":
                ergebnis = 3;
                break;
                case "Karo":
                ergebnis = 2;
                break;
                case "Herz":
                ergebnis = 1;
                break;
                default:
                break;
            }
            return ergebnis;
        }
        public int Wertigkeit () {
            int ergebnis = 0;
            switch (this.Wert) {
                case "1":
                ergebnis = 1;
                break;
                case "2":
                ergebnis = 2;
                break;
                case "3":
                ergebnis = 3;
                break;
                case "4":
                ergebnis = 4;
                break;
                case "5":
                ergebnis = 5;
                break;
                case "6":
                ergebnis = 6;
                break;
                case "7":
                ergebnis = 7;
                break;
                case "8":
                ergebnis = 8;
                break;
                case "9":
                ergebnis = 9;
                break;
                case "10":
                ergebnis = 10;
                break;
                case "Bube":
                ergebnis = 11;
                break;
                case "Dame":
                ergebnis = 12;
                break;
                case "Koenig":
                ergebnis = 13;
                break;
                case "As":
                ergebnis = 14;
                break;
                default:
                break;
            }
            return ergebnis;
        }
    }
}
