using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Modelo
    {
        private int _id;
        private string _descripcion;
        private int _año;
        private int _MarcaID;
        private string _Marca;

       


        public int ID { get { return this._id; } set { this._id = value; } }
        public string Descripcion { get { return this._descripcion; } set { this._descripcion = value; } }
        public int Año { get { return this._año; } set { this._año = value; } }
        public int MarcaID { get { return this._MarcaID; } set { this._MarcaID = value; } }
        public string Marca { get { return this._Marca; } set { this._Marca = value; } }


        public Modelo() { }


    }
}