using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

	namespace Login
{
	public class rendimiento
	{
		public rendimiento() { }


		public int largoTocho;
		public double largoExtrusion;
		public int cortes;
		public double rendimientos;
		public double despunte_Perfil;
		public int cant_Tochos;

		public rendimiento(double largoPerfil,double pesoMetro,int salidas, double diametro, double LargoBarrote, double kg_pedido)
		{
			try
			{

				//conversiones
				largoPerfil = largoPerfil / 1000;
				diametro = diametro * 25.4;
				LargoBarrote = LargoBarrote / 1000;
				double pesoEspecifico;
				if (diametro == 127) { pesoEspecifico = 34.203; }
				else { pesoEspecifico = 49.252; }

				//parametros predefinidos
				double despunte = 1;
				int largo_mesa = 32;

				//variables auxiliares
				int cant_Tiras = 0;
				double descarte = 0;


				double largo_culote = 1.25 * 25.4 / 1000;
				double peso_culote = Math.Round(pesoEspecifico * largo_culote, 2);
				double peso_barrote = Math.Round(pesoEspecifico * LargoBarrote, 2);
				double KgUtiles = peso_barrote - peso_culote;
				double largo_extrusion = Math.Round(KgUtiles / pesoMetro / salidas, 2);
				int cant_Tiras_por_Tirada = (int)((int)(largo_mesa - despunte) / largoPerfil);
				int Largo_Tirada = (int)(cant_Tiras_por_Tirada * largoPerfil + (int)despunte);
				int cantidad_Tiradas = (int)largo_extrusion / Largo_Tirada;
				descarte += cantidad_Tiradas;
				cant_Tiras += cantidad_Tiradas * cant_Tiras_por_Tirada * salidas;
				double sobrante = largo_extrusion - (cantidad_Tiradas * Largo_Tirada);
				if (sobrante > (largoPerfil + despunte))
				{
					int Tiras = (int)((int)(sobrante - despunte) / largoPerfil * salidas);
					cant_Tiras += Tiras;
					sobrante -= (Tiras / salidas) * largoPerfil;
				}

				//Guardamos en las variables de instancia
				despunte_Perfil = Math.Round((largo_extrusion-((cant_Tiras/salidas)*((double)largoPerfil))), 2);
				largoTocho = (int)(LargoBarrote * 1000);
				largoExtrusion = largo_extrusion;
				cortes = cant_Tiras / salidas;
				double kg = cant_Tiras * pesoMetro * largoPerfil;
				rendimientos = Math.Round((kg * 100 / peso_barrote), 2);
				double cant_Tochos2 = kg_pedido / kg * 1.05;
				int cant_Tochos3 = (int)Math.Round((kg_pedido / kg * 1.05), 0);
				if ((cant_Tochos2 - cant_Tochos3) > 0) { cant_Tochos = cant_Tochos3 + 1; }
				else { cant_Tochos = cant_Tochos3; }
			}
            catch (Exception) { largoTocho = (int)(LargoBarrote*1000); }

		}


	}




}


