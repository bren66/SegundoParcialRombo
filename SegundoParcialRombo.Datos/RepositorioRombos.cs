using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Datos
{
    public class RepositorioRombos
    {
        private List<Rombo>? rombos;
        private string? nombreArchivo = "Rombos.txt";
        private string? rutaArchivo = AppDomain.CurrentDomain.BaseDirectory;
        private string? rutaCompletaArchivo;

        public RepositorioRombos()
        {
            rombos = new List<Rombo>();
            LeerDatos();
        }


        public int GetCantidad()
        {
            return rombos!.Count;

        }
        public bool Existe(Rombo rombo)
        {
            if (rombos!.Any(r => r.DMenor == r.DMenor && r.DMayor == r.DMayor && r.contorno == r.contorno))
            {
                return false;

            }
            return true;
        }
        public void Agregar(Rombo rombo)
        {

            rombos!.Add(rombo);

        }

        public void GuardarDatos()
        {
            rutaCompletaArchivo = Path.Combine(rutaArchivo!, nombreArchivo!);
            using (var escritor = new StreamWriter(rutaCompletaArchivo))
            {
                foreach (var rombo in rombos!)
                {
                    string linea = ConstruirLinea(rombo);
                    escritor.WriteLine(linea);
                }
            }
        }

        private string ConstruirLinea(Rombo rombos)
        {
            return $"{rombos.DMayor}|{rombos.DMenor}|{rombos.contorno.GetHashCode()}";
        }

        private List<Rombo> LeerDatos()
        {
            var listaRombos = new List<Rombo>();
            rutaCompletaArchivo = Path.Combine(rutaArchivo!, nombreArchivo!);
            if (!File.Exists(rutaCompletaArchivo))
            {
                return listaRombos;
            }
            using (var lector = new StreamReader(rutaCompletaArchivo))
            {
                while (!lector.EndOfStream)
                {
                    string? linea = lector.ReadLine();
                    Rombo? rombo = ContruirRombo(linea);
                    listaRombos.Add(rombo!);
                }
            }
            return listaRombos;
        }

        private Rombo? ContruirRombo(string? linea)
        {
            var campos = linea!.Split('|');
            var DM = int.Parse(campos[0]);
            var dm = int.Parse(campos[1]);
            return new Rombo(DM, dm);

        }
    }
}
