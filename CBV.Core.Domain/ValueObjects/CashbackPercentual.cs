using CBV.Core.Domain.Enum;

namespace CBV.Core.Domain.ValueObjects
{
    public class CashbackPercentual
    {
        public static decimal Get(int generoId, int diaSemanaId)
        {
            var generoEnum = (GeneroEnum)generoId;
            var diaSemanaEnum = (DiaSemanaEnum)diaSemanaId;

            return (generoEnum, diaSemanaEnum) switch
            {
                //POP 25% 7% 6% 2% 10% 15% 20%
                (GeneroEnum.POP, DiaSemanaEnum.Domingo) => 25M,
                (GeneroEnum.POP, DiaSemanaEnum.Segunda) => 07M,
                (GeneroEnum.POP, DiaSemanaEnum.Terca) => 06M,
                (GeneroEnum.POP, DiaSemanaEnum.Quarta) => 02M,
                (GeneroEnum.POP, DiaSemanaEnum.Quinta) => 10M,
                (GeneroEnum.POP, DiaSemanaEnum.Sexta) => 15M,
                (GeneroEnum.POP, DiaSemanaEnum.Sabado) => 20M,

                //MPB 30% 5% 10% 15% 20% 25% 30%
                (GeneroEnum.MPB, DiaSemanaEnum.Domingo) => 30M,
                (GeneroEnum.MPB, DiaSemanaEnum.Segunda) => 05M,
                (GeneroEnum.MPB, DiaSemanaEnum.Terca) => 10M,
                (GeneroEnum.MPB, DiaSemanaEnum.Quarta) => 15M,
                (GeneroEnum.MPB, DiaSemanaEnum.Quinta) => 20M,
                (GeneroEnum.MPB, DiaSemanaEnum.Sexta) => 25M,
                (GeneroEnum.MPB, DiaSemanaEnum.Sabado) => 30M,

                //CLASSIC 35% 3% 5% 8% 13% 18% 25%
                (GeneroEnum.CLASSIC, DiaSemanaEnum.Domingo) => 35M,
                (GeneroEnum.CLASSIC, DiaSemanaEnum.Segunda) => 03M,
                (GeneroEnum.CLASSIC, DiaSemanaEnum.Terca) => 05M,
                (GeneroEnum.CLASSIC, DiaSemanaEnum.Quarta) => 08M,
                (GeneroEnum.CLASSIC, DiaSemanaEnum.Quinta) => 13M,
                (GeneroEnum.CLASSIC, DiaSemanaEnum.Sexta) => 18M,
                (GeneroEnum.CLASSIC, DiaSemanaEnum.Sabado) => 25M,

                //ROCK 40% 10% 15% 15% 15% 20% 40%
                (GeneroEnum.ROCK, DiaSemanaEnum.Domingo) => 40M,
                (GeneroEnum.ROCK, DiaSemanaEnum.Segunda) => 10M,
                (GeneroEnum.ROCK, DiaSemanaEnum.Terca) => 15M,
                (GeneroEnum.ROCK, DiaSemanaEnum.Quarta) => 15M,
                (GeneroEnum.ROCK, DiaSemanaEnum.Quinta) => 15M,
                (GeneroEnum.ROCK, DiaSemanaEnum.Sexta) => 20M,
                (GeneroEnum.ROCK, DiaSemanaEnum.Sabado) => 40M,
            };
        }

    }
}





