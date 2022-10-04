namespace BlazorAppAsambly2TEST.Client.Shared
{
    public class operaciones
    {
        private int numeroA;
        private int numeroB;
        private string operacionAritmetica;
        private float res;
        
        public operaciones()
        {

        }
        public operaciones(int numeroA, int numeroB, float res)
        {
            this.numeroA = numeroA;
            this.numeroB = numeroB;
            this.res = res;
        }
        public int NumeroA { get => numeroA; set => numeroA = value; }
        public int NumeroB { get => numeroB; set => numeroB = value; }

        public string OperacionAritmetica { get => operacionAritmetica; set => operacionAritmetica = value; }
        public float Res { get => res; set => res = value; }
    }
}
