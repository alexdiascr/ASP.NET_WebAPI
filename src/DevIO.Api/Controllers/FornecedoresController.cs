using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Api.Controllers
{
    [Route("api/fornecedores")]
    public class FornecedoresController : MainController
    {
        //Validadacao de notificacoes de erro

        //Validacao de modelstate

        //validacao de operacao de negocios


        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
        {
            var fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());

            return fornecedores;
        }
    }
}