using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Cliente
    {
        private int _id;
        private int _numero;
        private string _alias;
        private string __razonSocial;
        private int _cuit;
        private string _telefono1;
        private string _telefono2;
        private string _email;

        private int _idDireccion;
        private string _direccion;
        private string _ciudad;
        private string _provincia;
        private string _cp;

        private int _idDireccion2;
        private string _direccion2;
        private string _ciudad2;
        private string _provincia2;
        private string _cp2;

        private string _iva;
        private string _tipoDoc;
        private decimal _bonificacion;
        private decimal _recargo;



        public int ID { get { return this._id; } set { this._id = value; } }
        public int Numero { get { return this._numero; } set { this._numero = value; } }
        public string Alias { get { return this._alias; } set { this._alias= value; } }
        public string RazonSocial { get { return this.__razonSocial; } set { this.__razonSocial = value; } }
        public int Cuit { get { return this._cuit; } set { this._cuit = value; } }
        public string Telefono1 { get { return this._telefono1; } set { this._telefono1 = value; } }
        public string Telefono2 { get { return this._telefono2; } set { this._telefono2 = value; } }
        public string Email { get { return this._email; } set { this._email = value; } }

        public int IDDireccion { get { return this._idDireccion; } set { this._idDireccion = value; } }
        public string Direccion { get { return this._direccion; } set { this._direccion = value; } }
        public string Ciudad { get { return this._ciudad; } set { this._ciudad = value; } }
        public string Provincia { get { return this._provincia; } set { this._provincia = value; } }
        public string CP { get { return this._cp; } set { this._cp = value; } }

        public int IDDireccion2 { get { return this._idDireccion2; } set { this._idDireccion2 = value; } }
        public string Direccion2 { get { return this._direccion2; } set { this._direccion2 = value; } }
        public string Ciudad2 { get { return this._ciudad2; } set { this._ciudad2 = value; } }
        public string Provincia2 { get { return this._provincia2; } set { this._provincia2 = value; } }
        public string CP2 { get { return this._cp2; } set { this._cp2 = value; } }

        public string IVA { get { return this._iva; } set { this._iva = value; } }
        public string TIPODOC { get { return this._tipoDoc; } set { this._tipoDoc = value; } }
        public decimal Bonificacion { get { return this._bonificacion; } set { this._bonificacion = value; } }
        public decimal Recargo { get { return this._recargo; } set { this._recargo = value; } }



    }

}
