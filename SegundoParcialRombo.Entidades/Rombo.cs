namespace SegundoParcialRombo.Entidades
{
    public class Rombo
    {
        private int dM;
        private int dm;

        public Contorno contorno { get; set; }
        public int DMayor { get; set; }
        public int DMenor { get; set; }

        public Rombo()
        {

        }

        public Rombo(int dM, int dm)
        {
            this.dM = dM;
            this.dm = dm;
        }

        public double CalcularLado()
        {
            return Math.Sqrt((Math.Pow(2, DMayor / 2)) + (Math.Pow(2, DMenor / 2)));

        }
        public double GetPerimetro()
        {
            return 4 * CalcularLado();
        }
        public double GetArea()
        {
            return DMayor * DMenor / 2;
        }


    }
}
