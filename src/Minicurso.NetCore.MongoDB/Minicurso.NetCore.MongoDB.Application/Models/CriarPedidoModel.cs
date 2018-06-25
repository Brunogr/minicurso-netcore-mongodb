using Minicurso.NetCore.MongoDB.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application
{
    public class CriarPedidoModel
    {
        public AtendenteModel atendente { get; set; }
        public int Mesa { get; set; }
    }
}
