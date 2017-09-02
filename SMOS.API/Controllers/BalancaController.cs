using AutoMapper;
using SMOS.API.ViewModel;
using SMOS.Domain;
using SMOS.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SMOS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BalancaController : MapController
    {

        public BalancaController()
        {
            AutomMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TB_Balanca, BalancaViewModel>();
                cfg.CreateMap<BalancaViewModel, TB_Balanca>();
            });

            Mapper = AutomMapperConfig.CreateMapper();
        }

        private readonly BalancaService _balancaService = new BalancaService();


        [HttpGet]
        // GET: api/Balanca
        public IEnumerable<BalancaViewModel> GetBalanca()
        {

            var listaBalancas = _balancaService.ObterTodosLazyLoad();
            var balancas = Mapper.Map<IEnumerable<TB_Balanca>, IEnumerable<BalancaViewModel>>(listaBalancas);

            return balancas.ToList();
        }

        // GET: api/Aluno/5
        [ResponseType(typeof(BalancaViewModel))]
        public IHttpActionResult GetBalanca(int id)
        {
            var _balanca = _balancaService.ObterPorIdLazyLoad(id);
            var balanca = Mapper.Map<TB_Balanca, BalancaViewModel > (_balanca);
            return Ok(balanca);
        }


        // PUT: api/GetBalanca/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBalanca(int id, BalancaViewModel balancaViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var balanca = Mapper.Map<BalancaViewModel, TB_Balanca>(balancaViewModel);
                balanca.BalancaId = id;
                _balancaService.Atualizar(balanca);
            }
            catch
            {
                throw;
            }


            return Content(HttpStatusCode.OK, "Registro alterado com sucesso");
        }

        // POST: api/Balanca
        [ResponseType(typeof(BalancaViewModel))]
        public IHttpActionResult PostBalanca(BalancaViewModel balancaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var balanca = Mapper.Map<BalancaViewModel, TB_Balanca>(balancaViewModel);
            _balancaService.Salvar(balanca);


            return CreatedAtRoute("DefaultApi", new { id = balancaViewModel.BalancaId }, balancaViewModel);
        }

        // DELETE: api/Balanca/5
        [ResponseType(typeof(BalancaViewModel))]
        public IHttpActionResult DeleteBalanca(int id)
        {
            var _balanca = _balancaService.ObterPorIdLazyLoad(id);
            try
            {
                _balancaService.Excluir(_balanca);
            }
            catch
            {
                throw;
            }
            return Content(HttpStatusCode.OK, "Excluído com sucesso");
        }

        protected override void Dispose(bool disposing)
        {
            _balancaService.Dispose();
        }
    }
}