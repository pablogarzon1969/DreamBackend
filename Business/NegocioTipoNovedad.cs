using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public  class NegocioTipoNovedad
    {
        private UnitOfWork unit;

        public NegocioTipoNovedad()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Permite obtener los tipos de novedades 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TipoNovedad> GetTypeNovelties()
        {
            IEnumerable<TipoNovedad> typeNovelties;
            return typeNovelties = unit.TipoNovedadRecursoRepository.Get().AsEnumerable();
        }

        public TipoNovedad GetTypeNoveltyById(Int32 Id)
        {
            var typeVovelty = unit.TipoNovedadRecursoRepository.FindSingleBy(x => x.IdTipoNovedad == Id);
            if (typeVovelty == null)
                return null;
            return typeVovelty;
        }

        /// <summary>
        /// Permite el tipo de novedad
        /// </summary>
        /// <param name="typeNovelty"></param>
        /// <returns></returns>
        public TipoNovedad TypeNoveltyCreate(TipoNovedad typeNovelty)
        {
            unit.TipoNovedadRecursoRepository.Insert(typeNovelty);
            unit.Save();
            return typeNovelty;
        }


        /// <summary>
        /// Permite eliminar el tipo de novedad
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTypeNovelty(Int32 id)
        {
            var typeNovelty = unit.TipoNovedadRecursoRepository.GetByID(id);
            if (typeNovelty != null)
            {
                unit.TipoNovedadRecursoRepository.Delete(typeNovelty);
                unit.Save();
            }
        }

        /// <summary>
        /// Permite actualizar la informacion correspondiente al tipo de novedad
        /// </summary>
        /// <param name="typeNoveltie"></param>
        /// <returns></returns>
        public String UpdateTypeNovelty(TipoNovedad typeNovelty)
        {
            String msg;
            var tiponovedadconsulta = unit.TipoNovedadRecursoRepository.GetByID(typeNovelty.IdTipoNovedad);

            if (tiponovedadconsulta == null)
            {
                msg = "La novedad no se encuentra";
            }
            else
            {
                tiponovedadconsulta.Descripcion = typeNovelty.Descripcion;
                tiponovedadconsulta.Activa = typeNovelty.Activa;
                tiponovedadconsulta.IdTipoNovedad = typeNovelty.IdTipoNovedad;
                unit.TipoNovedadRecursoRepository.Update(tiponovedadconsulta);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }
    }
}
