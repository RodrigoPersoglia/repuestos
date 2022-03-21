using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Usuario    {
        
        private string _user;

      
    
        private bool _tablaArchivos;
        private bool _tablaArticulos;
        private bool _tablaCliente;
        private bool _tablaPedidos;
        private bool _tablaMatrices;
        private bool _tablaUsuario;
        private bool _tablaReportes;
        private bool _altaArticulos;
        private bool _bajaArticulos;
        private bool _modificaArticulos;
        private bool _altaClientes;
        private bool _modificaClientes;
        private bool _altaPedidos;
        private bool _modificaPedidos;
        private bool _detallePedidos;
        private bool _altaMatrices;
        private bool _modificaMatrices;
        private bool _nitrurado;




        public string User { get { return this._user; } set { this._user = value; } }
        public bool TablaArchivos { get { return this._tablaArchivos; }  set { this._tablaArchivos = value; } }
        public bool TablaArticulos { get { return this._tablaArticulos; }  set { this._tablaArticulos = value; } }
        public bool TablaCliente { get { return this._tablaCliente; }  set { this._tablaCliente = value; } }
        public bool TablaPedidos { get { return this._tablaPedidos; }  set { this._tablaPedidos = value; } }
        public bool TablaMatrices { get { return this._tablaMatrices; } set { this._tablaMatrices = value; } }
        public bool Tablausuario { get { return this._tablaUsuario; } set { this._tablaUsuario = value; } }
        public bool TablaReporte { get { return this._tablaReportes; } set { this._tablaReportes = value; } }

        public bool AltaArticulos { get { return this._altaArticulos; } set { this._altaArticulos = value; } }
        public bool BajaArticulos { get { return this._bajaArticulos; } set { this._bajaArticulos = value; } }
        public bool ModificaArticulos { get { return this._modificaArticulos; } set { this._modificaArticulos = value; } }
        public bool AltaClientes { get { return this._altaClientes; } set { this._altaClientes = value; } }
        public bool ModificaClientes { get { return this._modificaClientes; } set { this._modificaClientes = value; } }
        public bool AltaPedidos { get { return this._altaPedidos; } set { this._altaPedidos = value; } }
        public bool ModificaPedidos { get { return this._modificaPedidos; } set { this._modificaPedidos = value; } }
        public bool DetallePedidos { get { return this._detallePedidos; } set { this._detallePedidos = value; } }
        public bool AltaMatrices { get { return this._altaMatrices; } set { this._altaMatrices = value; } }
        public bool ModificaMatrices { get { return this._modificaMatrices; } set { this._modificaMatrices = value; } }
        public bool Nitrurado { get { return this._nitrurado; } set { this._nitrurado = value; } }


        public Usuario() { }




    }
}