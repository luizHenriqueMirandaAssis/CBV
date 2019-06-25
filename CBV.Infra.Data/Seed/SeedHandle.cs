using CBV.Core.Application.Interfaces.Handle;
using CBV.Core.Application.Interfaces.Repositories;
using CBV.Core.Domain.Entities;
using CBV.Core.Domain.Enum;
using CBV.Core.Domain.Shared;
using CBV.Core.Domain.ValueObjects;
using System.Collections.Generic;

namespace CBV.Infra.Data.Seed
{
    public class SeedHandle: ISeedHandle
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly ICashbackRepository _cashbackRepository;
        private readonly IDiaSemanaRepository _diaSemanaRepository;

        public SeedHandle(IGeneroRepository generoRepository, ICashbackRepository cashbackRepository, IDiaSemanaRepository diaSemanaRepository)
        {
            _generoRepository = generoRepository;
            _cashbackRepository = cashbackRepository;
            _diaSemanaRepository = diaSemanaRepository;
        }

        public void Seed()
        {
            if (!_generoRepository.Any())
                _generoRepository.AddList(BuildListGenero());

            if (!_diaSemanaRepository.Any())
                _diaSemanaRepository.AddList(BuildListDiaSemana());

            if (!_cashbackRepository.Any())
                _cashbackRepository.AddList(BuildListCashback());
        }

        #region Auxiliary methods

        private static List<Genero> BuildListGenero()
        {
            var list = Genero.ListEmpty();

            foreach (var item in Enumerators.GetEnumDescriptions(typeof(GeneroEnum)))
            {
                var newObj = Genero.Build(item.Key, item.Value);
                list.Add(newObj);
            }

            return list;
        }

        private static List<DiaSemana> BuildListDiaSemana()
        {
            var list = DiaSemana.ListEmpty();

            foreach (var item in Enumerators.GetEnumDescriptions(typeof(DiaSemanaEnum)))
            {
                var newObj = DiaSemana.Build(item.Key, item.Value);
                list.Add(newObj);
            }

            return list;
        }

        private static List<Cashback> BuildListCashback()
        {
            var list = Cashback.ListEmpty();
            var cashbackId = 1;

            foreach (var itemGenero in Enumerators.GetEnumDescriptions(typeof(GeneroEnum)))
            {
                foreach (var itemDia in Enumerators.GetEnumDescriptions(typeof(DiaSemanaEnum)))
                {
                    var newObj = Cashback.BuildInitial(cashbackId, (GeneroEnum)itemGenero.Key);

                    newObj.DiaSemanaId = (DiaSemanaEnum)itemDia.Key;
                    newObj.Percentual = CashbackPercentual.Get(itemGenero.Key, itemDia.Key);

                    list.Add(newObj);
                    cashbackId++;
                }
            }

            return list;
        }
        #endregion
    }
}
