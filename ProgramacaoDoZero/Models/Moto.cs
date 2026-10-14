namespace ProgramacaoDoZero.Models
{
    public class Moto : Veiculo
    {
        public Moto()
        {
            QuantidadeRodas = 2;

            TanqueCombustivel = 15;
        }

        public override void Acelerar()
        {
            Injetarcombustivel(1);
        }

        private void Injetarcombustivel(int quantidadeCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - quantidadeCombustivel;
        }

        public int QuantidadeRodas { get; set; }
    }
}
