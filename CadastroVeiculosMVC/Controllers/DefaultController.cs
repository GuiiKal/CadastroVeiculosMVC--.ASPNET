using CadastroVeiculosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroVeiculosMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            /*Veiculo v = new Veiculo();
            v.Placa = "AA234G6"; //setando valores
            string placaNova = v.Placa; //atribuindo a nova variavel*/

            return View();
        }
        public ActionResult Listar()
        {
            List<Veiculo> lista = Veiculo.listarVeiculos();
            return View(lista);
        }

        public ActionResult Excluir(string id)
        {
            Veiculo v = new Veiculo();
            v.Placa = id;
            string msg =  v.ExcluirM();
            TempData["msg"] = msg; 
            return RedirectToAction("Listar");
        }

        public ActionResult Salvar()
        {
            //esse método chama a view
            return View();
        }

        [HttpPost] //esse metdo so trata requisições vindas dos formularios (method="post")
        public ActionResult Salvar(string placa, string modelo)
        {
            //esse método recebe as informações
            Veiculo v = new Veiculo();
            v.Placa = placa;
            v.Modelo = modelo;
            TempData["msg"] = v.SalvarM();
            return View();
        }
    }
}