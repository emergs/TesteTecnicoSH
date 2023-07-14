using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using TesteTecnico.Data;
using TesteTecnico.Models;

namespace TesteTecnico.Controllers
{
    public class ClienteController : Controller
    {
        readonly private ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ClienteModel> cliente = _db.Cliente;
            return View(cliente);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ClienteModel cliente = _db.Cliente.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ClienteModel cliente = _db.Cliente.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public class ClasseFiltro
        {
            public string ?NomeRazaoSocial { get; set; }
            public string ?Email { get; set; }
            public string ?Telefone { get; set; }
            public DateTime ?DataDeCadastro { get; set; }

            public string ?Bloqueado { get; set; }
        }
        
        [HttpGet]
        public IActionResult Filtrar(ClasseFiltro dados)
        {
            if (dados.NomeRazaoSocial != null)
            {
            IEnumerable<ClienteModel> cliente = _db.Cliente.Where(x => x.Nome.Contains(dados.NomeRazaoSocial)).ToList();
            return View(cliente);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteModel cliente)
        {
            if (ModelState.IsValid) 
            {
                bool emailExist = _db.Cliente.Any(x => x.Email == cliente.Email);
                bool cpfOrCnpjExist = _db.Cliente.Any(x => x.CpfCnpj == cliente.CpfCnpj);

                if (emailExist)
                {
                    TempData["MensagemErro"] = "Este email já está cadastrado para outro cliente";
                    return View();
                }

                if (cpfOrCnpjExist)
                {
                    TempData["MensagemErro"] = "Este CPF/CNPJ já está cadastrado para outro cliente";
                    return View();
                }

                _db.Cliente.Add(cliente);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Cliente criado com sucesso!!";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Cliente.Update(cliente);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cliente editado com sucesso!!";

                return RedirectToAction("Index");
            }


            return View(cliente);
        }

        [HttpPost]
        public IActionResult Excluir(ClienteModel cliente)
        {
            if(cliente == null)
            {
                return NotFound();
            }

            _db.Cliente.Remove(cliente);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Cliente deletado com sucesso!!";

            return RedirectToAction("Index");
        }
       
    }
}
